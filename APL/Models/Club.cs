using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class Club
    {
        public int Id { get; set; } // поле використовується у якості праймері кей

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [StringLength(200, ErrorMessage = "CLUB name cannot be longer than 200 characters")] // максимальна довжина рядка
        public string ClubName { get; set; }

        [Required(ErrorMessage = "- Field is required")]
        public string ClubNickname { get; set; }

        [Required(ErrorMessage = "- Field is required")]
        public string ClubCrest { get; set; }

        //[Required(ErrorMessage = "- Field is required")] // закоментовано при додаванні моделі Town
        //public string ClubTown { get; set; }

        //[Required(ErrorMessage = "- Field is required")]
        //public string ClubHomeStadium { get; set; }

        public string ClubWebsite { get; set; }

        [StringLength(700, ErrorMessage = "CLUB description cannot be longer than 700 characters")] // максимальна довжина рядка
        public string ClubDescription { get; set; }

        public int CoachId { get; set; }
        public Coach Coach { get; set; } // навігаційна властивість

        //[Required(ErrorMessage = "- Field is required")]
        public int? TownId { get; set; } // int? - поле не обовязкове для заповнення - може бути null (нулабл) - у контроллері потрібно перевіряти дане поле на null
        public Town Town { get; set; } // навігаційна властивість

        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; } // навігаційна властивість
    }
}
