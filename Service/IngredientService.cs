using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Service;

public class IngredientService : IIngredientService
{
    private readonly RestaurantContext _context;
    public IngredientService(RestaurantContext context)
    {
        _context = context;
    }
    public async Task<Ingredient> CreateIngredient(IngredientViewModel ingredient)
    {
        var model = new Ingredient
        {
            Name = ingredient.Name
        };
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<IngredientViewModel?> GetIngredient(int id)
    {
        var ingredient = await _context.Ingredients.Where(e => e.Id == id).Select(e => new IngredientViewModel
        {
            Id = e.Id,
            Name = e.Name
        }).FirstOrDefaultAsync();
        return ingredient;
    }

    public async Task<List<IngredientViewModel>> GetIngredients()
    {
        var ingredients = await _context.Ingredients.Select(e=>new IngredientViewModel
        {
            Id = e.Id,
            Name = e.Name
        }).ToListAsync();
        return ingredients;
    }
}
