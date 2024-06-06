using AquaGuard_Dotnet.Data;
using AquaGuard_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaGuard_Dotnet.Controllers;

public class TilapiaController : Controller
{
    private readonly DataContext _dataContext;

    public TilapiaController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _dataContext.TabelaTilapia.ToListAsync());
    }
        
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tilapia = await _dataContext.TabelaTilapia
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tilapia == null)
        {
            return NotFound();
        }

        return View(tilapia);
    }
        
    public IActionResult Create()
    {
        return View();
    }
        
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,isDoente,data,tanqueId")] Tilapia tilapia)
    {
        if (ModelState.IsValid)
        {
            _dataContext.Add(tilapia);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tilapia);
    }
}