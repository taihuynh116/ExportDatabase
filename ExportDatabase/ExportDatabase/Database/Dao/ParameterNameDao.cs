using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Database.Dao
{
    public static class ParameterNameDao
    {
        static ProjectDbContext db;
        public static List<ParameterName> GetParameterNames(int idCate, bool isUsed = true)
        {
            db = new ProjectDbContext();
            var paraNameIds = db.ParameterBindings.Where(x => (x.IDCategory == idCate) == isUsed).Select(x=> x.IDParameterName);
            var obj = db.ParameterNames.Where(x => paraNameIds.Contains(x.ID));
            if (obj.Count() == 0)
                return new List<ParameterName>();
            return obj.ToList();
        }
    }
}
