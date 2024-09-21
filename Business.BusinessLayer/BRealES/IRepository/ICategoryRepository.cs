using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
    }
}
