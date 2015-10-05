using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;
using Microsoft.AspNet.Identity;

namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            IEnumerable<Order> OrderArticles = from i in db.Orders
                                               orderby i.DateStart descending
                                               select i;

            ViewBag.db = OrderArticles.ToList();
            return View();
        }

        public ActionResult AddArticle()
        {
            ViewBag.Teg = db.Tegs.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(string Info, string teg)
        {
            lock (db)
            {
                db.Articles.Add(new Article { Info = Info, ArticleId = db.Articles.Count() + 1 });
                db.AWT.Add(new ArticleWithTeg { ArticleId = db.Articles.Count(), TegId = db.Tegs.Where(x => x.Value == teg).First().TegId, OrderId = db.Orders.Count() + 1 });
                db.Orders.Add(new Order { DateStart = DateTime.Now, OrderId = db.Orders.Count() + 1, CustomerId = User.Identity.GetUserId(), Completed = false });

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult TakeArticle(int OrderId)
        {
            if (User.Identity.IsAuthenticated && User.Identity.GetUserId() != db.Orders.Where(x => x.OrderId == OrderId).First().CustomerId)
            {
                lock (db)
                {
                    db.Orders.ToList().Where(x => x.OrderId == OrderId).First().EmailWorker = User.Identity.GetUserId();
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ThrowArticle(int Id)
        {
            lock (db)
            {
                db.Orders.Where(x => x.OrderId == Id).First().EmailWorker = null;
                db.SaveChanges();
            }
            return RedirectToAction("ShowUser", new { id = User.Identity.GetUserId() });
        }

        [HttpGet]
        public ActionResult ShowUser(string Id)
        {

            ViewBag.User = db.Users.Where(x => x.Id == Id).First();
            return View();
        }

    }
}