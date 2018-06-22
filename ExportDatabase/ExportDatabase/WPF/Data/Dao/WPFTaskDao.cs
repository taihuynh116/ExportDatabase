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
    }
}
