using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Database.Dao
{
    public static class ValueDao
    {
        static ProjectDbContext db;
        public static void Remove(int id)
        {
            db = new ProjectDbContext();
            var obj = db.Values.Where(x => x.ID == id);
            if (obj.Count() == 0) return;
            db.Values.RemoveRange(obj);
            db.SaveChanges();
        }
        public static void RemoveWithValueBinding(int idValueBinding, ProjectDbContext db= null)
        {
            if (db== null) db = new ProjectDbContext();
            var obj = db.Values.Where(x => x.IDValueBinding == idValueBinding);
            if (obj.Count() == 0) return;
            db.Values.RemoveRange(obj);
            db.SaveChanges();
        }
    }
}
