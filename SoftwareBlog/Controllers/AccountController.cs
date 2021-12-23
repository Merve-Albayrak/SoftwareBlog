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
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController( UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _ = this.User;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<IActionResult> MyPage()
        {
            var user = await _userManager.GetUserAsync(User);
           string id = user.Id;
          //  id = _signInManager.IsSignedIn();

            return View();
        }
      
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Login(string ReturnUrl = null)
        //{
        //    return RedirectToAction("Index", "Home");
            
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

             var user = await _userManager.FindByNameAsync(model.UserName);
          //  var user = await _userManager.FindByEmailAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı ile daha önce hesap oluşturulmamış");
                return View(model);
            }

            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    ModelState.AddModelError("", "Lütfen email hesabınıza gelen link ile üyeliğinizi onaylayınız.");
            //    return View(model);
            //}

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("MyPage", "Account");
            }

            ModelState.AddModelError("", "Girilen kullanıcı adı veya parola yanlış");
            return View(model);
        }
     //  [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      //  [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            //return RedirectToAction("Index", "Home");
          //  Console.WriteLine("anan");
            if (!ModelState.IsValid)
            {
              //  return RedirectToAction("Index", "Home");
               return View(model);
            }

            var user = new User()
            {
            
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // generate token
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var url = Url.Action("ConfirmEmail", "Account", new
                //{
                //    userId = user.Id,
                //    token = code
                //});

                // email
               // await _emailSender.SendEmailAsync(model.Email, "Hesabınızı onaylayınız.", $"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }
    }
}
