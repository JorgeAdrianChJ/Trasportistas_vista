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
    public class ArticuloRetiradoesController : Controller
    {
        private readonly BD_TRASPORTISTASContext _context;

        public ArticuloRetiradoesController(BD_TRASPORTISTASContext context)
        {
            _context = context;
        }

        // GET: ArticuloRetiradoes
        public async Task<IActionResult> Index()
        {
            return _context.ArticuloRetirados != null ?
                        View(await _context.ArticuloRetirados.ToListAsync()) :
                        Problem("Entity set 'BD_TRASPORTISTASContext.ArticuloRetirados'  is null.");
        }

        // GET: ArticuloRetiradoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArticuloRetirados == null)
            {
                return NotFound();
            }

            var articuloRetirado = await _context.ArticuloRetirados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articuloRetirado == null)
            {
                return NotFound();
            }

            return View(articuloRetirado);
        }

        // GET: ArticuloRetiradoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticuloRetiradoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrasportistaCodigo,TrakingId,Descripcion,ClienteCodigo,FechaRetiro")] ArticuloRetirado articuloRetirado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articuloRetirado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articuloRetirado);
        }

        // GET: ArticuloRetiradoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArticuloRetirados == null)
            {
                return NotFound();
            }

            var articuloRetirado = await _context.ArticuloRetirados.FindAsync(id);
            if (articuloRetirado == null)
            {
                return NotFound();
            }
            return View(articuloRetirado);
        }

        // POST: ArticuloRetiradoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrasportistaCodigo,TrakingId,Descripcion,ClienteCodigo,FechaRetiro")] ArticuloRetirado articuloRetirado)
        {
            if (id != articuloRetirado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articuloRetirado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloRetiradoExists(articuloRetirado.Id))
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
            return View(articuloRetirado);
        }

        // GET: ArticuloRetiradoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArticuloRetirados == null)
            {
                return NotFound();
            }

            var articuloRetirado = await _context.ArticuloRetirados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articuloRetirado == null)
            {
                return NotFound();
            }

            return View(articuloRetirado);
        }

        // POST: ArticuloRetiradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArticuloRetirados == null)
            {
                return Problem("Entity set 'BD_TRASPORTISTASContext.ArticuloRetirados'  is null.");
            }
            var articuloRetirado = await _context.ArticuloRetirados.FindAsync(id);
            if (articuloRetirado != null)
            {
                _context.ArticuloRetirados.Remove(articuloRetirado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloRetiradoExists(int id)
        {
            return (_context.ArticuloRetirados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
