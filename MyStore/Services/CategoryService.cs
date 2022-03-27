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
    public interface ICategoryService
    {
        CategoryModel Add(CategoryModel newCategory);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<CategoryModel> GetAll();
        CategoryModel GetByID(int id);
        bool HasProducts(int id);
        CategoryModel Update(CategoryModel category);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            return mapper.Map<IEnumerable<CategoryModel>>(categoryRepository.GetAll());
        }

        public CategoryModel GetByID(int id)
        {
            return mapper.Map<CategoryModel>(categoryRepository.GetByID(id));
        }

        public CategoryModel Add(CategoryModel newCategory)
        {
            Category addedCategory = categoryRepository.Add(mapper.Map<Category>(newCategory));

            return mapper.Map<CategoryModel>(addedCategory);
        }

        public CategoryModel Update(CategoryModel category)
        {
            var updatedCategory= categoryRepository.Update(mapper.Map<Category>(category));

            return mapper.Map<CategoryModel>(updatedCategory); 
        }

        public bool Exists(int id)
        {
            return categoryRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            Category categoryToDelete = categoryRepository.GetByID(id);

            if (categoryToDelete == null)
                return false;

            return categoryRepository.Delete(categoryToDelete);
        }

        public bool HasProducts(int id)
        {
            return categoryRepository.HasProducts(id);
        }
    }

   
}
