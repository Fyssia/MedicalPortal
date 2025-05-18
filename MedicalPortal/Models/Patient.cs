using System.ComponentModel.DataAnnotations;

namespace MedicalPortal.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Display(Name = "Диагноз")]
        public string Diagnosis { get; set; }
    }
}