using System;
using System.Collections.Generic;
using System.Linq;
using ShopSite.Data;
using ShopSite.Models;

namespace ShopSite.Services.SQL
{
    public class SqlCategoryService : ICategoryService
    {
        private ShopSiteDbContext _context;

        public SqlCategoryService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public IList<Category> GetAll()
        {
            return _context.CategoryDbContext.ToList();
        }

        public IQueryable<Category> GetListByIds(IList<int> ids)
        {
            return _context.CategoryDbContext.Where(r => ids.Contains(r.Id));
        }

        public Category GetCategory(int id)
        {
            return _context.CategoryDbContext.FirstOrDefault(r => r.Id == id);
        }

        public Category GetCategoryParent(int id)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
           return _context.SaveChanges();
        }

        public void Create(Category category)
        {
            _context.Add(category);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category category)
        {
            _context.Remove(category);
        }
    }
}
