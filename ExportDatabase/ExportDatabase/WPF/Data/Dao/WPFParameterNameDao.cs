using ExportDatabase.Database.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.WPF.Data.Dao
{
    public static class WPFParameterNameDao
    {
        public static void Update()
        {
            WPFDbContext.Instance.UsedParameters.Clear();
            ParameterNameDao.GetParameterNames(WPFDbContext.Instance.SelectedCategory.ID).ForEach(x => WPFDbContext.Instance.UsedParameters.Add(x));

            WPFDbContext.Instance.UnusedParameters.Clear();
            ParameterNameDao.GetParameterNames(WPFDbContext.Instance.SelectedCategory.ID, false).ForEach(x => WPFDbContext.Instance.UnusedParameters.Add(x));
        }
    }
}
