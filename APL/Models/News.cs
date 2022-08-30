using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class News
    {
        public int NewsId { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [Display(Name = "Title")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [Display(Name = "News Text")]
        public string NewsText { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [Display(Name = "Author")]
        public string NewsAuthor { get; set; }

        [Display(Name = "News Image")]
        public string NewsImage{ get; set; }

        [Display(Name = "Date of creation")]
        public DateTime NewsCreationDate { get; set; } = DateTime.Now;
    }
}
