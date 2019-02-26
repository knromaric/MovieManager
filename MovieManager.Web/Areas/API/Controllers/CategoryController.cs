using MovieManager.DataContracts;
using MovieManager.Management;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MovieManager.Web.Areas.API.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private CategoryManagement _categoryManagement = new CategoryManagement();

        [HttpGet]
        [Route("getallcategories")]
        public List<CategoryDTO> GetCategories()
        {
            return _categoryManagement.GetCategories();
        }

        [HttpGet]
        [Route("{categoryId}")]
        public CategoryDTO GetCategory(Guid categoryId)
        {
            return _categoryManagement.GetCategory(categoryId);
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public void DeleteCategory(Guid categoryId)
        {
            _categoryManagement.DeleteCategory(categoryId);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateCategory([FromBody] CategoryDTO category, Guid id)
        {
            _categoryManagement.AddOrUpdateCategory(category);
        }

        [HttpPost]
        [Route("{id}")]
        public void AddCategory([FromBody] CategoryDTO category, Guid id)
        {
            _categoryManagement.AddOrUpdateCategory(category);
        }


    }
}
