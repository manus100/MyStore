using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Infrastructure
{
    public class SupplierProfiles : AutoMapper.Profile
    {
        public SupplierProfiles()
        {
            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierModel, Supplier>();
        }
    }
}
