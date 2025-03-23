using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Exceptions;
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
        string name = ingredient.Name.Trim().ToLower();
        bool isExit = await _context.Ingredients.AnyAsync(e => e.Name == name);
        if (isExit)
        {
            throw new DuplicateExeception("Ingredient Alredy Exist");
        }
        var model = new Ingredient
        {
            Name = ingredient.Name
        };
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    //public async Task<IngredientViewModel?> GetIngredient(int id)
    //{
    //    var ingredient = await _context.Ingredients.Where(e => e.Id == id).Select(e => new IngredientViewModel
    //    {
    //        Id = e.Id,
    //        Name = e.Name
    //    }).FirstOrDefaultAsync();
    //    return ingredient;
    //}

    //public async Task<List<IngredientViewModel>> GetIngredients()
    //{
    //    var ingredients = await _context.Ingredients.Select(e=>new IngredientViewModel
    //    {
    //        Id = e.Id,
    //        Name = e.Name
    //    }).ToListAsync();
    //    return ingredients;
    //}

    public async Task<List<IngredientViewModel>?> SearchIngredient(string name)
    {
        var ingredients = await  _context.Ingredients.Where(e=>e.Name.Contains(name)).Select(name=>new IngredientViewModel
        {
            Id = name.Id,
            Name = name.Name
        }).ToListAsync();
        return ingredients;
    }
}
