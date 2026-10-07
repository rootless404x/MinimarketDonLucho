using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimarketDonLucho.Data;
using MinimarketDonLucho.Models;

namespace MinimarketDonLucho.Controllers;

public class CategoriasController : Controller
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Categorias
    public async Task<IActionResult> Index()
    {
        var categorias = await _context.Categorias
            .Include(c => c.Productos)
            .OrderBy(c => c.Nombre)
            .ToListAsync();

        return View(categorias);
    }

    // GET: Categorias/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categorias/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nombre")] Categoria categoria)
    {
        if (!ModelState.IsValid)
        {
            return View(categoria);
        }

        _context.Add(categoria);
        await _context.SaveChangesAsync();
        TempData["Mensaje"] = "Categoría registrada correctamente.";
        return RedirectToAction(nameof(Index));
    }
}
