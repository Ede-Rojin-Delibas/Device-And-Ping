using System.DirectoryServices.ActiveDirectory;
using System;
using Newtonsoft.Json;
using Domain.Entities;
using Infrastructure;
using Persistence.Context;


namespace FirstDesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var jsonData = File.ReadAllText("devices.json");
            var tranferedData = JsonConvert.DeserializeObject<List<Devices>>(jsonData);
            var context = new AppDbContext();
            foreach (var item in tranferedData)
            {
                //veri tabanýnda veri olup olmadýðýný kontrol ediyor.
                var dataControl = context.Devices.Any(x => x.id == item.id);
                if (dataControl)
                {
                    //veri varsa kullanýcýya mesaj ver.
                    //Console.WriteLine($"Cihaz zaten mevcut: {item.cihazAdi}(ID: {item.id})");
                }
                else
                {
                    //veri yoksa ekle ve kaydet
                    context.Devices.Add(item);   //veri tabanýndaki() devices tablosuna ekle.
                    context.SaveChanges(); // her kayýttan sonra otomatik olarak kaydetmeyi saðlar.
                    //Console.WriteLine($"Cihaz baþarýyla eklendi: {item.cihazAdi}(ID: {item.id})");
                }

    
            }
           

        }
    }
}
