using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        SupplierModel Add(SupplierModel newSupplier);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<SupplierModel> GetAll();
        SupplierModel GetByID(int id);
        SupplierModel Update(SupplierModel model);
    }
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierModel> GetAll()
        {
            var allSuppliers = supplierRepository.GetAll().ToList();
            return mapper.Map<IEnumerable<SupplierModel>>(allSuppliers); 
        }

        public SupplierModel GetByID(int id)
        {
            return mapper.Map<SupplierModel>(supplierRepository.GetByID(id));
        }

        public SupplierModel Add(SupplierModel newSupplier)
        {
            Supplier supplierToAdd = mapper.Map<Supplier>(newSupplier);
            var addedSupplier = supplierRepository.AddSupplier(supplierToAdd);

            return mapper.Map<SupplierModel>(addedSupplier);

            //Supplier supplierToAdd = new Supplier();  // = mapper.Map(newSupplier, supplierToAdd);

            //return mapper.Map(supplierRepository.AddSupplier(mapper.Map(newSupplier, supplierToAdd)), newSupplier);

        }

        public bool Exists(int id)
        {
            return supplierRepository.Exists(id);
        }

        public SupplierModel Update(SupplierModel model)
        {
            var updatedSupplier = supplierRepository.Update(mapper.Map<Supplier>(model));

            return mapper.Map<SupplierModel>(updatedSupplier);
        }

        public bool Delete(int id)
        {
            var itemToDelete = supplierRepository.GetByID(id);
            if (itemToDelete != null)
                return supplierRepository.Delete(itemToDelete);
            else
                return false;

        }
    }
  
  
}
