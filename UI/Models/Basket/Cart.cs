using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Basket
{
    public class Cart
    {
        public Cart()
        {
            Quantity = 1;
        }
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public string ImagePath { get; set; }
        public string SubCategoryName { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
        public Guid productId { get; set; }
        public List<Product> Products { get; set; }
    }
}