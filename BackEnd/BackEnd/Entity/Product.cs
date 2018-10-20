using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackEnd.Entity
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(250)]
        public string ProductName { get; set; }
        [Required]
        public float Price { get; set; }
        [Required, StringLength(250)]
        public string Country { get; set; }
    }
}