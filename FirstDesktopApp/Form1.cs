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
                //veri taban�nda veri olup olmad���n� kontrol ediyor.
                var dataControl = context.Devices.Any(x => x.id == item.id);
                if (dataControl)
                {
                    //veri varsa kullan�c�ya mesaj ver.
                    //Console.WriteLine($"Cihaz zaten mevcut: {item.cihazAdi}(ID: {item.id})");
                }
                else
                {
                    //veri yoksa ekle ve kaydet
                    context.Devices.Add(item);   //veri taban�ndaki() devices tablosuna ekle.
                    context.SaveChanges(); // her kay�ttan sonra otomatik olarak kaydetmeyi sa�lar.
                    //Console.WriteLine($"Cihaz ba�ar�yla eklendi: {item.cihazAdi}(ID: {item.id})");
                }

    
            }
           

        }
    }
}
