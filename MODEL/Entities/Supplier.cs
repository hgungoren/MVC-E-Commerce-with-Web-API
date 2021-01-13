using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity;

namespace MODEL.Entities
{
    public class Supplier : EntityRepository
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string IbanNo { get; set; }
        public int DeliveryTimeInDays { get; set; }
        public string Email { get; set; }

        public decimal? SupplierPayment { get; set; }



        public virtual List<Product> Products { get; set; }
        
        

    }
}
