using Application;
using Application.DTOs;
using Application.Mapping;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Persistence.Utilities;
using Persistance;




namespace Persistence.Repository
{

    public class DeviceRepository : IDeviceRepository
    { 
        private bool devicesdtoL;
        private readonly IMemoryCache _memoryCache;

        public DeviceRepository(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
            
        }

        //Tüm cihazları listeleyen fonksiyon
        public BaseResponse<List<Devices>> GetTotalData()
        {
                var model = new BaseResponse<List<Devices>>();
                var cachedDevice = new CacheServices<Devices>().GetCachedData(_memoryCache, CacheKeys.cacheKey);
                model.TotalCount = cachedDevice == null ? 0 : cachedDevice.Count;
                model.Data = cachedDevice;
                return model;

                //var MapDevice = new MappingEntoDTO().GetAllDevices(cachedDevice);
                //if (MapDevice.Any())
                //{
                //    //Başarılı response
                //    /*List<Devices> mappedDevices = new MappingEntoDTO.GetAllDevices(devices);*/
                //    var mappedDevices = new MappingEntoDTO().GetAllDevices(cachedDevice);
                //    return new BaseResponse<List<DeviceDTO>>(mappedDevices, mappedDevices.Count);

                //}
                //else
                //{
                //    return new BaseResponse<List<DeviceDTO>>("Veri bulunamadı.");
                //}

        }

        
        //public List<DeviceDTO> GetAllDevices()
        //{

        //    var cachedDevice = new CacheServices<Devices>().GetCachedData(_memoryCache ,CacheKeys.cacheKey);
        //    var MapDevice = new MappingEntoDTO().GetAllDevices(cachedDevice); //mapping2
        //    return MapDevice;

        //     //    ////json'ı modelleme
        //        //    //string jsondata = file.readalltext("devices.json"); //projeye eklediğimiz dosyayı okuma
        //        //    //list<devices> devicedtol = jsonconvert.deserializeobject<list<devices>>(jsondata); //okuduğumuz json tipindeki dosyayı entity ile eşleştiriyoruz.
        //        //    //var model = new mappingentodto().getalldevices(devicedtol);
        //        //    //return model;

        //        //}

        //}

        public BaseResponse<Devices> GetById(int pingid)
        {
            var model = new BaseResponse<Devices>();
            var cachedDevice = new CacheServices<Devices>().GetCachedData(_memoryCache, CacheKeys.cacheKey);
            var data = cachedDevice.Where(x => x.pingid == pingid).FirstOrDefault(); //Device entity sinden pingid yi filtreleyerek getirdik.
            /*var mapd = new MappingEntoDTO().GetById(data); */  //dto ya çevirdik çünkü kullanıcıya DTO döndürüyoruz.
            model.Data = data;
            model.TotalCount = data == null ? 0 : 1;
            return model;

        }

        public BaseResponse<List<Devices>> GetByName(string cihazAdi)
        {
            //json'ı modelleme
            var model = new BaseResponse<List<Devices>>();
            //string jsonData = File.ReadAllText("devices.json"); //projeye eklediğimiz dosyayı okuma
            /* List<Devices> devicedtoL = JsonConvert.DeserializeObject<List<Devices>>(jsonData);*/ //okuduğumuz json tipindeki dosyayı entity ile eşleştiriyoruz.
                                                                                                    //var model = new MappingEntoDTO().GetAllDevices(devicedtoL);
            var cachedDevice = new CacheServices<Devices>().GetCachedData(_memoryCache, CacheKeys.cacheKey);
            return model;
        }

    }
}
