using Microsoft.AspNetCore.Mvc;
using Restaurant.Exceptions;
using Restaurant.Service;
using Restaurant.ViewModels;
using System.Threading.Tasks;

namespace Restaurant.Controllers;

public class IngredientController : Controller
{
    private readonly IIngredientService _ingredientService;
    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    //[HttpGet("Ingredient/Detail/{id}")]
    //public async Task<IActionResult> Detail(int id)
    //{
    //    var  ingredient = await _ingredientService.GetIngredient(id);
    //    if (ingredient == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(ingredient);
    //}

    [HttpGet("Ingredient/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Ingredient/Create")]
    public async Task<IActionResult> Create(IngredientViewModel ingredient)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _ingredientService.CreateIngredient(ingredient);
                return RedirectToAction("Index", "Dish");
            }
            return View(ingredient);
        }
        catch (DuplicateExeception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("Index", "Dish");
        }
    }
    [HttpGet]
    public async Task<JsonResult> SearchIngredient(string name)
    {
        var ingredients = await _ingredientService.SearchIngredient(name);
        return Json(ingredients);
    }
}
