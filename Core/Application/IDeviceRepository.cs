using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Mapping;
using Domain.Entities;


namespace Application
{
    public interface IDeviceRepository
    {
        BaseResponse<List<Devices>> GetTotalData();

        BaseResponse<List<Devices>> GetByName(string cAdi);

        BaseResponse<Devices> GetById(int pingid);

       
        
    }
}
