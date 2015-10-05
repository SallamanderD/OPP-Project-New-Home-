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
        public Order() {
            ArticleWithTeg = new List<ArticleWithTeg>();
        }

        [Key]
        [Required]
        public int OrderId { set; get; }

        [Column]
        [Required]
        public DateTime DateStart { set; get; }

        [Column]
        public string EmailWorker { set; get; }

        [ForeignKey("Customer")]
        public string CustomerId { set; get; }

        public virtual ApplicationUser Customer { set; get; }

        [Column]
        [Required]
        public bool Completed { set; get; }

        public virtual List<ArticleWithTeg> ArticleWithTeg { set; get; }




    }
}