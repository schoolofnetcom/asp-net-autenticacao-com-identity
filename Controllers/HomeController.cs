using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using autenticacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace autenticacao.Controllers
{

    
    public class HomeController : Controller
    {
        
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController( UserManager<IdentityUser> userManager){
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.GetUserAsync(User);
            //return Content(User.FindFirst("Fullname").Value);
            return View();
        }


        [Authorize(Policy = "TemNome")]
        public IActionResult Privacy()
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
