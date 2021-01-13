using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class OrderDetailMap : CoreMap<OrderDetails>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(x => x.UnitPrice).IsRequired();
            Property(x => x.Quantity).IsRequired();
        }
    }
}