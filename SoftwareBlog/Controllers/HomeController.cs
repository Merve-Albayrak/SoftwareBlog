using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftwareBlog.Identity;
using SoftwareBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBlog.Controllers
{
    public class HomeController : Controller
    {


        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        IBlogPostService _blogPostService;
        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager,IBlogPostService blogPostService)
        {
            _ = this.User;
            _blogPostService = blogPostService;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            
            var posts =  await _blogPostService.GetAll();




            return View(new MyPageListViewModel()

            {
                MyPosts = posts.OrderByDescending(x=>x.BlogPostId).Take(9).ToList(),



            });

        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
