using luke_josh_project.Models.ViewModels;
using luke_josh_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace luke_josh_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeService homeService = new HomeService();
            HomeViewModel viewModel = homeService.GetHomeData();

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}