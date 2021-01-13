using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class SupplierPayment : EntityRepository
    {
        public decimal SupplierPay { get; set; }
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
