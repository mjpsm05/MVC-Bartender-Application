namespace MVC_Bartender_Application.Models;

public class CocktailOrder
{
    public int Id { get; set; }

    public int CocktailId { get; set; }

    public Cocktail? Cocktail { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime OrderTime { get; set; } = DateTime.Now;
}