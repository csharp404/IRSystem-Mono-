using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.IRepository
{
    public interface IRealESRepository
    {
        public List<RealEs> GetByUserId(string userId);
        public RealEs GetById(string id);
        public IQueryable<RealEs> GetAll();
        public bool Create(CreateVm createVm);
        public bool Update(CreateVm updateVm);
        public bool Delete(string id);
        public List<RealEs> Filter(IQueryable<RealEs> rels, FilterVm fill);
        public List<CardVm> GetCardsForIndexPage(List<RealEs> realEss);
        public List<FavVm> GetMyPropertiesByCurrentUser();
        public RealEs GetRealEsWithComment(string id);
        public void IncrementView(string id);
        public DetailsVm GetDetails(string id);
        public Task<CreateVm> UpdateGet(string id);
        
    }
}
