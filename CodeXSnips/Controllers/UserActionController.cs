using CodeXSnips.DataAccess.Repository.IRepository;
using CodeXSnips.Models;
using CodeXSnips.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Security.Claims;

namespace CodeXSnipsWeb.Controllers
{
    public class UserActionController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpPost]
        public IActionResult UpsertCodeSnippet(CodeSnippetVM codeSnippetVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\CodeSnippet");

                    if (!string.IsNullOrEmpty(codeSnippetVM.CodeSnippet.CodeImage))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, codeSnippetVM.CodeSnippet.CodeImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    codeSnippetVM.CodeSnippet.CodeImage = @"\images\CodeSnippet\" + fileName;
                }

                codeSnippetVM.CodeSnippet.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (codeSnippetVM.CodeSnippet.CodeSnippetId == 0)
                {
                    _unitOfWork.CodeSnippet.Add(codeSnippetVM.CodeSnippet);
                }
                else
                {
                    _unitOfWork.CodeSnippet.Update(codeSnippetVM.CodeSnippet);
                }
                _unitOfWork.Save();
                TempData["success"] = "Code snippet created successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpsertCodeReel(CodeReelVM codeReelVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\CodeReel");

                    if (!string.IsNullOrEmpty(codeReelVM.CodeReel.CodeReelVideo))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, codeReelVM.CodeReel.CodeReelVideo.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    codeReelVM.CodeReel.CodeReelVideo = @"\images\CodeReel\" + fileName;
                }

                if (codeReelVM.CodeReel.CodeReelId == 0)
                {
                    _unitOfWork.CodeReel.Add(codeReelVM.CodeReel);
                }
                else
                {
                    _unitOfWork.CodeReel.Update(codeReelVM.CodeReel);
                }

                _unitOfWork.Save();
                TempData["success"] = "Code reel created successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult UpsertStory(StoryVM storyVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\Story");

                    if (!string.IsNullOrEmpty(storyVM.Story.StoryMedia))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, storyVM.Story.StoryMedia.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    storyVM.Story.StoryMedia = @"\images\Story\" + fileName;
                }

                if (storyVM.Story.StoryId == 0)
                {
                    _unitOfWork.Story.Add(storyVM.Story);
                }
                else
                {
                    _unitOfWork.Story.Update(storyVM.Story);
                }

                _unitOfWork.Save();
                TempData["success"] = "Story created successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _unitOfWork.Comment.Add(comment);
                _unitOfWork.Save();
                TempData["success"] = "Comment added successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
