﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPingServices
    {
        public Task<List<Ping>> GetAllPings(); //Task methodu senkronu asenkrona çevirmeye yarar.
        


    }

}
