using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Application.Mapping;

namespace Application
{
    public interface IPingRepo
    {
        List<PingDTO> GetAllPings();
        PingDTO GetByStatus(string status);
        
    }
    
}
