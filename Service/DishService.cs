using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Linq;
using System.Security.AccessControl;

namespace Restaurant.Service;

public class DishService : IDishService
{
    private readonly RestaurantContext _context;

    public DishService(RestaurantContext context)
    {
        _context = context;
    }

    public async Task<Dish> CreateDish(DishViewModel dish)
    {

        var model = new Dish
        {
            Name = dish.Name,
            Price = dish.Price,
            ImageUrl = dish.ImageUrl
        };
        await _context.Dishes.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<DishViewModel?> GetDish(int id)
    {
        var dish = await _context.Dishes.Include(d => d.DishIngredients).ThenInclude(di => di.Ingredient).FirstOrDefaultAsync(d=>d.Id==id);
        if (dish == null)
        {
            return null;
        }
        var dishViewModel = new DishViewModel
        {
            Id = dish.Id,
            Name = dish.Name,
            Price = dish.Price,
            ImageUrl = dish.ImageUrl,
            Ingredients = dish.DishIngredients.Select(di => new IngredientViewModel
            {
                Id = di.Ingredient.Id,
                Name = di.Ingredient.Name
            }).ToList()
        };
        return dishViewModel;
    }

    public async Task<List<DishViewModel>> GetDishes()
    {
        var dishes = await _context.Dishes.Select(e=>new DishViewModel
        {
            Id = e.Id,
            Name = e.Name,
            Price = e.Price,
            ImageUrl = e.ImageUrl
        }).ToListAsync();
        return dishes;
    }
}
