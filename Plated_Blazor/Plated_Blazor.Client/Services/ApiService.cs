using Plated_Blazor.Client.Models;
using System.Net.Http.Json;

namespace Plated_Blazor.Client.Services;

public class ApiService: IApiService
{
    private readonly HttpClient _httpClient;
    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task PostRecipe(Recipe recipe)
    {
        await _httpClient.PostAsJsonAsync<Recipe>("api/recipe", recipe);
    }
}
