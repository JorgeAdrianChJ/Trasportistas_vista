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
    public class ArticuloCustodiasController : Controller
    {
        private readonly BD_TRASPORTISTASContext _context;

        public ArticuloCustodiasController(BD_TRASPORTISTASContext context)
        {
            _context = context;
        }

        // GET: ArticuloCustodiums
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();

            ViewBag.Clientes = new SelectList(clientes, "Id", "Codigo");

            var trasportistas = await _context.Trasportista.ToListAsync();

            ViewBag.Trasportistas = new SelectList(trasportistas, "Id", "Codigo");

            return _context.ArticuloCustodia != null ?
                        View(await _context.ArticuloCustodia.ToListAsync()) :
                        Problem("Entity set 'BD_TRASPORTISTASContext.ArticuloCustodia'  is null.");
        }

        // GET: ArticuloCustodiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArticuloCustodia == null)
            {
                return NotFound();
            }

            var articuloCustodium = await _context.ArticuloCustodia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articuloCustodium == null)
            {
                return NotFound();
            }

            return View(articuloCustodium);
        }

        // GET: ArticuloCustodiums/Create
        public async Task<IActionResult> Create()
        {
            var clientes = await _context.Clientes.ToListAsync();

            ViewBag.Clientes = new SelectList(clientes, "Id", "Codigo");

            var trasportistas =await _context.Trasportista.ToListAsync();

            ViewBag.Trasportistas = new SelectList(trasportistas, "Id", "Codigo");
            return View();
        }

        // POST: ArticuloCustodiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrasportistaCodigo,TrakingId,Descripcion,Peso,Precio,ClienteCodigo,FechaIngreso")] ArticuloCustodium articuloCustodium)
        {
            var clientes = await _context.Clientes.ToListAsync();

            ViewBag.Clientes = new SelectList(clientes, "Id", "Codigo");

            var trasportistas = await _context.Trasportista.ToListAsync();

            ViewBag.Trasportistas = new SelectList(trasportistas, "Id", "Codigo");

            if (ModelState.IsValid)
            {
                _context.Add(articuloCustodium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
 
            return View(articuloCustodium);
        }

        // GET: ArticuloCustodiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var clientes = await _context.Clientes.ToListAsync();

            ViewBag.Clientes = new SelectList(clientes, "Id", "Codigo");

            var trasportistas = await _context.Trasportista.ToListAsync();

            ViewBag.Trasportistas = new SelectList(trasportistas, "Id", "Codigo");
            if (id == null || _context.ArticuloCustodia == null)
            {
                return NotFound();
            }

            var articuloCustodium = await _context.ArticuloCustodia.FindAsync(id);
            if (articuloCustodium == null)
            {
                return NotFound();
            }
            return View(articuloCustodium);
        }

        // POST: ArticuloCustodiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrasportistaCodigo,TrakingId,Descripcion,Peso,Precio,ClienteCodigo,FechaIngreso")] ArticuloCustodium articuloCustodium)
        {
            var clientes = await _context.Clientes.ToListAsync();

            ViewBag.Clientes = new SelectList(clientes, "Id", "Codigo");

            var trasportistas = await _context.Trasportista.ToListAsync();

            ViewBag.Trasportistas = new SelectList(trasportistas, "Id", "Codigo");
            if (id != articuloCustodium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articuloCustodium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloCustodiumExists(articuloCustodium.Id))
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
            return View(articuloCustodium);
        }

        // GET: ArticuloCustodiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var clientes = await _context.Clientes.ToListAsync();

            ViewBag.Clientes = new SelectList(clientes, "Id", "Codigo");

            var trasportistas = await _context.Trasportista.ToListAsync();

            ViewBag.Trasportistas = new SelectList(trasportistas, "Id", "Codigo");
            if (id == null || _context.ArticuloCustodia == null)
            {
                return NotFound();
            }

            var articuloCustodium = await _context.ArticuloCustodia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articuloCustodium == null)
            {
                return NotFound();
            }

            return View(articuloCustodium);
        }

        // POST: ArticuloCustodiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArticuloCustodia == null)
            {
                return Problem("Entity set 'BD_TRASPORTISTASContext.ArticuloCustodia'  is null.");
            }
            var articuloCustodium = await _context.ArticuloCustodia.FindAsync(id);
            if (articuloCustodium != null)
            {
                _context.ArticuloCustodia.Remove(articuloCustodium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloCustodiumExists(int id)
        {
            return (_context.ArticuloCustodia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
