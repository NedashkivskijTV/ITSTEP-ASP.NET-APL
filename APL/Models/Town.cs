using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class Town
    {
        public int TownId { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [Display(Name = "City")]
        public string TownName { get; set; }

        [StringLength(500, ErrorMessage = "Field cannot be longer than 500 characters.")]
        [Display(Name = "Description")]
        public string TownDescription { get; set; }
    }
}
