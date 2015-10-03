using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Role
    {
        [Key]
        public int RoleId { set; get; }

        [Column]
        public string Type { set; get; }
    }
}