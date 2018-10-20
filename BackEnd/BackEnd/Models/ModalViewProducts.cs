using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class ModalViewProducts
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Country { get; set; }
    }
}