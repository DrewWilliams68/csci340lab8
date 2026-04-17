using System.ComponentModel.DataAnnotations;

namespace RazorPagesGames.Models;

public class Games
{
    public int Id { get; set; }
    public string? GameTitle { get; set; }
    public decimal Price { get; set; }
    public string? SoldCopies { get; set; }
    public string? Type { get; set; }
    public string? SkillLevel { get; set; }
}