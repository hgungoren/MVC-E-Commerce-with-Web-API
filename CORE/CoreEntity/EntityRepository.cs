using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CORE.CoreEntity.Enums;

namespace CORE.CoreEntity
{
    public class EntityRepository : IEntity<Guid>
    {
        public EntityRepository()
        {
            Status = Status.Active;
            CreatedDate = DateTime.Now;
            CreatedComputerName = Environment.MachineName;
            CreatedAdUserName = WindowsIdentity.GetCurrent().Name;
            CreatedBy = "varsayılan";
            CreatedIP = "192.168.1.1";
        }
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public int? MasterId { get; set; } = 1;
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }

        //[Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz!."), StringLength(30)]
        public string CreatedIP { get; set; }

        //[Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz!."), StringLength(50)]
        public string CreatedAdUserName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedIP { get; set; }
        public string UpdatedAdUserName { get; set; }
        public string UpdatedBy { get; set; }
        

    }
}
