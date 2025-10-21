using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.DTOS;
using static UCRMTS.dll.Scops;

namespace UCRMTS.dll
{
    public class MTSRequests
    {

        public static async Task<ExchangeDataPiplineDTO> UCRVerification(string ucr, string shipperId)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.UCRVerifiy);
            string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/consignments/{ucr}";
            using (var http = new HttpClient())
            {

                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("requestId", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("shipperId", shipperId);
               var response =  await http.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                  return   JsonConvert.DeserializeObject<ExchangeDataPiplineDTO>(result);
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new UCRException(result,response.StatusCode);
                }
             

            }



        }

        public static async Task<bool> AddingConsignments(ExchangeDataPiplineDTO exchangeDataPipline)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.WaypointSubmit);
            string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/consignments/waypoints";
            using (var http = new HttpClient())
            {

                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("requestId", Guid.NewGuid().ToString());
                var requestBody = JsonConvert.SerializeObject(exchangeDataPipline);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result);
                }


            }
        }
        //public async Task<bool> 


    }
}
