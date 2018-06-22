using ExportDatabase.Database.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.WPF
{
    public class WPFTaskDao
    {
        public static void GetTasks()
        {
            WPFDbContext.Instance.Tasks.Clear();
            TaskDao.GetTasks().ForEach(x => WPFDbContext.Instance.Tasks.Add(x));
        }
        public static void SaveTempSelectedIndex()
        {
            
            WPFDbContext.Instance.TempSelectedTaskIndex = TaskDao.GetIndex(WPFDbContext.Instance.SelectedUnusedTask);
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
