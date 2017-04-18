using System.Collections.Generic;
using System.Linq;

namespace ShopSite.Services
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PagedList(IQueryable<T> list, int pageIndex, int pageSize)
        {
            TotalCount = list.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(list.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        public PagedList(IList<T> list, int pageIndex, int pageSize)
        {
            TotalCount = list.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(list.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        public bool HasPreviousPage
        {
            get { return PageIndex > 0; }
        }

        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
