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
            string path = "C:\\Users\\Ede Rojin DEL�BA�\\.vscode\\ViStuCod\\ProjectDevices\\DEV�CES\\Presentation\\DesktopApp\\";
            var jsonData = File.ReadAllText($"{path}devices.json");
            var tranferedData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Devices>>(jsonData);
            listBox1.Items.Add($"{DateTime.Now} -- VER� TRANSFER ��LEM� BA�LADI. --");
            var context = new AppDbContext();

            var model = context.Devices.ToList();
            if (model != null)
            {
                listBox1.Items.Add($"Veri taban�nda {model.Count} adet veri vard�r. Silme i�lemi ba�lat�l�yor.");
                context.Devices.RemoveRange(model);
                context.SaveChanges();
                listBox1.Items.Add($"{model.Count} kadar veri silindi.");
            }

            foreach (var item in tranferedData)
            {
                context.Devices.Add(item);
                context.SaveChanges();
                listBox1.Items.Add($"{DateTime.Now} {item.cihazAdi} kay�t edildi.");
                //Thread.Sleep(2000);


            }
            listBox1.Items.Add($"{DateTime.Now} -- VER� TRANSFER ��LEM� B�TT�. --");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
