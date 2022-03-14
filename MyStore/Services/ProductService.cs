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
    public interface IProducService   //aduce date din bd si le prelucreaza dc e cazul
    {
        ProductModel AddProduct(ProductModel newProduct);
        bool CheckPrice(ProductModel model);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetByID(int id);
        bool HasOrders(int id);
        ProductModel UpdateProduct(ProductModel model);
    }
    public class ProductService :IProducService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)  //dependency inversion - nu depind de implementarea clasei ProductRepository, folosesc interfata
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            //take domain objects
            var allProducts = productRepository.GetAll().ToList();//List<Product>
                                                                  //transform domain objects from List<Product> -> List<ProductModel>
                                                                  //var productModels = new List<ProductModel>();

            var productModels= mapper.Map<IEnumerable<ProductModel>>(allProducts);

            //for (int i = 0; i < allProducts.Count(); i++)
            //{
            //    var productModel = new ProductModel();
            //    productModel.Categoryid = allProducts[i].Categoryid;
            //    productModel.Productid = allProducts[i].Productid;
            //    productModel.Productname = allProducts[i].Productname;
            //    productModel.Unitprice = allProducts[i].Unitprice;
            //    productModel.Discontinued = allProducts[i].Discontinued;
            //}

            //1 la 1
            //var source = new Product();
            //var destination = new ProductModel();

            //destination.Categoryid = source.Categoryid;
            //destination.Discontinued = source.Discontinued;
            //destination.Productid = source.Productid;
            //destination.Productname = source.Productname;
            //destination.Supplierid = source.Supplierid;
            //destination.Unitprice = source.Unitprice;


            return productModels;
        }

        public ProductModel GetByID(int id)
        {
            return mapper.Map<ProductModel>(productRepository.GetByID(id));
        }

        public ProductModel AddProduct(ProductModel newProduct)
        {
            //ProductModel -> Product, in bd tb sa ajunga Product

            //assuming is valid -> transform to Product

            Product productToAdd = mapper.Map<Product>(newProduct);
            var addedProduct = productRepository.Add(productToAdd);

            newProduct = mapper.Map<ProductModel>(addedProduct);

            return newProduct;
        }

        public ProductModel UpdateProduct(ProductModel model)
        {
            Product productToUpdate = mapper.Map<Product>(model);
            var updatedProduct = productRepository.Update(productToUpdate);
            return mapper.Map<ProductModel>(updatedProduct);
        }

        public bool Exists(int id)
        {
            return productRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            var itemToDelete = productRepository.GetByID(id);

            if (itemToDelete == null)
            {
                //eroare
                return false;
            }
            return productRepository.Delete(itemToDelete);
        }

        public bool CheckPrice(ProductModel model)
        {
            if (model.Supplierid == 1 && model.Unitprice < 50)
            {
                return false;
            }

            return true;
        }

        public bool HasOrders(int id)
        {
            return productRepository.HasOrders(id);
        }
    }


}
