using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface IProducService   //aduce date din bd si le prelucreaza dc e cazul
    {
        IEnumerable<Product> GetAllProducts();
        Product GetByID(int id);
    }
    public class ProductService :IProducService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)  //dependency inversion - nu depind de implementarea clasei ProductRepository, folosesc interfata
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public Product GetByID(int id)
        {
            return productRepository.GetByID(id);
        }
    }


}
