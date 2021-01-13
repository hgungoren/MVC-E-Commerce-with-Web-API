using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Models.Basket;

namespace UI.Models
{
    public class DeleteCartVM:Cart
    {
        public Product Product { get; set; }
        public int QuantityInBasket { get; set; }
        public int MyProperty { get; set; }
    }
}