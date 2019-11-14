using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trgovina.Models
{
    public class Product
    {
        public int productID { get; set; }
        [Required, StringLength(160, MinimumLength = 2)]
        public string productName{ get; set; }
        public int quantity { get; set; }
        public int storeID { get; set; }
        public virtual Store Store { get; set; }

   
    }
}