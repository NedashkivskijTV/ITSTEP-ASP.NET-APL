using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "- Field is required")]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }
        
        [Display(Name = "Photo")]
        public string PlayerPhoto { get; set; }
        
        [Display(Name = "Player Number")]
        public int PlayerNumber { get; set; }
        
        [Display(Name = "Player Position")]
        public string PlayerPosition { get; set; }

        [Display(Name = "Description")]
        public string PlayerDescription { get; set; }

        [Display(Name = "APL Club")]
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}
