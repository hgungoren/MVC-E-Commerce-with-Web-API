using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class ProductReturn: EntityRepository
    {
        public string NameSurname { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IbanNo { get; set; }
        public DateTime Date { get; set; }
    }
}
