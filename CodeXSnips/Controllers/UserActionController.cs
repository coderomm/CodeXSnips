using CodeXSnips.DataAccess.Data;
using CodeXSnips.DataAccess.Repository.IRepository;
using CodeXSnips.Models;
using CodeXSnips.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CodeXSnipsWeb.Controllers
{
    public class UserActionController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpPost]
        public IActionResult CreateCodeSnippet(CodeSnippetVM codeSnippetVM)
        {
            if (ModelState.IsValid)
            {
                var mediaFile = codeSnippetVM.MediaFile;

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                // Handle media file
                if (mediaFile != null && mediaFile.Length > 0)
                {
                    string imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(mediaFile.FileName);
                    string imagePath = Path.Combine(wwwRootPath, "images", "CodeSnippet", imageFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        mediaFile.CopyTo(stream);
                    }

                    codeSnippetVM.MediaPath = "images/CodeSnippet/" + imageFileName;
                }

                var model = new CodeXSnips.Models.CodeSnippet
                {
                    Content = codeSnippetVM.Content,
                    MediaPath = codeSnippetVM.MediaPath,
                    CreatedAt = DateTime.Now,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                _unitOfWork.CodeSnippet.Add(model);
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
        public IActionResult CreateStory(StoryVM storyVM)
        {
            if (ModelState.IsValid)
            {
                // Access the image and video files
                var mediaFile = storyVM.MediaFile;
                /*var imageFile = storyVM.ImageFile;
                var videoFile = storyVM.VideoFile;*/

                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Handle story media file
                if (mediaFile != null && mediaFile.Length > 0)
                {
                    string imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(mediaFile.FileName);
                    string imagePath = Path.Combine(wwwRootPath, "images", "Story", imageFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        mediaFile.CopyTo(stream);
                    }

                    storyVM.MediaPath = "images/Story/" + imageFileName;
                }

                /*// Handle image file
                if (imageFile != null && imageFile.Length > 0)
                {
                    string imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string imagePath = Path.Combine(wwwRootPath, "images", "Story", "images", imageFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    storyVM.ImagePath = "images/Story/images/" + imageFileName;
                }

                // Handle video file
                if (videoFile != null && videoFile.Length > 0)
                {
                    string videoFileName = Guid.NewGuid().ToString() + Path.GetExtension(videoFile.FileName);
                    string videoPath = Path.Combine(wwwRootPath, "images", "Story", "videos", videoFileName);

                    using (var stream = new FileStream(videoPath, FileMode.Create))
                    {
                        videoFile.CopyTo(stream);
                    }

                    storyVM.VideoPath = "images/Story/videos/" + videoFileName;
                }*/

                var storyModel = new Story
                {
                    Content = storyVM.Content,
                    MediaPath = storyVM.MediaPath,
                    /*ImagePath = storyVM.ImagePath,
                    VideoPath = storyVM.VideoPath,*/
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddHours(24),
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                _unitOfWork.Story.Add(storyModel);
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

        [HttpPost]
        public IActionResult UpsertUserData(ApplicationUser user, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId != user.Id)
                {
                    return RedirectToAction("Index", "Home");
                }

                var entityInDb = _unitOfWork.User.Get(u => u.Id == userId);

                if (entityInDb != null)
                {
                    _unitOfWork.User.Detach(entityInDb);
                    user.Id = entityInDb.Id;
                    user.UserName = entityInDb.UserName;
                    user.NormalizedUserName = entityInDb.NormalizedUserName;
                    user.Email = entityInDb.Email;
                    user.NormalizedEmail = entityInDb.NormalizedEmail;
                    user.PasswordHash = entityInDb.PasswordHash;
                    user.SecurityStamp = entityInDb.SecurityStamp;
                    user.ConcurrencyStamp = entityInDb.ConcurrencyStamp;
                    user.LockoutEnabled = entityInDb.LockoutEnabled;

                    if (string.IsNullOrEmpty(user.FullName))
                    {
                        user.FullName = entityInDb.FullName;
                    }

                    if (!string.IsNullOrEmpty(user.Bio))
                    {
                        user.Bio = entityInDb.Bio;
                    }

                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        user.Email = entityInDb.Email;
                        user.NormalizedEmail = user.NormalizedEmail.ToUpper();
                    }

                    if (!string.IsNullOrEmpty(user.PhoneNumber))
                    {
                        user.PhoneNumber = entityInDb.PhoneNumber;
                    }
                }
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\User");

                    if (!string.IsNullOrEmpty(user.ProfileImage))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, user.ProfileImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    user.ProfileImage = @"\images\User\" + fileName;
                }

                _unitOfWork.User.Update(user);
                _unitOfWork.Save();
                TempData["success"] = "User updated successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
