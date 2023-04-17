using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DragonCity.Models;
using DragonCity.Services;
namespace DragonCity.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDragonService _DragonService;
    public HomeController(ILogger<HomeController> logger, IDragonService DragonService)
    {
        _logger = logger;
        _DragonService = DragonService;
    }
    public IActionResult Index(string tipo)
    {
        var drag = _DragonService.GetDragonCityDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(drag);
    }
    public IActionResult Details(int Numero)
    {
        var dragoes = _DragonService.GetDetailedDragoes(Numero);
        return View(dragoes);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier });
    }
}