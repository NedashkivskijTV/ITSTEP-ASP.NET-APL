using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class Stadium
    {
        public int StadiumId { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [Display(Name = "Stadium")]
        public string StadiumName { get; set; }

        [Display(Name = "Description")]
        public string StadiumDescription { get; set; }

        [Display(Name = "Town")]
        public int? TownId { get; set; } // int? - поле не обовязкове для заповнення - може бути null (нулабл) - у контроллері потрібно перевіряти дане поле на null
        public Town Town { get; set; } // навігаційна властивість
    }
}
