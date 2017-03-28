using System.Collections.Generic;
using ShopSite.Models;

namespace ShopSite.Services
{
    public class CategoryService : ICategoryService
    {
        static List<Category> _categories;

        public CategoryService()
        {
            _categories = new List<Category>
            {
                new Category { Description = "Desc1", Name = "Name1" },
                new Category { Description = "Desc2", Name = "Name2" },
                new Category { Description = "Desc3", Name = "Name3" },
                new Category { Description = "Desc4", Name = "Name4" }
            };
        }

        public IList<Category> GetAll()
        {
            return _categories;
        }

        public Category GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategoryParent(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Create(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
