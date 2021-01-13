using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class SellerMap : CoreMap<Seller>
    {
        public SellerMap()
        {
            ToTable("dbo.Sellers");
            Property(x => x.CityName).HasMaxLength(60).IsRequired();//yerine attiribute eklendi.
            Property(x => x.District).HasMaxLength(60).IsOptional();
            Property(x => x.EmployeeTitle).HasMaxLength(60).IsOptional();
            Property(x => x.SellerProductName).HasMaxLength(60).IsOptional();
            Property(x => x.SellerQuantity).IsOptional();
            Property(x => x.SellerUnitPrice).IsOptional();
            Property(x => x.TotalSalePrice).IsOptional();
        }
    }
}
