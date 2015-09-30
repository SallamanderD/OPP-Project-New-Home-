using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Order
    {
        public Order() { }

        [Key]
        [Required]
        public int OrderId { set; get; }



        [Column]
        public int EmailWorker { set; get; }      

        [ForeignKey("Article")]
        public int ArticleId { set; get; }

        public virtual Article  Article{set;get;}


        [ForeignKey("User")]
        public string UserId { set; get; }

        public virtual ApplicationUser User{set;get;}



             
    }
}