// See https://aka.ms/new-console-template for more information
using Domain.Entities;
using Newtonsoft.Json;
using Persistence.Context;


var jsonData = File.ReadAllText("devices.json");
var tranferedData= JsonConvert.DeserializeObject<List<Devices>>(jsonData);
foreach(var item in tranferedData)
{
    var context = new AppDbContext();
    context.Devices.Add(item);   //veri tabanındaki() devices tablosuna ekle.
    context.SaveChanges(); // her kayıttan sonra otomatik olarak kaydetmeyi sağlar.

}


