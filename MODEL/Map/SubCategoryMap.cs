using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Map;
using MODEL.Entities;

namespace MODEL.Map
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.SubCategoryName).HasMaxLength(255).IsRequired();
            Property(x => x.Description).HasMaxLength(255).IsOptional();
        }
    }
}
