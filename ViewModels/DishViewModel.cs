namespace Restaurant.ViewModels;

public class DishViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public List<string>? Ingredients { get; set; }
    public string FormattedPrice => Price.ToString("C");

}
