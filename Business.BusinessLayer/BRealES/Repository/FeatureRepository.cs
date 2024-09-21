using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessLayer.BRealES.IRepository;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly MyDbContext _db;

        public FeatureRepository(MyDbContext db)
        {
            this._db = db;
        }
        public bool Create(List<SelectionFeatures> features, string realId)
        {
            var feature = features
                .Where(x => x.IsSelected == true)
                .Select(x => x.Id)
                .ToList();

            List<RealEsFeature> r = new List<RealEsFeature>();
            foreach (var fg in feature)
            {
                r.Add(new RealEsFeature { FeatureId = fg, RealEsid = realId });

            }
            _db.RealEsFeatures.AddRange(r);
            _db.SaveChanges();
            return true;
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
