using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Service;

public interface IIngredientService
{
    Task<List<IngredientViewModel>> GetIngredients();
    Task<IngredientViewModel?> GetIngredient(int id);
    Task<Ingredient> CreateIngredient(IngredientViewModel ingredient);
}
