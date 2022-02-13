using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetByID(int id);
    }
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }

        public Supplier GetByID(int id)
        {
            return supplierRepository.GetByID(id);
        }
    }
}
