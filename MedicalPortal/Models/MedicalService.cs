using System.ComponentModel.DataAnnotations;

public class MedicalService
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Название услуги")]
    public string Name { get; set; }

    [Display(Name = "Описание")]
    public string Description { get; set; }

    [Display(Name = "Стоимость (руб)")]
    public decimal Price { get; set; }
}