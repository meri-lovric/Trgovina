using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trgovina.Models
{
    public class Store
    {
        public int storeID { get; set; }
        [Required, StringLength(160, MinimumLength = 2)]
        public string storeName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}