using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Database.Dao
{
    public static class CategoryDao
    {
        static ProjectDbContext db;
        public static List<Category> GetCategories()
        {
            db = new ProjectDbContext();
            return db.Categories.ToList();
        }
        public static int GetID(string name)
        {
            db = new ProjectDbContext();
            var obj = db.Categories.Where(x => x.Name == name);
            if (obj.Count() == 0) return -1;
            return obj.First().ID;
        }
    }
}
