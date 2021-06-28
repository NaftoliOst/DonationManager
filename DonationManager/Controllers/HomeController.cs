using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonationManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Import Data
        public ActionResult ImportData()
        {
            return View();
        }

        // GET: Reports
        public ActionResult Reports()
        {
            return View();
        }
    }
}