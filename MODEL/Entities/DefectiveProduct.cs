using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class DefectiveProduct : EntityRepository
    {
        [Required(ErrorMessage = "Lütfen boş bırakmayınız")]
        public string NameSurname { get; set; }
        //[Required(ErrorMessage = "Lütfen ürün seçiniz")]
        
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        //public string ImagePath { get; set; }
        [Required(ErrorMessage = "Lütfen boş bırakmayınız")]
        public string Description { get; set; }
        [EmailAddress(ErrorMessage = "Email geçersiz!!")]
        [Required(ErrorMessage = "Lütfen boş bırakmayınız")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayınız")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayınız")]
        public string IbanNo { get; set; }
        public DateTime Date { get; set; }
        //public Supplier Supplier { get; set; }

    }
}
