using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class QuestionMap : CoreMap<Question>
    {
        public QuestionMap()
        {
            ToTable("dbo.Questions");
            Property(x => x.QuestionLine).HasMaxLength(255).IsOptional();
            Property(x => x.ModifyDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.ModifyBy).HasMaxLength(150).IsOptional();
            
        }
    }
}
