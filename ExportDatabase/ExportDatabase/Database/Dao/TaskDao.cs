using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExportDatabase.Database.Dao
{
    public static class TaskDao
    {
        static ProjectDbContext db;
        public static int GetId(int cateId, int paraNameId)
        {
            db = new ProjectDbContext();
            var paraBindings = db.ParameterBindings.Where(x => x.IDCategory == cateId && x.IDParameterName == paraNameId);
            if (paraBindings.Count() == 0) return -1;
            return paraBindings.First().IDTask;
        }
        public static int GetIndex(Task task)
        {
            db = new ProjectDbContext();
            return db.Tasks.ToList().FindIndex(x => x.ID == task.ID);
        }
        public static void Insert(string taskName)
        {
            if (taskName == null) return;
            if (taskName.Length == 0) return;
            db = new ProjectDbContext();
            var obj = db.Tasks.Where(x => x.Name == taskName);
            if (obj.Count() != 0) return;
            db.Tasks.Add(new Task { Name = taskName, CreateDate = DateTime.Now });
            db.SaveChanges();
        }
        public static Task GetTaskFromIndex(int index)
        {
            db = new ProjectDbContext();
            return db.Tasks.ToList()[index];
        }
        public static Task GetTask(int id)
        {
            db = new ProjectDbContext();
            var obj = db.Tasks.Where(x => x.ID == id);
            if (obj.Count() == 0) return null;
            return obj.First();
        }
        public static List<Task> GetTasks()
        {
            db = new ProjectDbContext();
            return db.Tasks.ToList();
        }
        public static void Remove(int id)
        {
            db = new ProjectDbContext();
            var obj = db.Tasks.Where(x => x.ID == id);
            if (obj.Count() == 0) return;
            var paramBindings = db.ParameterBindings.Where(x => x.IDTask == id);
            paramBindings.ToList().ForEach(x => ParameterBindingDao.Remove(x.ID, db));
            db.Tasks.RemoveRange(obj);
            db.SaveChanges();
        }
    }
}
