using MVC_Bartender_Application.Models;

namespace MVC_Bartender_Application.Data;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Cocktails.Any())
        {
            return;
        }

        var cocktails = new Cocktail[]
        {
            new Cocktail
            {
                Name = "Margarita",
                Description = "Tequila, lime juice, and triple sec",
                Price = 8.00m
            },
            new Cocktail
            {
                Name = "Mojito",
                Description = "Rum, mint, lime juice, and soda water",
                Price = 9.00m
            },
            new Cocktail
            {
                Name = "Old Fashioned",
                Description = "Bourbon, bitters, sugar, and orange",
                Price = 10.00m
            },
            new Cocktail
            {
                Name = "Cosmopolitan",
                Description = "Vodka, cranberry juice, lime, and triple sec",
                Price = 9.00m
            },
            new Cocktail
            {
                Name = "Piña Colada",
                Description = "Rum, coconut cream, and pineapple juice",
                Price = 9.00m
            }
        };

        context.Cocktails.AddRange(cocktails);
        context.SaveChanges();
    }
}