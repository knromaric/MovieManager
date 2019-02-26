using MovieManager.DataAccess;
using MovieManager.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Management
{
    public class CategoryManagement
    {
        private CategoryRepository _repo = new CategoryRepository();

        public List<CategoryDTO> GetCategories()
        {
            var categories = _repo.GetCategories().Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return categories;
        }

        public CategoryDTO GetCategory(Guid categoryId)
        {
            var category = _repo.GetCategory(categoryId);
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public void DeleteCategory(Guid categoryId)
        {
            _repo.DeleteCategory(categoryId);
        }

        public void AddOrUpdateCategory(CategoryDTO newCategory)
        {
            Category category = new Category
            {
                Id = newCategory.Id == Guid.Empty ? Guid.NewGuid() : newCategory.Id,
                Name = newCategory.Name
            };

            if(category.Id == Guid.Empty)
            {
                _repo.AddCategory(category);
            }
            else
            {
                _repo.UpdateCategory(category);
            }
        }
    }
}
