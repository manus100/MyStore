using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        Product Add(Product newProduct);
        bool Delete(Product productToDelete);
        bool Exists(int id);

        //data access code
        //metode care se ocupa de CRUD + data retrieval

        IEnumerable<Product> GetAll();
        Product GetByID(int id);
        bool HasOrders(int id);
        Product Update(Product productToUpdate);
        // IEnumerable GetProductCategory();
    }
    public class ProductRepository : IProductRepository       //clasa care se ocupa cu accesul la date
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
          
        }

        public IEnumerable<Product> FindByCategory(int categoryID)
        {
            return context.Products.Where(x => x.Categoryid == categoryID).ToList();

            //Where returneaza un IQueryable care te lasa sa filtrezi un sir de date pana cand fac ToList(); cd fac ToList /Select codul ajunge la bd
        }

        public Product GetByID(int id)
        {
            //return context.Products.Where(x => x.Productid == id);  //nu merge
           return context.Products.Find(id);
          
        }

        public bool Exists(int id)
        {
            var exists = context.Products.Count(x => x.Productid == id);
            return exists==1;
        }

        //public  IEnumerable GetProductCategory()
        //{

        //    var data = context.Products
        //    .Join(
        //     context.Categories,
        //     product => product.Categoryid,
        //     category => category.Categoryid,
        //     (product, category) => new
        //     {
        //         productID = product.Productid,
        //         productName = product.Productname,
        //         CategoryName = category.Categoryname
        //     }
        // ).ToList();

        //    return data;
        //}

        public Product Add(Product newProduct)
        {
            var adddedProduct = context.Products.Add(newProduct);
            context.SaveChanges();
            return adddedProduct.Entity;
        }

       public Product Update(Product productToUpdate)
        {
           var updatedProduct= context.Products.Update(productToUpdate);
            context.SaveChanges();
            return updatedProduct.Entity;
        }

        public bool Delete(Product  productToDelete)
        {
           var deletedItem = context.Products.Remove(productToDelete);
            context.SaveChanges();

            return deletedItem != null;
        }

        public bool HasOrders(int id)
        {
            var exists = context.OrderDetails.Count(x => x.Productid == id);
            return exists > 0;
        }
    }
}
