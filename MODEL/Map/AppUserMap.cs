using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity;
using MODEL.Entities;
using CORE.Map;

namespace MODEL.Map
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Address).HasMaxLength(255).IsOptional();
            Property(x => x.Email).HasMaxLength(150).IsRequired();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.ImagePath).HasMaxLength(255).IsOptional();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.PhoneNumber).HasMaxLength(15).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.LastName).HasMaxLength(50).IsOptional();
            Property(x => x.Gender).HasMaxLength(5).IsOptional();
            
        }
    }
}
