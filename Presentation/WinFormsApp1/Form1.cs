using Domain.Entities;
using Newtonsoft.Json;
using Persistence.Context;
using System;

namespace WinFormsApp1
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
        }
    }
}
