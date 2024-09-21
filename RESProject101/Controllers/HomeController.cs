using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using Data.DataLayer;
using Data.ViewModels.DataRESVM;
using Microsoft.EntityFrameworkCore;
using RESProject101.Models;

namespace RESProject101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _db;

        public HomeController(ILogger<HomeController> logger , MyDbContext db)
        {
            _logger = logger;
            this._db = db;
        }

        public IActionResult Index()
        {
            var real  = _db.RealEs.Take(5).Include(x => x.Address)
              .ThenInclude(x => x.Country)
              .ThenInclude(x => x.Cities)
              .ThenInclude(x => x.Hoods)
              .Include(x => x.Images)
              .Include(x => x.Room)
              .Include(x => x.User)
              .Include(x => x.RealEsFeatures)
              .ThenInclude(x => x.Feature)
              .Include(x => x.Category)
              .ToList();
            List<CardVm> cardVm = new List<CardVm>();
            foreach (var card in real)
            {
                cardVm.Add(new CardVm
                {
                    ImageName = card.Images.Select(x => x.ImageName).ToList(),
                    UserName = card.User.FirstName + " " + card.User.LastName,
                    Title = card.Name,
                    Country = card.Address.Country.Name,
                    City = card.Address.City.Name,
                    Hood = card.Address.Hood.Name,
                    AreaSiza = card.AreaSize,
                    UserPp = card.User.ImageName,
                    TotalRooms = card.Room.NBathroom,
                    NBedRoom = card.Room.NBedroom,
                    Price = card.Price,
                    Date = card.CreatedAt.ToShortDateString(),
                    UserId = card.UserId,
                    RealId = card.Id,
                    Categories = _db.Categories.Select(x => new SelectionFeatures { Id = x.Id, Name = x.Name, IsSelected = false }).ToList(),
                    Features = _db.Features.Select(x => new SelectionFeatures { Id = x.Id, Name = x.Name, IsSelected = false }).ToList(),

                });

            }
            var d = _db.RealEs.Include(x => x.Category).ToList();
            var groupedData = d.GroupBy(x => x.CategoryId);

            var data = new HomeVm
            {
                Cards = cardVm,
                CountsCategory = groupedData.Select(g => new CountCategoty
                {
                    CategoryName = g.First().Category.Name,
                    CategotyId = g.Key,
                    Count = g.Count().ToString()
                }).ToList(),
                Categories = _db.Categories.Select(x => new SelectionFeatures { Id = x.Id, Name = x.Name, IsSelected = false }).ToList(),
            };

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }


        public IActionResult Search(string word)
        {
            
            var data = _db.RealEs.Where(x=>x.Name.Contains(word)).Select(x=>x.Name).ToList();

            return Ok(data);
        }

        public IActionResult Location(string word)
        {

            var data = _db.Countries.Where(x => x.Name.Contains(word)).Select(x => x.Name).ToList();

            return Ok(data);
        }

    }
}
