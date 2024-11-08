﻿using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopServiceRepository
    {
        Task Create(CarWorkshopService carWorksopService);
        Task<IEnumerable<CarWorkshopService>> GetAllByEncodedname(string encoedName);
    }
}
