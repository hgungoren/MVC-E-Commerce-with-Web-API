using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class SupplierProduct:EntityRepository
    {
        
        
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string OtherProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int SupplierStock { get; set; }
        public int DeliverTimeInDays { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
