using Microsoft.AspNetCore.Http.HttpResults;
using Plated_Blazor.Data;
using Plated_Blazor.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace Plated_Blazor.Endpoints;
public static class RecipeItemEndpoints
{
    public static void MapRecipeItemEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/recipe", AddRecipeItems);
    }

    public static async Task<Results<Created<Recipe>, BadRequest<string>>> AddRecipeItems(Recipe recipe, Planted_BlazorContext context)
    {
        try
        {
            context.Recipes.Add(recipe);
            await context.SaveChangesAsync();
            return TypedResults.Created($"/api/recipeitems/{recipe.Id}", recipe);
        }
        catch (DbUpdateException ex)
        {
            return TypedResults.BadRequest(ex.InnerException?.Message);
        }
    }
}
