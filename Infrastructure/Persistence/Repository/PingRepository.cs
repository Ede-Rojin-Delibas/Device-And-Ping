using Application;
using Application.DTOs;
using Application.Mapping;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace Persistence
{
    public class PingRepository : IPingRepo
    {   
        public  List<PingDTO> GetAllPings()
        {
            
            //json ı modelleme 
            string jsonData = File.ReadAllText("PingList");    //projeye eklediğimiz dosyayı okuyoruz
            List<PingDTO> pings = JsonConvert.DeserializeObject<List<PingDTO>>(jsonData); // okuduğumuz json tipindeki dosyayı entity ile eşleştiriyoruz. 
            var dtoModel = new MappingPingtoDTO().GetPings(pings);
            return dtoModel;

        }
        public PingDTO GetByStatus(string status)
        {
            throw new NotImplementedException();


        }


      
    }
    
}
