using Business.BusinessLayer.BRealES.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataLayer;
using Data.EntityModels;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyDbContext _db;

        public CategoryRepository(MyDbContext db)
        {
            this._db = db;
        }
        public List<Category> GetAll()
        {
            var types = _db.Categories.ToList();
            return types;
        }
    }
}
