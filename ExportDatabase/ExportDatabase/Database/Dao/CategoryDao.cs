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
        public static int GetIndex(Category cate)
        {
            db = new ProjectDbContext();
            return db.Categories.ToList().FindIndex(x => x.ID == cate.ID);
        }
        public static Category GetCategoryFromIndex(int index)
        {
            db = new ProjectDbContext();
            return db.Categories.ToList()[index];
        }
        public static int GetID(string name)
        {
            db = new ProjectDbContext();
            var obj = db.Categories.Where(x => x.Name == name);
            if (obj.Count() == 0) return -1;
            return obj.First().ID;
        }
        public static void Insert(string cateName)
        {
            if (cateName == null) return;
            if (cateName.Length == 0) return;
            db = new ProjectDbContext();
            var obj = db.Categories.Where(x => x.Name == cateName);
            if (obj.Count() != 0) return;
            db.Categories.Add(new Category { Name = cateName, CreateDate = DateTime.Now });
            db.SaveChanges();
        }
        public static void Remove(int id)
        {
            db = new ProjectDbContext();
            var obj = db.Categories.Where(x => x.ID == id);
            if (obj.Count() == 0) return;
            var paramBindings = db.ParameterBindings.Where(x => x.IDCategory == id);
            paramBindings.ToList().ForEach(x => ParameterBindingDao.Remove(x.ID, db));
            db.Categories.RemoveRange(obj);
            db.SaveChanges();
        }
    }
}
