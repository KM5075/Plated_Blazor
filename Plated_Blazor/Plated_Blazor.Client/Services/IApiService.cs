using Plated_Blazor.Client.Models;

namespace Plated_Blazor.Client.Services;

public interface IApiService
{
    Task PostRecipe(Recipe recipe);
}
