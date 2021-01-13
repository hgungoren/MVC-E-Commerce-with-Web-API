using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public partial class Question: EntityRepository
    {
        
        public string QuestionLine { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }

        //public Answer Answer { get; set; }
        //public Nullable<System.DateTime> CreateDate { get; set; }
        //public string CreateBy { get; set; }
    }
}
