using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Service;

public interface IDishService
{
    Task<List<DishViewModel>> GetDishes();
    Task<DishViewModel?> GetDish(int id);
    Task<Dish> CreateDish(DishViewModel dish);
}
