using LabWeb.Models;
using System;
using System.Web.Mvc;

namespace LabWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var tw = new TwentyWays();
            tw.GenerateWord();

            ViewBag.VisualMessage = tw.ToString();

            return View();
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