using FPTCodeChallenge.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FPTCodeChallenge.Repository.Weather
{
    public class Weather : IWeather
    {
        private static string APIUrl = "http://api.weatherstack.com/";
        private static string APIAccessKey = "cdff88fcef20af0adc5d66908bf11cfa";

        public string IsCanFlyKite(int windSpeed, string IsRaining)
        {
            if (windSpeed > 15 || IsRaining == "No")
            {
                return "No";
            }
            else
            {
                return "Yes";
            }
            throw new NotImplementedException();
        }

        public string IsNeedtoWearSunCream(int UVIndex)
        {
            if (UVIndex > 3)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
            throw new NotImplementedException();
        }

        public string IsRaining(int weatherCode)
        {
            List<int> rainingcodes = new List<int>();
            rainingcodes.Add(176);
            rainingcodes.Add(293);
            rainingcodes.Add(296);
            rainingcodes.Add(299);
            rainingcodes.Add(302);
            rainingcodes.Add(305);
            rainingcodes.Add(308);
            rainingcodes.Add(311);
            if (rainingcodes.Contains(weatherCode))
            {
                return "No";
            }
            else
            {
                return "Yes";
            }
            throw new NotImplementedException();
        }


        public async Task<Base> GetWeatherCondition(int zipCode)
        {
            Base result = new Base();
            string query = zipCode.ToString();
            string param = "current?access_key=" + APIAccessKey + "&query=" + query;
            var client1 = new RestClient(APIUrl);
            var request = new RestRequest(APIUrl + param, Method.Get);
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
            RestResponse response = client1.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<Base>(response.Content);
            }

                return result;

            throw new NotImplementedException();
        }
    }
}
