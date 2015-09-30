﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    /// <summary>
    /// Класс содержащий ключивые слова (Математика, Английский, уборка)
    /// для поиска по статьям
    /// </summary>
    public class Teg
    {
        public Teg() { }

        [Key]
        public int TegId { set; get; }

        [Column]
        public string Word { set; get; }

        public virtual IEnumerable<ArticleWithTeg> AWT { set; get; }
    }
}