using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using UCRDemo.DTOS;

namespace UCRDemo.Services
{

    public class UCRService :IUCRService
    {
        public enum AuthicationType
        {
            UCRVerifiy = 0,
            WaypointSubmit = 1,
            ManifestExport = 2
        }
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;

        public UCRService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.clientFactory = clientFactory;
        }

        public string URL { get => configuration["MtsConfiguration:URL"]; }

        public string ClientSecret { get => configuration["MtsConfiguration:ClientSecret"]; }

        public string ClientID { get => configuration["MtsConfiguration:ClientID"]; }

        public async Task<AuthicationResponseDTO> Authication(AuthicationType authicationType)
        {

            string url = $"{URL}/api/auth/token";
            var obj = new
            {
                grantType = "client_credentials",
                scope = Scops.Scope[authicationType],
                clientID = ClientID,
                clientSecret = ClientSecret
            };
            var info = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(obj, info);
            var client = clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return  JsonSerializer.Deserialize<AuthicationResponseDTO>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive  = true});
            }
            else
            {
                throw new HttpRequestException("Error Message");
            }


        }



        private static class Scops
        {

            static Scops()
            {
                Scope = new Dictionary<AuthicationType, string>();
                Scope.Add(AuthicationType.UCRVerifiy, "consignment.verify");
                Scope.Add(AuthicationType.WaypointSubmit, "consignment.waypoint.submit");
                Scope.Add(AuthicationType.ManifestExport, "manifest.export.submit");
            }
           

            internal static Dictionary<AuthicationType, string> Scope { get; set; }
        }

    }
}
