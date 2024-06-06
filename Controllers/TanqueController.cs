using AquaGuard_Dotnet.Data;
using AquaGuard_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaGuard_Dotnet.Controllers;

public class TanqueController : Controller
{
    private readonly DataContext _dataContext;
    public TanqueController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.TabelaTanque.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanque = await _dataContext.TabelaTanque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tanque == null)
            {
                return NotFound();
            }

            return View(tanque);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,hasFissuras,data,userId")] Tanque tanque)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(tanque);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tanque);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanque = await _dataContext.TabelaTanque.FindAsync(id);
            if (tanque == null)
            {
                return NotFound();
            }
            return View(tanque);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,hasFissuras,data,userId")] Tanque tanque)
        {
            if (id != tanque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(tanque);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TanqueExists(tanque.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tanque);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanque = await _dataContext.TabelaTanque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tanque == null)
            {
                return NotFound();
            }

            return View(tanque);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tanque = await _dataContext.TabelaTanque.FindAsync(id);
            if (tanque != null)
            {
                _dataContext.TabelaTanque.Remove(tanque);
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TanqueExists(int id)
        {
            return _dataContext.TabelaTanque.Any(e => e.Id == id);
        } 
}