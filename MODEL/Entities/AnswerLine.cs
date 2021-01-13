using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public partial class AnswerLine: EntityRepository
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        
        public Nullable<Guid> AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Question { get; set; }

        //public Answer Answer { get; set; }

    }
}
