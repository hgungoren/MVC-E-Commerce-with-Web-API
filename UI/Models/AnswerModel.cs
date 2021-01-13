using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class AnswerModel
    {
        public AppUser Email { get; set; }
        public string NameSurname { get; set; }
        public string Question { get; set; }
        public AppUser AppUser { get; set; }

        //public Answer Answer { get; set; }
    }
}