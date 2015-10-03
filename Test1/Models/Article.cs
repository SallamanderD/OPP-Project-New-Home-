using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test1.Models
{

    /// <summary>
    /// Статья, класс ордер все равно рассширится и нужно будет разбивать
    /// </summary>
    public class Article
    {
        public Article()
        {
            ArticleWithTeg = new List<ArticleWithTeg>();
        }

        [Key]
        public int ArticleId { set; get; }

        [Column]
        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Длина строки должна быть от 20 до 1000 символов.")]
        public string Info { set; get; }


        public virtual List<ArticleWithTeg> ArticleWithTeg { set; get; }
    }
}