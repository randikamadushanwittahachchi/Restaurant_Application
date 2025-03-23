using Restaurant.Models;

namespace Restaurant.ViewModels;

public class IngredientViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<DishIngredient>? DishIngredients { get; set; }
    public List<DishViewModel>? Dishs { get; set; }
}
