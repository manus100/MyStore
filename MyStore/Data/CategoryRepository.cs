using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        Category Add(Category newCategory);
        bool Delete(Category category);
        bool Exists(int id);
        IEnumerable<Category> GetAll();
        Category GetByID(int id);
        bool HasProducts(int id);
        Category Update(Category category);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext context;

        public CategoryRepository(StoreContext context)
        {
            this.context = context;
        }


        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            return context.Categories.FirstOrDefault(x=>x.Categoryid==id);
        }

        public Category Add(Category newCategory)
        {
            var addedCategory=context.Categories.Add(newCategory);
            context.SaveChanges();

            return addedCategory.Entity;
        }

        public Category Update(Category category)
        {
            var updatedCategory = context.Categories.Update(category);
            context.SaveChanges();

            return updatedCategory.Entity;
        }

        public bool Exists(int id)
        {
            var exists = context.Categories.Count(x => x.Categoryid == id);
            return (exists == 1);
        }

        public bool Delete(Category category)
        {
            var deletedCategory = context.Categories.Remove(category);
            context.SaveChanges();

            return deletedCategory != null;
        }

        public bool HasProducts(int id)
        {
            return context.Products.Count(x => x.Categoryid == id)>0;
        }

    }






}
