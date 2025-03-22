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
        return await _context.Dishes.Where(d=>d.Id==id).Select(d=>new DishViewModel
        {
            Id = d.Id,
            Name = d.Name,
            Price = d.Price,
            ImageUrl = d.ImageUrl
        }).FirstOrDefaultAsync();
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
