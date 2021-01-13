using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.ViewModels.AppUserVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunlu!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre zorunlu!")]
        public string Password { get; set; }
        //public string Role
        //{
        //    get
        //    {
        //        new string="Finans",""
        //    }
        //}
    }
}
