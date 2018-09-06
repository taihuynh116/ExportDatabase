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
            var paraNameIds = db.ParameterBindings.Where(x => x.IDCategory == idCate).Select(x=> x.IDParameterName);
            var obj = db.ParameterNames.Where(x => (paraNameIds.Contains(x.ID)==isUsed));

            List<string> names = obj.Select(x => x.Name).ToList();

            if (obj.Count() == 0)
                return new List<ParameterName>();
            return obj.ToList();
        }
        public static void Insert(string paraName, string description)
        {
            if (paraName == null) return;
            if (paraName.Length == 0) return;
            db = new ProjectDbContext();
            var obj = db.ParameterNames.Where(x => x.Name == paraName);
            if (obj.Count() != 0) return;
            db.ParameterNames.Add(new ParameterName { Name = paraName, Description= description, CreateDate = DateTime.Now });
            db.SaveChanges();
        }
        public static void Remove(int id)
        {
            db = new ProjectDbContext();
            var obj = db.ParameterNames.Where(x => x.ID == id);
            if (obj.Count() == 0) return;
            var paramBindings = db.ParameterBindings.Where(x => x.IDParameterName == id);
            paramBindings.ToList().ForEach(x => ParameterBindingDao.Remove(x.ID, db));
            db.ParameterNames.RemoveRange(obj);
            db.SaveChanges();
        }
    }
}
