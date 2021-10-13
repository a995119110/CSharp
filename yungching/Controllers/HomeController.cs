using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yungching.Models;

namespace yungching.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindEntities northwind = new NorthwindEntities();
        public ActionResult Index()
        {
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

        [ActionName("List")]
        public ActionResult List()
        {
            return View(northwind.Categories.ToList());
        }

        [ActionName("Edit")]
        public ActionResult ChangeName(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categorie = northwind.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }


    }
}