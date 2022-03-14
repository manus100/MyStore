using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Infrastructure
{
    public class ShipperInfrastructure:Profile
    {
        public ShipperInfrastructure()
        {
            CreateMap<ShipperModel, Shipper>();
            CreateMap<Shipper, ShipperModel>();
        }
       
    }
}
