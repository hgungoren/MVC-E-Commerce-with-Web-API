using CORE.Map;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Map
{
    public class EmployeeMap : CoreMap<Employee>
    {
        public EmployeeMap()
        {
            ToTable("dbo.Employees");
            Property(x => x.FirstName).HasMaxLength(20).IsRequired();
            Property(x => x.LastName).HasMaxLength(20).IsRequired();
            Property(x => x.Adress).IsOptional();
            Property(x => x.HireDate).IsRequired();
            Property(x => x.Salary).IsRequired();
            Property(x => x.IbanNo).HasMaxLength(20).IsRequired();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Title).IsRequired();
            Property(x => x.PrimShift).IsOptional();



        }

    }
}
