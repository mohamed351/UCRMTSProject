using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.DTOS;
using static UCRMTS.dll.Scops;

namespace UCRMTS.dll
{
    public  class Authication 
    {
        static Authication()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public static string ClientID { get => ConfigurationManager.AppSettings["MTS_ClientID"].ToString(); }

        public static string ClientSecrete { get => ConfigurationManager.AppSettings["MTS_ClientSecret"].ToString(); }


        public async  Task<AuthicationResponseDTO> SignIn(AuthicationType authicationType)
        {
            string url = $"{ ConfigurationManager.AppSettings["MTS_URL"]}/api/auth/token";

            using (var http = new HttpClient())
            {

             var requestBody = JsonConvert.SerializeObject(new
                {
                    grantType= "client_credentials",
                    scope= Scope[authicationType],
                    clientID= ClientID,
                    clientSecret= ClientSecrete
             });

                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                var response = await http.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var Jsondata = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AuthicationResponseDTO>(Jsondata);
                }
                else
                {
                    var currentString = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(currentString);
                }

            }
        }

    }
}
