using Microsoft.EntityFrameworkCore;
using Plated_Blazor.Client.Models;

namespace Plated_Blazor.Data;

public class Planted_BlazorContext: DbContext
{
    public Planted_BlazorContext(DbContextOptions<Planted_BlazorContext> options)
        : base(options)
    {
    }
    public DbSet<Recipe> Recipes { get; set; } = default!;
}
