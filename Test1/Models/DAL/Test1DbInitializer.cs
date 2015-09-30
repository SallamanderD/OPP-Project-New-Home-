using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test1.Models.DAL
{
    public class Test1DbInitializer:DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            List<Teg> tegs = new List<Teg>();
            tegs.Add(new Teg { TegId = 1, Word = "Математика" });
            tegs.Add(new Teg { TegId = 2, Word = "Уборка" });
            tegs.Add(new Teg { TegId = 3, Word = "Прогулка" });
            tegs.Add(new Teg { TegId = 4, Word = "Английский" });
            tegs.Add(new Teg { TegId = 5, Word = "Программирование" });

            db.Roles.Add(new Role { RoleId = 1, Type = "Admin" });
            db.Roles.Add(new Role { RoleId = 2, Type = "User" });

            db.Users.Add(new ApplicationUser { Email="gladush97@gmail.com",Name="Vanya",RoleId=1,Money=0,UserName="Vanya",Surname="Hladush"});
            List<Article> articls = new List<Article>();
            articls.Add(new Article { DateStart = DateTime.Today, ArticleId = 1, Info = "Не сложные задачи по математики, нужно помочь решить. Всего пара штучек за пара часиков, ,все будет хорошо." });
            articls.Add(new Article { DateStart = DateTime.Today, ArticleId = 2, Info = "Нужно сделать фронтенд для молодого проека Банк времени" });
            articls.Add(new Article { DateStart = DateTime.Today, ArticleId = 3, Info = "НУжно делать хоть, что-то и придумівать работу себе самим" });

            List<ArticleWithTeg> AWT = new List<ArticleWithTeg>();


            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < tegs.Count; j++) {
                    AWT.Add(new ArticleWithTeg { ArticleId = (j * i) % articls.Count + 1, ArticleWithTegId = 1, TegId = (i * j) % tegs.Count + 1 });
                }
            }
            List<Order> Orders = new List<Order>();
            Orders.Add(new Order { ArticleId = 1, OrderId = 2 });
            Orders.Add(new Order { ArticleId = 1, OrderId = 3 });
            Orders.Add(new Order { ArticleId = 1, OrderId = 4 });
            Orders.Add(new Order { ArticleId = 1, OrderId = 1 });
            foreach (var x in Orders) {
                db.Orders.Add(x);
            }
            foreach (var x in articls) {
                db.Articles.Add(x);
            }

            foreach (var x in tegs) {
                db.Tegs.Add(x);
            }
            foreach (var x in AWT) {
                db.AWT.Add(x);
            }
           
               

         
            db.SaveChanges();
            base.Seed(db);
        }
    }
}