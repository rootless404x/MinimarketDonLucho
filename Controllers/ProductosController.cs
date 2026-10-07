using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinimarketDonLucho.Data;
using MinimarketDonLucho.Models;

namespace MinimarketDonLucho.Controllers;

public class ProductosController : Controller
{
    private readonly AppDbContext _context;

    public ProductosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Productos
    public async Task<IActionResult> Index(string? buscar)
    {
        var productos = _context.Productos
            .Include(p => p.Categoria)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            productos = productos.Where(p => p.Nombre.Contains(buscar));
        }

        ViewBag.Buscar = buscar;
        return View(await productos.OrderBy(p => p.Nombre).ToListAsync());
    }

    // GET: Productos/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var producto = await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // GET: Productos/Create
    public IActionResult Create()
    {
        CargarCategorias();
        return View();
    }

    // POST: Productos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {
        _context.Add(producto);
        await _context.SaveChangesAsync();
        TempData["Exito"] = "Producto registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    // GET: Productos/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        CargarCategorias(producto.CategoriaId);
        return View(producto);
    }

    // POST: Productos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Stock,CategoriaId")] Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
            TempData["Mensaje"] = "Producto actualizado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        CargarCategorias(producto.CategoriaId);
        return View(producto);
    }

    // GET: Productos/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        TempData["Mensaje"] = "Producto eliminado.";
        return RedirectToAction(nameof(Index));
    }

    private void CargarCategorias(int? seleccionada = null)
    {
        ViewData["CategoriaId"] = new SelectList(
            _context.Categorias.OrderBy(c => c.Nombre), "Id", "Nombre", seleccionada);
    }
}
