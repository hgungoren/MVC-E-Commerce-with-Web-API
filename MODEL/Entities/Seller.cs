using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    //Bayiler
    public class Seller : EntityRepository
    {
        [Required]
        public string CityName { get; set; }
        public string District { get; set; }
        public string EmployeeTitle { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public int? SellerQuantity { get; set; }
        public decimal? SellerUnitPrice { get; set; }
        public decimal? TotalSalePrice { get; set; }
        public string SellerProductName { get; set; }
        public virtual SellerProduct SellerProduct { get; set; }
        public virtual List<SellerProduct> SellerProducts { get; set; }

    }
}
