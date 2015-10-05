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

            db.Roles.Add(new Role { RoleId = 1, Type = "Admin" });
            db.Roles.Add(new Role { RoleId = 2, Type = "User" });
            db.Users.Add(new ApplicationUser { Email = "gladsuh97@gmail.com", Name = "Vanya", Surname = "Hladush", Money = 0, RoleId = 1,UserName="Vanya" });
            db.SaveChanges();
            for (int i = 0; i < 3; i++)
            {
                db.AWT.Add(new ArticleWithTeg { ArticleId = i + 1, ArticleWithTegId = i, TegId = i + 1, OrderId = i + 1 });

            }
           db.Tegs.Add(new Teg { TegId = 1, Value = "Математика" });
            db.Tegs.Add(new Teg { TegId = 2, Value = "Уборка" });
            db.Tegs.Add(new Teg { TegId = 3, Value = "Прогулка" });
            db.Tegs.Add(new Teg { TegId = 4, Value = "Английский" });
            db.Tegs.Add(new Teg { TegId = 5, Value = "Программирование" });


            db.Articles.Add(new Article { ArticleId = 1, Info = "Несложные задачи по математике, нужно помочь решить. Всего пара штучек за пара часиков, ,все будет хорошо." });
            db.Articles.Add(new Article { ArticleId = 2, Info = "Нужно сделать фронтенд для молодого проека Банк времени" });
            db.Articles.Add(new Article { ArticleId = 3, Info = "НУжно делать хоть, что-то и придумівать работу себе самим" });


            db.Orders.Add(new Order { OrderId = 1, DateStart = DateTime.Today, CustomerId = db.Users.ToList().First().Id, Completed = false });
            db.Orders.Add(new Order { OrderId = 2, DateStart = DateTime.Today,CustomerId=db.Users.ToList().First().Id, Completed = false });
            db.Orders.Add(new Order { OrderId = 3, DateStart = DateTime.Today, CustomerId = db.Users.ToList().First().Id, Completed = false });
        

            db.SaveChanges();
            base.Seed(db);
        }
    }
}