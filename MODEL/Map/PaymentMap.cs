using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class PaymentMap : CoreMap<Payment>
    {
        public PaymentMap()
        {
            ToTable("dbo.Payments");
            Property(x => x.EmployeeId).IsOptional();



        }
    }
}
