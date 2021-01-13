using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.ProductName).HasMaxLength(255).IsRequired();
            Property(x => x.ImagePath).HasMaxLength(255).IsOptional();
            Property(x => x.UnitPrice).IsRequired();
            Property(x => x.UnitsInStock).IsRequired();
            Property(x => x.CriterionNote).IsOptional();


        }
    }
}
