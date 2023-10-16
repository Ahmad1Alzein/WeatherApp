using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Net.Mail;

namespace WeatherApp
{
    public class LocationProcessor
    {
        public static async Task<LocationModel> GetLocation()
        {
            ApiHelper.InitializeClient();
            string url = "https://api.ipdata.co/?api-key=067981a21fec2e5937fe51632a1a4d627bdbb18eaed2873f75c365f3";
            using(HttpResponseMessage resposnse = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (resposnse.IsSuccessStatusCode)
                {
                    LocationModel result = await resposnse.Content.ReadAsAsync<LocationModel>();
                    return result;
                }
                else
                {
                    throw new Exception(resposnse.ReasonPhrase);
                }
            }
        }
        public static async Task<LocationModel> GetFullLocation()
        {
            LocationModel result = await GetLocation();
            ApiHelper.InitializeClient();
            ApiHelper.ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiHelper.ApiClient.DefaultRequestHeaders.Add("User-Agent", "WeatherApp"); //hyda lapi bye7tej hal header
            string url= $"https://nominatim.openstreetmap.org/reverse?format=json&lat={result.Latitude}&lon={result.Longitude}";
            using (HttpResponseMessage resposnse = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (resposnse.IsSuccessStatusCode)
                {
                    string res = await resposnse.Content.ReadAsStringAsync();
                    JObject address= (JObject)JObject.Parse(res)["address"];
                    result.Village = (string)address["village"];
                    result.State_district = (string)address["state_district"];
                    result.State = (string)address["state"];

                    return result;
                }
                else
                {

                    throw new Exception(resposnse.ReasonPhrase);
                }
            }
        }
    }
}
