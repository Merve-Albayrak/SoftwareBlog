using Business.Abstract;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftwareBlog.Identity;
using SoftwareBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBlog.Controllers
{
    public class PostController : Controller
    {
        IBlogPostService _blogPostService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public PostController(IBlogPostService blogPostService, SignInManager<User> signInManager, UserManager<User> userManager, IBlogPostService postService)
        {
            _ = this.User;
            _blogPostService = blogPostService;
            _userManager = userManager;
            _blogPostService = postService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel postModel)
        {
            var user = await _userManager.GetUserAsync(User);
            string id = user.Id;
            if (ModelState.IsValid)
            {
                var entity = new BlogPost()
                {
                    Content = postModel.Text,
                    UserId=id,
                    PostDate=DateTime.Now

                };

                if (_blogPostService.Create(entity))
                {
                   
                    return RedirectToAction("MyPage","Account");
                }
                

                return View("Index");
            }
            return View("Index");


        }
    }
}
