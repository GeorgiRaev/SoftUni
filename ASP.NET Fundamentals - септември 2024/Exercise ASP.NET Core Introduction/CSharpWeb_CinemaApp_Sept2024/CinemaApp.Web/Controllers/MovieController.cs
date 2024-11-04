using Microsoft.AspNetCore.Mvc;
using CinemaApp.Web.ViewModels;
using System.Runtime.CompilerServices;


namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
