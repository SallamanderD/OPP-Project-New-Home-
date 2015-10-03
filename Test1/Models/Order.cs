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

        [ForeignKey("User")]
        public string UserId { set; get; }

        public virtual ApplicationUser User { set; get; }
        
        public virtual List<ArticleWithTeg> ArticleWithTeg { set; get; }


    }
}