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
            db.Articles.Add(new Article { Info = Info, ArticleId = db.Articles.Count() + 1 });
            db.AWT.Add(new ArticleWithTeg { ArticleId = db.Articles.Count(), TegId = db.Tegs.Where(x => x.Word == teg).First().TegId, OrderId = db.Orders.Count() + 1 });
            db.Orders.Add(new Order { DateStart = DateTime.Now, OrderId = db.Orders.Count() + 1, UserId = User.Identity.GetUserId() });

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SearchByInfo(string Info)
        {
            List<Article> ResultList = new List<Article>();
            foreach (Article article in db.Articles)
            {
                if (article.Info.Contains(Info))
                {
                    ResultList.Add(article);
                }
            }
            ViewBag.Result = ResultList;
            return View();
        }


    }


}