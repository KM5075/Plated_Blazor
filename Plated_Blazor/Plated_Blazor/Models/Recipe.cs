namespace Plated_Blazor.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string CategoryColor { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
