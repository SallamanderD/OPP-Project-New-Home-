using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class ArticleWithTeg
    {
        [Key]
        public int ArticleWithTegId { set; get; }


        [ForeignKey("Order")]
        public int OrderId { set; get; }

        public virtual Order Order {set;get;}

        [ForeignKey("Article")]
        public int ArticleId { set; get; }

        public virtual Article Article { set; get; }
        
        [ForeignKey("Teg")]
        public int TegId { set; get; }

        public virtual Teg Teg { set; get; }

 
    }
}