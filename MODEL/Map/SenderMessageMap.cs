using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class SenderMessageMap: CoreMap<SenderMessage>
    {
        public SenderMessageMap()
        {
            ToTable("dbo.SenderMessages");
            Property(x => x.Name).HasMaxLength(30).IsOptional();
            Property(x => x.Message).HasMaxLength(255).IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsOptional();
            Property(x => x.Date).HasColumnType("datetime2").IsOptional();
        }
    }
}
