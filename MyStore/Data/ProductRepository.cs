using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        //data access code
        //metode care se ocupa de CRUD + data retrieval

        IEnumerable<Product> GetAll();
        Product GetByID(int id);
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
    }
}
