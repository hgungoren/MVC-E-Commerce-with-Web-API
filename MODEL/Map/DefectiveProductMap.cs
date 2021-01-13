using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class DefectiveProductMap: CoreMap<DefectiveProduct>
    {
        public DefectiveProductMap()
        {
            ToTable("dbo.DefectiveProducts");
            Property(x => x.NameSurname).HasMaxLength(50).IsRequired();
            Property(x => x.ProductId).IsOptional();
            //Property(x => x.Product.ProductName).IsOptional();
            //Property(x => x.ImagePath).HasMaxLength(255).IsOptional();
            Property(x => x.Description).HasMaxLength(255).IsRequired();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.PhoneNumber).HasMaxLength(50).IsOptional();
            Property(x => x.IbanNo).HasMaxLength(50).IsRequired();
            Property(x => x.Date).HasColumnType("datetime2").IsOptional();

        }
        
    }
}
