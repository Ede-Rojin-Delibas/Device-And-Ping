using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Utilities;
using Domain;

namespace Persistance
{
    //cache servisi jenerik yapma
    public class CacheServices <T> where T : class //JENERİK,tek parametre ,:kalıtım
    { 
       
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(60);//cache anahtarının ve süresinin tanımlanması; cache de tutulan verinin
                                                                            //ne kadar saklanacağını belirten zaman aralığı 

        public List<T> GetCachedData(IMemoryCache _memoryCache, string cacheKey)
        {
            if (!_memoryCache.TryGetValue(CacheKeys.cacheKey, out List<T> cacheData))//trygetvalue ile cacheden veri almak,
            //TryGetValue metodu, cache’de belirli bir anahtara karşılık gelen verinin olup olmadığını kontrol eder.
            {
                var context = new AppDbContext();
                //Eğer cache de yoksa veri tabanına git ve veriyi al
                cacheData = context.Set<T>().ToList(); //YARDIMCI METHOD: EF

                //veriyi cache e ekle 
                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(_cacheDuration); //cache süresi 30 dk
                _memoryCache.Set(CacheKeys.cacheKey, cacheData, cacheOptions);

            }
            return cacheData;


        }
        
     }  


}
