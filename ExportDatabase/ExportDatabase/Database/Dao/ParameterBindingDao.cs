using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Database.Dao
{
    public static class ParameterBindingDao
    {
        static ProjectDbContext db;
        public static void Insert(int idTask, int idCate, int idParamName)
        {
            db = new ProjectDbContext();
            var obj = db.ParameterBindings.Where(x => x.IDTask == idTask && x.IDCategory == idCate && x.IDParameterName == idParamName);
            if (obj.Count() != 0) return;
            var res = new ParameterBinding()
            {
                CreateDate = DateTime.Now,
                IDTask = idTask,
                IDCategory = idCate,
                IDParameterName = idParamName
            };
            db.ParameterBindings.Add(res);
            db.SaveChanges();
        }
        public static void UpdateNewTask(int idTask, int idCate, int idParamName)
        {
            db = new ProjectDbContext();
            var obj = db.ParameterBindings.Where(x => x.IDCategory == idCate && x.IDParameterName == idParamName);
            if (obj.Count() == 0) return;
            else
            {
                var res = obj.First();
                if (res.IDTask == idTask) return;
                res.IDTask = idTask;
            }
            db.SaveChanges();
        }
        public static void Remove(int idCate, int idParamName)
        {
            db = new ProjectDbContext();
            var obj = db.ParameterBindings.Where(x => x.IDCategory == idCate && x.IDParameterName == idParamName);
            if (obj.Count() == 0) return;
            obj.ToList().ForEach(x => Remove(x.ID));
            db.SaveChanges();
        }
        public static void Remove(int id, ProjectDbContext db = null)
        {
            if (db== null) db = new ProjectDbContext();
            var obj = db.ParameterBindings.Where(x => x.ID== id);
            if (obj.Count() == 0) return;
            obj.ToList().ForEach(x => ValueBindingDao.RemoveWithParameterBinding(x.ID, db));
            db.ParameterBindings.RemoveRange(obj);
            db.SaveChanges();
        }
    }
}
