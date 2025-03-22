using Microsoft.AspNetCore.Mvc;
using Restaurant.Service;
using Restaurant.ViewModels;

namespace Restaurant.Controllers;

public class DishController : Controller
{
    private readonly IDishService _dishService;
    private readonly IIngredientService _ingredientService;
    public DishController(IDishService dishService,IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dishes = await _dishService.GetDishes();
        ViewData["ingredients"] = _ingredientService.GetIngredients();
        return View(dishes);
    }

    [HttpGet("Dish/Detail/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        var dish = await _dishService.GetDish(id);
        if (dish == null)
        {
            return NotFound();
        }
        return View(dish);
    }

    [HttpGet("Dish/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Dish/Create")]
    public async Task<IActionResult> Create(DishViewModel dish)
    {
        if (ModelState.IsValid)
        {
            await _dishService.CreateDish(dish);
            return RedirectToAction("Index" , "Dish");
        }
        return View(dish);
    }

}
