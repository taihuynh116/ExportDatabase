using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Database.Dao
{
    public static class ValueBindingDao
    {
        static ProjectDbContext db;
        public static void RemoveWithParameterBinding(int idParamBinding, ProjectDbContext db= null)
        {
            if (db== null) db = new ProjectDbContext();
            var obj = db.ValueBindings.Where(x => x.IDParameterBinding == idParamBinding);
            if (obj.Count() == 0) return;
            obj.ToList().ForEach(x => ValueDao.RemoveWithValueBinding(x.ID, db));
            db.ValueBindings.RemoveRange(obj);
            db.SaveChanges();
        }
    }
}
