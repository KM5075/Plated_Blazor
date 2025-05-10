using System.ComponentModel.DataAnnotations;

namespace Plated_Blazor.Client.Models;

public class Recipe
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; } = string.Empty;
    public string CategoryColor { get; set; } = string.Empty;
    [Required(ErrorMessage = "Material is required.")]
    public string Material { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
