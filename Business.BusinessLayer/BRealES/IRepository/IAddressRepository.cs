using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface IAddressRepository
    {
        public string Create(CreateVm createVm, string realId);
        public Address GetAddressByRealEsId(string realid);
        public bool Update();
        public bool Delete(string realid);
    }
}
