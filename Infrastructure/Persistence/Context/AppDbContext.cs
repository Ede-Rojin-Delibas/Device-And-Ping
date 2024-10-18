using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{

    public class AppDbContext : DbContext       //import etme ,inherit 
    {
        //internal readonly IEnumerable<object> DeviceDTO;

        public DbSet<Devices> Devices { get; set; } //veri tabanındaki tabloyu bulup eşleştirme 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BOTAS_DB;Trusted_Connection=True; Encrypt = False; TrustServerCertificate = False;", null); //connection string trusted connection true idi false yapıldı bağlantı güvenli değil 

        }

    }
}
