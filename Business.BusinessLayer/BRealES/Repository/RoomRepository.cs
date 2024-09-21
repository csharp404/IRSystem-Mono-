using Business.BusinessLayer.BRealES.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _db;



        public RoomRepository(IMapper map, MyDbContext db)
        {
            _mapper = map;
            this._db = db;
        }
        public string Create(CreateVm room, string realId)
        {
            Room rom = _mapper.Map<Room>(room);
            rom.RealEsId = realId;
            rom.RoomId = Guid.NewGuid().ToString();
            _db.Rooms.Add(rom);
            _db.SaveChanges();
            return rom.RoomId;

        }

        public Room GetRoomByRealId(string realId)
        {
            var room = _db.Rooms.Where(x => x.RealEsId == realId).FirstOrDefault();
            return room;
        }

        public bool Update(Room room)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string realId)
        {
            var data = GetRoomByRealId(realId);
            _db.Rooms.Remove(data);
            _db.SaveChanges();
            return true;
        }
    }
}
