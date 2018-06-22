using ExportDatabase.Database.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.WPF
{
    public class WPFCategoryDao
    {
        public static void GetCategories()
        {
            WPFDbContext.Instance.Categories.Clear();
            CategoryDao.GetCategories().ForEach(x => WPFDbContext.Instance.Categories.Add(x));
        }
        public static void SaveTempSelectedIndex()
        {
            WPFDbContext.Instance.TempSelectedCategoryIndex = CategoryDao.GetIndex(WPFDbContext.Instance.SelectedCategory);
        }
        public static void GetCategoryFromTempSelectedIndex()
        {
            while (WPFDbContext.Instance.TempSelectedCategoryIndex > WPFDbContext.Instance.Categories.Count - 1)
            {
                WPFDbContext.Instance.TempSelectedCategoryIndex--;
            }
            int index = WPFDbContext.Instance.TempSelectedCategoryIndex;
            WPFDbContext.Instance.SelectedCategory = CategoryDao.GetCategoryFromIndex(WPFDbContext.Instance.TempSelectedCategoryIndex);
            var obj = WPFDbContext.Instance.SelectedCategory;
        }
    }
}
