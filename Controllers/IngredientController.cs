using Microsoft.AspNetCore.Mvc;
using Restaurant.Service;

namespace Restaurant.Controllers;

public class IngredientController : Controller
{
    private readonly IIngredientService _ingredientService;
    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
