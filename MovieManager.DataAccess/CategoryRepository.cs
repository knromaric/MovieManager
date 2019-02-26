using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieManager.DataAccess
{
    public class CategoryRepository : BaseRepository
    {
        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetCategory(Guid categoryId)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.Name.ToLower().Contains(name.ToLower()));
            return category;
        }


        public void AddCategory(Category newCategory)
        {
            dbContext.Categories.Add(newCategory);
            dbContext.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
                dbContext.Categories.Remove(category);

            dbContext.SaveChanges();
        }

        public void UpdateCategory(Category updatedCategory)
        {
            var categoryInDb = dbContext.Categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
            if (categoryInDb != null)
            {
                categoryInDb.Name = updatedCategory.Name;
                dbContext.SaveChanges();
            }
        }
    }
}
