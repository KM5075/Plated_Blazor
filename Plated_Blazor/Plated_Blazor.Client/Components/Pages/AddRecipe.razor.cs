using Microsoft.AspNetCore.Components;
using Plated_Blazor.Client.Models;
using Plated_Blazor.Client.Services;
using System.Net.Http.Json;

namespace Plated_Blazor.Client.Components.Pages;

public partial class AddRecipe
{
    [Inject] public HttpClient HttpClient { get; set; } = default!;
    [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    [Inject] public IApiService ApiService { get; set; } = default!;

    public Recipe newRecipe = new Recipe();

    public List<string> materials = new List<string>();

    public string newMaterial = string.Empty;

    public string error = string.Empty;

    public void RedirectToHome()
    {
        NavigationManager.NavigateTo("/");
    }

    public async Task AddRecipePage()
    {
        try
        {
            newRecipe.Id = 0;
            newRecipe.CategoryColor = SetColor(newRecipe.Category);
            newRecipe.ImageUrl = GetImagePath(newRecipe.Category);

            await ApiService.PostRecipe(newRecipe);
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            error = $"Error: {e.Message}.Please reflash.";
        }
    }

    private void AddMaterial()
    {
        if (string.IsNullOrWhiteSpace(newMaterial)) { return; }
        materials.Add(newMaterial);
        newRecipe.Material = string.Join('$', materials);
        newMaterial = string.Empty;
    }

    private string SetColor(string category)
    {
        return category switch
        {
            "Pasta" => "teal",
            "Curry" => "blue",
            "Pizza" => "red",
            "Salad" => "green",
            _ => throw new ArgumentException("Invalid category")
        };
    }

    private string GetImagePath(string category)
    {
        return category switch
        {
            "Pasta" => "./Images/Pasta.png",
            "Curry" => "./Images/Curry.png",
            "Pizza" => "./Images/Pizza.png",
            "Salad" => "./Images/Salad.png",
            _ => throw new ArgumentException("Invalid category")
        };
    }
}
