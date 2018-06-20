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
    }
}
