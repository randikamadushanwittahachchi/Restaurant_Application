﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Data;

#nullable disable

namespace Restaurant.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restaurant.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dish");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.stockfood.com%2Fimages%2F00955009-Cheese-and-tomato-pizza-with-oregano-quartered&psig=AOvVaw3rhizAmHqsaRK3GL0YfEsP&ust=1742597380576000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCMjBp6ffmYwDFQAAAAAdAAAAABAQ",
                            Name = "Pizza",
                            Price = 12.5
                        });
                });

            modelBuilder.Entity("Restaurant.Models.DishIngredient", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredient");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            IngredientId = 1
                        },
                        new
                        {
                            DishId = 1,
                            IngredientId = 2
                        });
                });

            modelBuilder.Entity("Restaurant.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tomato"
                        });
                });

            modelBuilder.Entity("Restaurant.Models.DishIngredient", b =>
                {
                    b.HasOne("Restaurant.Models.Dish", "Dish")
                        .WithMany("DishIngredient")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Models.Ingredient", "Ingredient")
                        .WithMany("DishIngredient")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Restaurant.Models.Dish", b =>
                {
                    b.Navigation("DishIngredient");
                });

            modelBuilder.Entity("Restaurant.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredient");
                });
#pragma warning restore 612, 618
        }
    }
}
