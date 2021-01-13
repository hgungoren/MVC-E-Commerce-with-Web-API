using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class SupplierMap : CoreMap<Supplier>
    {
        public SupplierMap()
        {
            ToTable("dbo.Supplier");
            Property(x => x.CompanyName).HasMaxLength(60).IsRequired();
            Property(x => x.ContactName).HasMaxLength(20).IsRequired();
            Property(x => x.Adress).IsOptional();
            Property(x => x.IbanNo).HasMaxLength(20).IsRequired();
        }
    }
}
