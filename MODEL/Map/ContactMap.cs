using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MODEL.Map
{
    public class ContactMap: CoreMap<Contact>
    {
        public ContactMap()
        {
            ToTable("dbo.Contacts");
            Property(x => x.Name).HasMaxLength(30).IsRequired();
            Property(x => x.Subject).HasMaxLength(100).IsOptional();
            Property(x => x.Message).HasMaxLength(255).IsRequired();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.Date).HasColumnType("datetime2").IsOptional();
        }
    }
}
