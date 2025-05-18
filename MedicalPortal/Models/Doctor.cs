using System.ComponentModel.DataAnnotations;

public class Doctor
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "ФИО врача")]
    public string FullName { get; set; }

    [Display(Name = "Специализация")]
    public string Specialization { get; set; }

    [Display(Name = "Стаж (лет)")]
    public int Experience { get; set; }
}