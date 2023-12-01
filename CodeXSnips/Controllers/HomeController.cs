using CodeXSnips.DataAccess.Repository.IRepository;
using CodeXSnips.Models;
using CodeXSnips.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Diagnostics;
using System.Security.Claims;

namespace CodeXSnips.Controllers
{
    [Authorize]
    public class HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            IEnumerable<Models.CodeSnippet> codeSnippetList = _unitOfWork.CodeSnippet.GetAll(includeProperties: "User,Comments,Likes");

            AllVM allViewModel = new()
            {
                CodeSnippetList = codeSnippetList,
                CommentList = codeSnippetList.SelectMany(cs => cs.Comments).ToList(),
                LikeList = codeSnippetList.SelectMany(cs => cs.Likes).ToList(),
                UserList = _unitOfWork.User.GetAll().ToList(),
                StoryList = _unitOfWork.Story.GetAll().ToList()
            };

            return View(allViewModel);
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

        public IActionResult Profile(string id)
        {
            ApplicationUser model = _unitOfWork.User.Get(u => u.Id == id);
            return View(model);
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser model = _unitOfWork.User.Get(u => u.Id == userId);
            return View(model);
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
