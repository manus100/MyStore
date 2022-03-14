using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface IShipperRepository
    {
        Shipper Add(Shipper newShipper);
        bool Delete(Shipper shipper);
        bool Exists(int id);
        IEnumerable<Shipper> GetAll();
        Shipper GetByID(int id);
        bool HasOrders(int id);
        void Update(Shipper shipper);
    }
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreContext context;

        public ShipperRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Shipper> GetAll()
        {
            return context.Shippers.ToList();
        }

        public Shipper GetByID(int id)
        {
            return context.Shippers.FirstOrDefault(x=>x.Shipperid==id);
        }

        public Shipper Add(Shipper newShipper)
        {
            var addedShipper = context.Shippers.Add(newShipper);
            context.SaveChanges();

            return addedShipper.Entity;
        }

        public bool Exists(int id)
        {
            return (context.Shippers.Count(x => x.Shipperid == id) == 1);
        }

        public void Update(Shipper shipper)
        {
            context.Shippers.Update(shipper);
            context.SaveChanges();
        }

        public bool HasOrders(int id)
        {
            return (context.Orders.Count(x => x.Shipperid == id) > 0);
        }

        public bool Delete(Shipper shipper)
        {
            var deletedShipper = context.Shippers.Remove(shipper);
            context.SaveChanges();

            return deletedShipper != null;
        }

    }


}
