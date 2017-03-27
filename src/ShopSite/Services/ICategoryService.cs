using ShopSite.Models;
using System.Collections.Generic;
using ShopSite.ViewModels;

namespace ShopSite.Services
{
    public interface ICategoryService
    {
        IList<Category> GetAll();

        Category GetCategory(int id);
        Category GetCategoryParent(int id);

        int Commit();

        void Create(Category category);
        void Update(Category category);
        void Remove(Category category);
    }
}
