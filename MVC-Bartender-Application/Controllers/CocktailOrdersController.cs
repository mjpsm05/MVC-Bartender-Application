using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Bartender_Application.Data;
using MVC_Bartender_Application.Models;

namespace MVC_Bartender_Application.Controllers;

public class CocktailOrdersController :  Controller
{
    private readonly ApplicationDbContext _context;

    public CocktailOrdersController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Menu()
    {
        var cocktails = await _context.Cocktails.ToListAsync();

        return View(cocktails);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int cocktailId)
    {
        var cocktail = await _context.Cocktails.FindAsync(cocktailId);

        if (cocktail == null)
        {
            return NotFound();
        }

        var order = new CocktailOrder
        {
            CocktailId = cocktailId,
            Status = "Pending",
            OrderTime = DateTime.Now
        };

        _context.CocktailOrders.Add(order);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Menu));
    }
    
    public async Task<IActionResult> Queue()
    {
        var orders = await _context.CocktailOrders
            .Include(o => o.Cocktail)
            .OrderBy(o => o.OrderTime)
            .ToListAsync();

        return View(orders);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MarkReady(int id)
    {
        var order = await _context.CocktailOrders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        order.Status = "Ready for Pickup";

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Queue));
    }
}