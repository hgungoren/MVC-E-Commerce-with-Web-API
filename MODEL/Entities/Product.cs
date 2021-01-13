using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity;

namespace MODEL.Entities
{
    public class Product : EntityRepository
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public decimal SupplierUnitPrice { get; set; }

        public Guid SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        //public virtual List<DefectiveProduct> DefectiveProducts { get; set; }
        //public virtual List<ProductReturn> ProductReturns { get; set; }


        //Kriter Notu 
        public decimal? CriterionNote { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal PurchasePrice { get; set; }


    }
}
