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

            for (int i = 0; i < 3; i++)
            {
                db.AWT.Add(new ArticleWithTeg { ArticleId = i + 1, ArticleWithTegId = i, TegId = i + 1, OrderId = i + 1 });

            }
            db.Tegs.Add(new Teg { TegId = 1, Word = "Математика" });
            db.Tegs.Add(new Teg { TegId = 2, Word = "Уборка" });
            db.Tegs.Add(new Teg { TegId = 3, Word = "Прогулка" });
            db.Tegs.Add(new Teg { TegId = 4, Word = "Английский" });
            db.Tegs.Add(new Teg { TegId = 5, Word = "Программирование" });

            db.Roles.Add(new Role { RoleId = 1, Type = "Admin" });
            db.Roles.Add(new Role { RoleId = 2, Type = "User" });

            db.Articles.Add(new Article { ArticleId = 1, Info = "Не сложные задачи по математики, нужно помочь решить. Всего пара штучек за пара часиков, ,все будет хорошо." });
            db.Articles.Add(new Article { ArticleId = 2, Info = "Нужно сделать фронтенд для молодого проека Банк времени" });
            db.Articles.Add(new Article { ArticleId = 3, Info = "НУжно делать хоть, что-то и придумівать работу себе самим" });


            db.Orders.Add(new Order { OrderId = 1, DateStart = DateTime.Today, });
            db.Orders.Add(new Order { OrderId = 2, DateStart = DateTime.Today, });
            db.Orders.Add(new Order { OrderId = 3, DateStart = DateTime.Today, });
        

            db.SaveChanges();
            base.Seed(db);
        }
    }
}