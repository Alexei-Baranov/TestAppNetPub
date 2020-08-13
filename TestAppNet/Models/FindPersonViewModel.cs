using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;

namespace TestAppNet.Models
{
    public class FindPersonViewModel
    {
        [Required(ErrorMessage = "Не указана фамилия")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime DateOfBirt { get; set; }

        [Required(ErrorMessage = "Не указан СНИЛС")]
        [RegularExpression("^\\d{3}-\\d{3}-\\d{3} \\d{2}$")]
        public string SNILS { get; set; }
    }
}