using CORE.CoreEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Contact: EntityRepository
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen bir konu başlığı giriniz.")]
        public string Subject { get; set; }
        //public AppUser AppUser { get; set; }
        [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz!")]
        public string Message { get; set; }
        [EmailAddress(ErrorMessage = "Email geçersiz!!")]
        [Required(ErrorMessage ="Lütfen Mail adresinizi giriniz.")]
        public string Email { get; set; }
        public DateTime Date { get; set; }

    }
}
