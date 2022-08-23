using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trasportistas_vista.Models;

namespace Trasportistas_vista.Controllers
{
    public class TrasportistasController : Controller
    {
        // Scaffold-DbContext "Server=.;Database=BD_TRASPORTISTAS;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        // Scaffold-DbContext "Server=.;Database=BD_TRASPORTISTAS;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -tcliente -f
        private readonly BD_TRASPORTISTASContext _context;

        public TrasportistasController(BD_TRASPORTISTASContext context)
        {
            _context = context;
        }

        // GET: Trasportistums
        public async Task<IActionResult> Index()
        {
            return _context.Trasportista != null ?
                        View(await _context.Trasportista.ToListAsync()) :
                        Problem("Entity set 'BD_TRASPORTISTASContext.Trasportista'  is null.");
        }

        // GET: Trasportistums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trasportista == null)
            {
                return NotFound();
            }

            var trasportistum = await _context.Trasportista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trasportistum == null)
            {
                return NotFound();
            }

            return View(trasportistum);
        }

        // GET: Trasportistums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trasportistums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nombre")] Trasportistum trasportistum)
        {
            trasportistum.Codigo = TrasportistumTop();
            if (ModelState.IsValid)
            {
                _context.Add(trasportistum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trasportistum);
        }

        // GET: Trasportistums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trasportista == null)
            {
                return NotFound();
            }

            var trasportistum = await _context.Trasportista.FindAsync(id);
            if (trasportistum == null)
            {
                return NotFound();
            }
            return View(trasportistum);
        }

        // POST: Trasportistums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nombre")] Trasportistum trasportistum)
        {
            if (id != trasportistum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trasportistum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrasportistumExists(trasportistum.Id))
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
            return View(trasportistum);
        }

        // GET: Trasportistums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trasportista == null)
            {
                return NotFound();
            }

            var trasportistum = await _context.Trasportista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trasportistum == null)
            {
                return NotFound();
            }

            return View(trasportistum);
        }

        // POST: Trasportistums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trasportista == null)
            {
                return Problem("Entity set 'BD_TRASPORTISTASContext.Trasportista'  is null.");
            }
            var trasportistum = await _context.Trasportista.FindAsync(id);
            if (trasportistum != null)
            {
                _context.Trasportista.Remove(trasportistum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrasportistumExists(int id)
        {
            return (_context.Trasportista?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string TrasportistumTop()
        {
            var top = (_context.Trasportista.OrderByDescending(u => u.Id).Take(1).FirstOrDefault());
            if (top == null)
            {
                return "001";
            }
            var id = top.Id + 1;
            return id.ToString().PadLeft(3, '0');
        }
    }
}
