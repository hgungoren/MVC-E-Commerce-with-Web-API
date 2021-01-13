using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class SellerProduct:EntityRepository
    {
        public virtual Product Product { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual List<Seller> Sellers { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
