using DesktopApp.Context;
using Domain.Entities;
using System;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\Ede Rojin DELÝBAÞ\\.vscode\\ViStuCod\\ProjectDevices\\DEVÝCES\\Presentation\\DesktopApp\\";
            var jsonData = File.ReadAllText($"{path}devices.json");
            var tranferedData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Devices>>(jsonData);
            listBox1.Items.Add($"{DateTime.Now} -- VERÝ TRANSFER ÝÞLEMÝ BAÞLADI. --");
            var context = new AppDbContext();

            var model = context.Devices.ToList();
            if (model != null)
            {
                listBox1.Items.Add($"Veri tabanýnda {model.Count} adet veri vardýr. Silme iþlemi baþlatýlýyor.");
                context.Devices.RemoveRange(model);
                context.SaveChanges();
                listBox1.Items.Add($"{model.Count} kadar veri silindi.");
            }

            foreach (var item in tranferedData)
            {
                context.Devices.Add(item);
                context.SaveChanges();
                listBox1.Items.Add($"{DateTime.Now} {item.cihazAdi} kayýt edildi.");
                //Thread.Sleep(2000);


            }
            listBox1.Items.Add($"{DateTime.Now} -- VERÝ TRANSFER ÝÞLEMÝ BÝTTÝ. --");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
