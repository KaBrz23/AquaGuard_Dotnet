using AquaGuard_Dotnet.Data;
using AquaGuard_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaGuard_Dotnet.Controllers;

public class RelatorioController : Controller
{
    private readonly DataContext _dataContext;

    public RelatorioController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _dataContext.TabelaRelatorio.ToListAsync());
    }
        
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var relatorio = await _dataContext.TabelaRelatorio
            .FirstOrDefaultAsync(m => m.Id == id);
        if (relatorio == null)
        {
            return NotFound();
        }

        return View(relatorio);
    }
        
    public IActionResult Create()
    {
        return View();
    }
        
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,descricao,userId")] Relatorio relatorio)
    {
        if (ModelState.IsValid)
        {
            _dataContext.Add(relatorio);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(relatorio);
    }
}