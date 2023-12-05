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
            IEnumerable<Models.CodeSnippet> codeSnippetList = _unitOfWork.CodeSnippet.GetAll(includeProperties: "User,Comments,Likes");

            return View(codeSnippetList);
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

            if (id == null || string.IsNullOrEmpty(id))
            {
                string? loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(!string.IsNullOrEmpty(loggedUserId))
                {
                    var loggedUserModel = _unitOfWork.User.Get(u => u.Id == loggedUserId, includeProperties: "CodeSnippet");
                    return View(loggedUserModel);
                }
            }
            var model = _unitOfWork.User.Get(u => u.Id == id, includeProperties: "CodeSnippet");
            return View(model);
        }

        public IActionResult Reels()
        {
            IEnumerable<Models.CodeSnippet> codeSnippetList = _unitOfWork.CodeSnippet.GetAll(includeProperties: "User,Comments,Likes");
            return View(codeSnippetList);
        }

        public IActionResult ReelView(int id)
        {
            var reel = _unitOfWork.CodeSnippet.Get(u => u.CodeSnippetId == id, includeProperties: "User,Comments,Likes");
            return View(reel);
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
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.User.GetAll();
            return View(applicationUsers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
