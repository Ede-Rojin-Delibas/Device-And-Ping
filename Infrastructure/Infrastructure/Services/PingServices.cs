using Application.Services;
using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Infrastructure.Services
{
    public class PingServices : IPingServices
    {
        public async Task<List<Ping>> GetAllPings()
        {
            List<Ping> pings = new List<Ping>();
            string url = "http://10.50.10.14:81/PingList ";

            Uri baseURL = new Uri(url);     //constructor uri nedir?
            RestClient client = new RestClient(baseURL);

            RestRequest req = new RestRequest(baseURL,Method.Get);
            var response = await client.ExecuteAsync<List<Ping>>(req); //modele çevirme 
            List<Ping> result = JsonConvert.DeserializeObject<List<Ping>>(response.Content);
            return result;


        }
    }
}
