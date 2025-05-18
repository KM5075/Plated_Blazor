using Plated_Blazor.Client.Models;
using Plated_Blazor.Client.Services;

namespace Plated_Blazor.Services;

public class DummyApiService : IApiService
{
    public Task PostRecipe(Recipe recipe)
    {
        // Dummy側は何もしない  
        return Task.CompletedTask;
    }
}
