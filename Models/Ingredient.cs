namespace Restaurant.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<DishIngredient> DishIngredient { get; set; } = null!;
}
