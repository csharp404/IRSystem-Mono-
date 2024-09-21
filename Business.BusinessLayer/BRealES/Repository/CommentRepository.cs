using Business.BusinessLayer.BRealES.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Data.DataLayer;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Business.BusinessLayer.BRealES.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _db;
        public CommentRepository(IMapper mapper, MyDbContext db)
        {
            this._mapper = mapper;
            this._db = db;
        }


        public bool AddComment(DetailsVm comm)
        {
            Comments commnt = _mapper.Map<Comments>(comm);
            _db.Comments.Add(commnt);
            _db.SaveChanges();
            return true;
        }
    }
}
