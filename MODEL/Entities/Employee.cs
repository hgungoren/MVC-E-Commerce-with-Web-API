using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity;

namespace MODEL.Entities
{
    public class Employee : EntityRepository
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime HireDate { get; set; }
        public string ImagePath { get; set; }
        public decimal Salary { get; set; }
        public string IbanNo { get; set; }
        public int TCKN { get; set; }
        public string EducationStatus { get; set; }
        public string Certificate1 { get; set; }
        public string Certificate2 { get; set; }
        public string Permisson { get; set; }
        public string UsedLeave { get; set; }
        public decimal? PrimShift { get; set; }

        public virtual List<Payment> Payment { get; set; }

        public Guid SellerId { get; set; }
        public virtual Seller Seller { get; set; }

    }
}
