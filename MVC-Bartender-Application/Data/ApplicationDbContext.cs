using Microsoft.EntityFrameworkCore;
using MVC_Bartender_Application.Models;

namespace MVC_Bartender_Application.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cocktail> Cocktails { get; set; }
    public DbSet<CocktailOrder> CocktailOrders { get; set; }
}