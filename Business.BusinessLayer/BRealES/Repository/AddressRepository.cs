using Business.BusinessLayer.BRealES.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;
using AutoMapper;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _db;



        public AddressRepository(IMapper map, MyDbContext db)
        {
            _mapper = map;
            this._db = db;
        }
        public string Create(CreateVm createVm, string realId)
        {
            Address address = _mapper.Map<Address>(createVm);
            address.AddressId = Guid.NewGuid().ToString();
            address.RealEsid = realId;
            var addressId = Guid.NewGuid().ToString();

            _db.Addresses.AddAsync(address);
            _db.SaveChanges();
            return address.AddressId;
        }

        public Address GetAddressByRealEsId(string realid)
        {
            var address = _db.Addresses.Where(x => x.RealEsid == realid).FirstOrDefault();
            return address;
        }



        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string realid)
        {
            var data = GetAddressByRealEsId(realid);
            _db.Addresses.Remove(data);
            _db.SaveChanges();
            return true;

        }
    }
}
