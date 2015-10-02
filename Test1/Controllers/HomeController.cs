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
            ViewBag.db = SortByAlphabet(db.Articles.ToList());
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
        public ActionResult AddArticle(string Info,string teg) {
            db.Articles.Add(new Article { Info = Info, ArticleId = db.Articles.Count() + 1, DateStart = DateTime.Now });
            db.AWT.Add(new ArticleWithTeg { ArticleId = db.Articles.Count(), TegId = db.Tegs.Where(x => x.Word == teg).First().TegId });
            db.Orders.Add(new Order { ArticleId = db.Articles.Count(), OrderId = db.Orders.Count() + 1, UserId = User.Identity.GetUserId() });

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

        public List<Article> SortByAlphabet(List<Article> UnsortedList)
        {
            List<Article> ResultList = UnsortedList;
            var OrderArticles = from i in ResultList
                                orderby i.DateStart descending
                                select i;
            ResultList = OrderArticles.ToList();
            return ResultList;
        }

    }


}