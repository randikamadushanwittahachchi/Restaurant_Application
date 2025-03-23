using Microsoft.AspNetCore.Mvc;
using Restaurant.Service;
using Restaurant.ViewModels;

namespace Restaurant.Controllers;

public class DishController : Controller
{
    private readonly IDishService _dishService;
    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dishes = await _dishService.GetDishes();
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
