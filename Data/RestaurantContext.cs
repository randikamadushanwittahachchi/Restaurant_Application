using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredient>().HasKey(di => new 
        {
            di.DishId, 
            di.IngredientId 
        });

        modelBuilder.Entity<DishIngredient>()
            .HasOne(d=> d.Dish).WithMany(di => di.DishIngredient).HasForeignKey(d => d.DishId);
        modelBuilder.Entity<DishIngredient>()
            .HasOne(i => i.Ingredient).WithMany(di => di.DishIngredient).HasForeignKey(i => i.IngredientId);

        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, Name = "Pizza", Price = 12.50, ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.stockfood.com%2Fimages%2F00955009-Cheese-and-tomato-pizza-with-oregano-quartered&psig=AOvVaw3rhizAmHqsaRK3GL0YfEsP&ust=1742597380576000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCMjBp6ffmYwDFQAAAAAdAAAAABAQ" });

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Cheese" },
            new Ingredient { Id = 2, Name = "Tomato" });

        modelBuilder.Entity<DishIngredient>().HasData(
            new DishIngredient { DishId = 1, IngredientId = 1 },
            new DishIngredient { DishId = 1, IngredientId = 2 });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Dish> Dishes { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<DishIngredient> DishIngredients { get; set; } = null!;

}
