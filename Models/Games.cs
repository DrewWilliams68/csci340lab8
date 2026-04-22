using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesGames.Models;

public class Games
{
    public int Id { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? GameTitle { get; set; }

    [Range(0, 150)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    [Required]
    public decimal Price { get; set; }

    
    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string? SoldCopies { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Type { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? SkillLevel { get; set; }
}