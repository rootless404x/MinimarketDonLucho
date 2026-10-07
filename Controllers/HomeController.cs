using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimarketDonLucho.Data;

namespace MinimarketDonLucho.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.TotalProductos = await _context.Productos.CountAsync();
        ViewBag.TotalCategorias = await _context.Categorias.CountAsync();
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
