using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingEntoDTO
    {
        public List<DeviceDTO> GetAllDevices(List<Devices> device)
        {
            List<DeviceDTO> devicedto = new List<DeviceDTO>();
            foreach (var item in device)
            {
                DeviceDTO deviceDto = new DeviceDTO();
                deviceDto.PingID = item.pingid;
                deviceDto.CihazAdi = item.cihazAdi;
                deviceDto.CihazTuru = item.cihazTuru;
                deviceDto.Ip = item.ip;
                deviceDto.Koordinatlar = item.enlem;
                deviceDto.Koordinatlar = item.boylam;
                deviceDto.RootID = item.rId;

                devicedto.Add(deviceDto);

            }
            return devicedto;


        }
        public DeviceDTO Single(Devices varlik)
        { 
            DeviceDTO dto = new DeviceDTO();
            dto.PingID = varlik.pingid;
            dto.CihazAdi = varlik.cihazAdi;
            dto.CihazTuru = varlik.cihazTuru;
            dto.Ip = varlik.ip;
            dto.Koordinatlar = varlik.enlem;
            dto.Koordinatlar = varlik.boylam;
            dto.RootID = varlik.rId;

            return dto;

        }
        public List<DeviceDTO> GetDeviceList(List<Devices> devicesdtoL)
        {
            List<DeviceDTO> devicedto = new List<DeviceDTO>();
            foreach (var item in devicesdtoL)
            {
                DeviceDTO deviceDto = new DeviceDTO();
                deviceDto.PingID = item.pingid;
                deviceDto.CihazAdi = item.cihazAdi;
                deviceDto.CihazTuru = item.cihazTuru;
                deviceDto.Ip = item.ip;
                deviceDto.Koordinatlar = item.enlem;
                deviceDto.Koordinatlar=item.boylam;
                deviceDto.RootID = item.rId;

                devicedto.Add(deviceDto);

            }
            return devicedto;
        }
        public DeviceDTO GetById(Devices dev)
        {
            DeviceDTO dto = new DeviceDTO();
            dto.PingID = dev.pingid;
            dto.CihazAdi = dev.cihazAdi;
            dto.CihazTuru = dev.cihazTuru;
            dto.Koordinatlar = dev.enlem;
            dto.Koordinatlar = dev.boylam;
            dto.RootID = dev.rId;
            return dto;

        }
 
       
    }
}
