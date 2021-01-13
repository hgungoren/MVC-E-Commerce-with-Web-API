using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class AnswerLineMap : CoreMap<AnswerLine>
    {
        public AnswerLineMap()
        {
            ToTable("dbo.AnswerLines");
            Property(x => x.Question).HasMaxLength(150).IsOptional();
            
        }
    }
}
