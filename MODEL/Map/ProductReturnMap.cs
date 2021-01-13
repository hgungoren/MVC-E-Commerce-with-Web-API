using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
   public class ProductReturnMap: CoreMap<ProductReturn>
    {
        public ProductReturnMap()
        {
            ToTable("dbo.ProductReturns");
            Property(x => x.NameSurname).HasMaxLength(40);
            Property(x => x.Email).HasMaxLength(30);
            Property(x => x.PhoneNumber).HasMaxLength(15);
            Property(x => x.IbanNo).HasMaxLength(30);
            Property(x => x.Date).HasColumnType("datetime2");
        }
    }
}
