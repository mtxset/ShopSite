﻿using System.Collections.Generic;

namespace ShopSite.ViewModels.Category
{
    public class CategoryMenuItem
    {
        public CategoryMenuItem()
        {
            ChildItems = new List<CategoryMenuItem>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public CategoryMenuItem Parent { get; set; }

        public IList<CategoryMenuItem> ChildItems { get; set; }

        public void AddChildItem(CategoryMenuItem childItem)
        {
            childItem.Parent = this;
            ChildItems.Add(childItem);
        }
    }
}
