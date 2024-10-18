using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Mapping
{
    public class MappingPingtoDTO
    {
        public object GetAllPings { get; set; }         //neden oluşturuldu?

        public PingDTO Single(Ping entity)
        {
            PingDTO pingdto=new PingDTO ();
            pingdto.dtoStatus = entity.status;
            pingdto.Id = entity.pingID;
            pingdto.time = entity.zaman;
            return pingdto;


        }
        public List<PingDTO> MapPingList(List<Ping> Entity)
        {
            List<PingDTO> pingList = new List<PingDTO>();
            
            foreach (var item in Entity) 
            {
                PingDTO pingdto = new PingDTO();
                pingdto.dtoStatus = item.status;
                pingdto.Id = item.pingID;
                pingdto.time = item.zaman;

                pingList.Add(pingdto);
            }
            return pingList;  //orderByDescending sondan sıralıyor..OrderByDescending(x=> x.Id).Take(10)



        }

        public object GetPing(List<Ping> pings)
        {
            throw new NotImplementedException();
        }

        public List<PingDTO> GetPings(List<PingDTO> pings)
        {
            throw new NotImplementedException();
        }
    }
}
