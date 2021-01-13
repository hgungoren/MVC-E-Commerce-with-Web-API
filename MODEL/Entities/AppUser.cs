using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity;
using CORE.CoreEntity.Enums;

namespace MODEL.Entities
{
    public class AppUser : EntityRepository
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string TCKN { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }

        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
        public Guid ActivationId { get; set; }
        public bool IsActive { get; set; }
        public string IbanNo { get; set; }
        //public Role Role { get; set; }
        public string Role { get; set; }



        public string PersonCode { get; set; }
        public string PersonName { get; set; }
        public string UserCode { get; set; }
        public string Score { get; set; }
        public Nullable<bool> Iscomplete { get; set; }
        public string dokuman_path { get; set; }
        public string dokuman_adi { get; set; }
        public string dokuman_no { get; set; }
        //public string TCKN { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //public string ZipCode { get; set; }




        //public List<Answer> Answers { get; set; }


        //public string Score { get; set; }


        //public Nullable<System.DateTime> CreateDate { get; set; }

        //public string CreateBy { get; set; }

        //public Nullable<System.DateTime> ModifyDate { get; set; }

        //public string ModifyBy { get; set; }

        //public Nullable<bool> IsAdmin { get; set; }
    }
}
