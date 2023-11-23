using CodeXSnips.DataAccess.Repository.IRepository;
using CodeXSnips.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeXSnips.Controllers
{
    [Authorize]
    public class HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Explore()
        {
            return View();
        }
        
        public IActionResult FormLogin()
        {
            return View();
        }
        
        public IActionResult FormRegister()
        {
            return View();
        }
        
        public IActionResult Messages()
        {
            return View();
        }
        
        public IActionResult Profile()
        {
            return View();
        }
        
        public IActionResult Reels()
        {
            return View();
        }
        
        public IActionResult ReelsView()
        {
            return View();
        }
        
        public IActionResult Setting()
        {
            return View();
        }
        
        public IActionResult Shop()
        {
            return View();
        }
        
        public IActionResult Coders()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}