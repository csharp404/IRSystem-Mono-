using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Business.BusinessLayer.BCommon.IRepository;
using Business.BusinessLayer.BRealES.IRepository;
using Business.BusinessLayer.BUser.IRepository;
using Data.DataLayer;
using Data.ViewModels.DataRESVM;
using Microsoft.AspNetCore.Authorization;


namespace RESProject101.Controllers
{
    public class RealEsController : Controller
    {


        public readonly IServicesRepository ServicesRepository;
        public readonly Business.BusinessLayer.BRealES.IRepository.IRealESRepository IRealEsRepository;
        public readonly IFavoriteRepository IFavoriteRepository;
        public readonly ICommentRepository ICommentRepository;
        public readonly IUserRepository IUserRepository;



        private readonly MyDbContext _db;

        public RealEsController(MyDbContext b, IServicesRepository servicesRepository, Business.BusinessLayer.BRealES.IRepository.IRealESRepository iRealEsRepository, IFavoriteRepository iFavoriteRepository, ICommentRepository iCommentRepository, IUserRepository iUserRepository)
        {

            ServicesRepository = servicesRepository;
            IRealEsRepository = iRealEsRepository;
            this.IFavoriteRepository = iFavoriteRepository;
            _db = b;
            ICommentRepository = iCommentRepository;
            IUserRepository = iUserRepository;
        }
        [HttpGet]


        [Authorize]
        public IActionResult MyProperties()
        {

            var myProp = IRealEsRepository.GetMyPropertiesByCurrentUser();
            return View(myProp);
        }
        [Authorize]
        public IActionResult RemoveitFavoriteDashboard(string id)
        {

            IFavoriteRepository.RemoveRealEs(id);
            return RedirectToAction("Favorites");

        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            CreateVm data;
         
               data = new CreateVm
              {
                  CategoryListItems = ServicesRepository.GetCategoriesAsSelectListItem(),
                  CountriesListItems = ServicesRepository.GetCountryAsSelectListItem(),
                  Features = ServicesRepository.GetFeaturesAsSelectionFeature(),
                  Flag = false
              };
       
            return View(data);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateVm prop)
        {

            IRealEsRepository.Create(prop);
            return NoContent();
        }


        public IActionResult GetAllCountry()
        {
            var data = ServicesRepository.GetCountries();
            return Ok(data);
        }



        public async Task<IActionResult>  GetCities(string id)
        {
            var data = await ServicesRepository.GetCities(id);

            return Ok(data);
        }

        public IActionResult GetHoods(string id)
        {
            var data = ServicesRepository.GetHoods(id);
            return Ok(data);
        }

        public IActionResult Favorites()
        {
            var data = IFavoriteRepository.GetFavoriteByUserId();

            return View(data);

        }
        [Authorize]
        public IActionResult MakeitFavorite(string id)
        {
            IFavoriteRepository.AddFavorite(id);

            return Ok(1);

        }
        [Authorize]
        public IActionResult RemoveitFavorite(string id)
        {

            IFavoriteRepository.RemoveRealEs(id);
            return Ok();

        }

        [HttpGet]
        public IActionResult Update(string id)
        
        {
            var data = IRealEsRepository.UpdateGet(id).Result;
            data.CategoryListItems = ServicesRepository.GetCategoriesAsSelectListItem();
            data.CountriesListItems = ServicesRepository.GetCountryAsSelectListItem();
            data.Features = ServicesRepository.GetFeaturesAsSelectionFeature();
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(CreateVm updateData)
        {
          
            return View();
        }

        public IActionResult PostComment(DetailsVm comm)
        {
            ICommentRepository.AddComment(comm);
            return RedirectToAction("Details", "RealEs", new { id = comm.RealId });
        }
        public IActionResult Index(FilterVm fill)
        {
            var data = IRealEsRepository.GetAll();
            var dataAfterFilltering = IRealEsRepository.Filter(data, fill);
            var cardVm = IRealEsRepository.GetCardsForIndexPage(dataAfterFilltering);
            return View(cardVm);
        }


        [HttpGet]
        [Authorize]
        public IActionResult RemoveMyProperties(string id)
        {

            IRealEsRepository.Delete(id);


            return RedirectToAction("MyProperties");
        }

        public IActionResult Details(string id)
        {
            var data = IRealEsRepository.GetDetails(id);
            return View(data);
        }

      






    }
}
