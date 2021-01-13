using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Payment : EntityRepository
    {
        public decimal TotalPrice { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }




    }
}
