using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface IRoomRepository
    {
        public string Create(CreateVm room, string realId);
        public Room GetRoomByRealId(string realId);
        public bool Update(Room room);
        public bool Delete(string realId);

    }
}
