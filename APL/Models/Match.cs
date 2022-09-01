using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class Match
    {
        public int MatchId { get; set; }


        [Required(ErrorMessage = "- Field is required")]
        [Display(Name = "Match Date")]
        public DateTime MatchDate { get; set; }


        //[ForeignKey("HomeClub")]
        [Required(ErrorMessage = "- Field is required")]
        [Display(Name = "Home Club")]
        public int HomeClubId { get; set; }
        //public Club HomeClub { get; set; } // навігаційна властивість

        //[ForeignKey("AwayClub")]
        [Required(ErrorMessage = "- Field is required")]
        [Display(Name = "Away Club")]
        public int AwayClubId { get; set; }
        //public Club AwayClub { get; set; } // навігаційна властивість


        [Display(Name = "Match Town")]
        public int? TownId { get; set; } // int? - поле не обовязкове для заповнення - може бути null (нулабл) - у контроллері потрібно перевіряти дане поле на null
        public Town Town { get; set; } // навігаційна властивість

        [Display(Name = "Match Stadium")]
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; } // навігаційна властивість

        // /((\d+)(:)(\d+))
        // /([0-9]+:[0-9]+)/g
        [RegularExpression(@"/([0-9]+:[0-9]+)")]
        [Display(Name = "Match Result")]
        public string MatchResult { get; set; }

        [Display(Name = "Match Description")]
        public string MatchDescription { get; set; }

        [Display(Name = "Match status")]
        public bool MatchIsOver { get; set; } = false;

    }
}
