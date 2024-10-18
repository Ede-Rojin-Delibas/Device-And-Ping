using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeviceDTO
    {
        public int PingID { get; set; }
        public string CihazAdi{ get; set; }
        public string CihazTuru { get; set; }
        public string Ip { get; set; }

        public string Koordinatlar { get; set; }
        public int RootID { get; set; }

    }
}
