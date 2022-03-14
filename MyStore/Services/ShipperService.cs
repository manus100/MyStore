using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Service
{
    public interface IShipperService
    {
        ShipperModel Add(ShipperModel newShipper);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<ShipperModel> GetAll();
        ShipperModel GetByID(int id);
        bool HasOrders(int id);
        void Update(ShipperModel shipper);
    }
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository shipperRepository;
        private readonly IMapper mapper;

        public ShipperService(IShipperRepository shipperRepository, IMapper mapper)
        {
            this.shipperRepository = shipperRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ShipperModel> GetAll()
        {
            return mapper.Map<IEnumerable<ShipperModel>>(shipperRepository.GetAll());
        }

        public ShipperModel GetByID(int id)
        {
            return mapper.Map<ShipperModel>(shipperRepository.GetByID(id));
        }

        public ShipperModel Add(ShipperModel newShipper)
        {
            Shipper addedShipper = shipperRepository.Add(mapper.Map<Shipper>(newShipper));
            return mapper.Map<ShipperModel>(addedShipper);
        }

        public bool Exists(int id)
        {
            return shipperRepository.Exists(id);
        }

        public void Update(ShipperModel shipper)
        {
            shipperRepository.Update(mapper.Map<Shipper>(shipper));
        }

        public bool HasOrders(int id)
        {
            return shipperRepository.HasOrders(id);
        }

        public bool Delete(int id)
        {
            var itemToDelete = shipperRepository.GetByID(id);

            if (itemToDelete == null)
                return false;

            return shipperRepository.Delete(itemToDelete);
        }

    }


}
