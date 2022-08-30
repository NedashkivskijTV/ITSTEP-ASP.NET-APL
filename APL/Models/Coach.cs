using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APL.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [StringLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        [Display(Name = "Surname")] // Атрибут Display указывает, что заголовки для текстовых полей должны иметь иной вид
        //[Column("Surname")]
        public string CoachSurname { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [StringLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        [Display(Name = "Name")]
        //[Column("Name")]
        public string CoachName { get; set; }

        //[Column("Patronymic")]
        [StringLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        [Display(Name = "Patronymic")]
        public string CoachPatronymic { get; set; }

        //[DataType(DataType.Date)] // Атрибут DataType используется для указания типа данных, который является более конкретным, чем встроенный тип базы данных. В этом случае требуется отслеживать только дату, а не дату и время.
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] //С помощью атрибута DisplayFormat можно явно указать формат даты. Параметр ApplyFormatInEditMode указывает, что указанное форматирование также должно применяться при отображении значения в текстовом поле для редактирования.
        [Display(Name = "Date of birth")]
        //[Column("Date of birth")]
        public DateTime CoachBirthday { get; set; }

        [Required(ErrorMessage = "- Field is required")] // виводить текст помилки, введений у рядку
        [StringLength(1000, ErrorMessage = "Field cannot be longer than 1000 characters.")]
        [Display(Name = "Description")]
        //[Column("Description")]
        public string CoachDescription { get; set; }

        //[Column("Photo")]
        [Display(Name = "Photo")]
        public string CoachPhoto { get; set; }


        [Display(Name = "Full Name")]
        public string CoachFullName //  это вычисляемое свойство, которое возвращает значение, созданное путем объединения двух других свойств. Таким образом, он имеет только get метод доступа, и в базе данных не FullName будет создан столбец.
        {
            get
            {
                return CoachSurname + " " + CoachName + " " + CoachPatronymic;
            }
        }

        /*public string CoachBd()
        {
            return CoachBirthday.ToShortDateString();
        }*/
    }
}
