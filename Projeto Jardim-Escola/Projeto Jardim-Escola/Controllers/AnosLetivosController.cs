using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;

namespace Projeto_Jardim_Escola.Controllers
{
    public class AnosLetivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnosLetivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnosLetivos
        public async Task<IActionResult> Index()
        {
              return View(await _context.AnosLetivos.ToListAsync());
        }

        // GET: AnosLetivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnosLetivos == null)
            {
                return NotFound();
            }

            var anosLetivos = await _context.AnosLetivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anosLetivos == null)
            {
                return NotFound();
            }

            return View(anosLetivos);
        }

        // GET: AnosLetivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnosLetivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnoLetivo")] AnosLetivos anosLetivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anosLetivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anosLetivos);
        }

        // GET: AnosLetivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnosLetivos == null)
            {
                return NotFound();
            }

            var anosLetivos = await _context.AnosLetivos.FindAsync(id);
            if (anosLetivos == null)
            {
                return NotFound();
            }
            return View(anosLetivos);
        }

        // POST: AnosLetivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnoLetivo")] AnosLetivos anosLetivos)
        {
            if (id != anosLetivos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anosLetivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnosLetivosExists(anosLetivos.Id))
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
            return View(anosLetivos);
        }

        // GET: AnosLetivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnosLetivos == null)
            {
                return NotFound();
            }

            var anosLetivos = await _context.AnosLetivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anosLetivos == null)
            {
                return NotFound();
            }

            return View(anosLetivos);
        }

        // POST: AnosLetivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnosLetivos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnosLetivos'  is null.");
            }
            var anosLetivos = await _context.AnosLetivos.FindAsync(id);
            if (anosLetivos != null)
            {
                _context.AnosLetivos.Remove(anosLetivos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnosLetivosExists(int id)
        {
          return _context.AnosLetivos.Any(e => e.Id == id);
        }
    }
}
