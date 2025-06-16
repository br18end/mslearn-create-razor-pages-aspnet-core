using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Display(Name = "Size")]
    public PizzaSize Size { get; set; }

    [Display(Name = "Is Gluten Free?")]
    public bool IsGlutenFree { get; set; }

    [Range(0.01, 9999.99)]
    [Column(TypeName = "decimal(18, 2)")]
    [Display(Name = "Price")]
    public decimal Price { get; set; }
}

public enum PizzaSize { Small, Medium, Large }