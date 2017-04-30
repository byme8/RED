using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REDBlend.Assets.UI.Tools;
using REDBlend.Assets.UI.ViewModels.Core;

namespace REDBlend.Assets.Resources.UI.ViewModels
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
            this.Select = new Command(_ => Navigator.Instance.Navigate(Routes.Levels, this));
        }

        public Command Select
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class CategoriesViewModel : ViewModel
    {
        public CategoriesViewModel()
        {
            this.Categories = new[]
            {
                new Category("Test1"),
                new Category("Test2"),
                new Category("Test3")
            };
        }

        public Category[] Categories
        {
            get;
        }
    }
}
