﻿namespace Restaurant.Models;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public double Price { get; set; }

    public List<DishIngredient>? DishIngredient { get; set; }

}
