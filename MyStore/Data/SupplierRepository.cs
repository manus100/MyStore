using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier AddSupplier(Supplier newSupplier);
        bool Delete(Supplier supplierToDelete);
        bool Exists(int id);
        IEnumerable<Supplier> GetAll();
        Supplier GetByID(int id);
        Supplier Update(Supplier supplierToUpdate);
    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext context;

        public SupplierRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public Supplier GetByID(int id)
        {
            return context.Suppliers.Find(id);
        }

        public Supplier AddSupplier(Supplier newSupplier)
        {
            var addedSupplier = context.Suppliers.Add(newSupplier);
            context.SaveChanges();

            return addedSupplier.Entity;
        }

        public bool Exists(int id)
        {
            var exists = context.Suppliers.Count(x => x.Supplierid == id);
            return (exists == 1);
        }

        public Supplier Update(Supplier supplierToUpdate)
        {
            var updatedSupplier = context.Suppliers.Update(supplierToUpdate);
            context.SaveChanges();

            return updatedSupplier.Entity;
        }

        public bool Delete(Supplier supplierToDelete)
        {
            var deletedSupplier = context.Suppliers.Remove(supplierToDelete);
            context.SaveChanges();

            return deletedSupplier != null;
            }
        }
}
