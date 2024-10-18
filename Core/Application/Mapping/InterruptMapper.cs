using Application.DTOs;
using Application.ViewModal;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class InterruptMapper
    {
        //iki farklı kaynaktan gelen veriyi işleyip kullanıcıya istediği modeli dönüyor.(deviceList ve pingList)
        public List<InterruptViewModel> MappReport(List<Devices> deviceList, List<Ping> PingList)
        {
            List<InterruptViewModel> model = new List<InterruptViewModel>();
            //fonksiyonun dönmesini beklediği objeyi döndürdük.
            foreach (var device in deviceList)
            {
                //ilişkisel bağlantının kontrolü 
                var ping = PingList.Where(x => x.pingID == device.pingid).FirstOrDefault();

                //döngü içerisindeki her işlemde bize bir interruptviewmodel nesnesi oluşturduk.
                InterruptViewModel i = new InterruptViewModel();
               
                i.PingId = device.pingid;
                i.CihazAdi= device.cihazAdi;
                i.Status = ping.status;
                model.Add(i);
                
            }
            return model;
            //controller da verileri hem infrastructuredan hem de persistencedan çekicem.

        }
    }
}
