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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult InsertValue(Categories modelCategories)
        {
            if (ModelState.IsValid)
            {
                northwind.Categories.Add(modelCategories);
                northwind.SaveChanges(); //建議使用SaveChangesAsync 動態分配時間 刪除同理

                //northwind.Categories.Add(modelCategories);
                //await northwind.SaveChangesAsync();

                return RedirectToAction("List");
            }
            return View(modelCategories);
        }

        public ActionResult Delete(int? id)
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

        [HttpPost]
        [ActionName("Detele")]
        public ActionResult DeteleValue(int? id)
        {
            if (id != null)
            {
                Categories categories = northwind.Categories.Find(id);
                northwind.Categories.Remove(categories);
                northwind.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}