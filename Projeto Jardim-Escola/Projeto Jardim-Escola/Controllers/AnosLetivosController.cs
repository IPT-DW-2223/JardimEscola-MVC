using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;

namespace Projeto_Jardim_Escola.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnosLetivosController : Controller
    {
        private readonly ApplicationDbContext _baseDados;

        public AnosLetivosController(ApplicationDbContext context)
        {
            _baseDados = context;
        }

        // GET: AnosLetivos
        public async Task<IActionResult> Index()
        {
              return View(await _baseDados.AnosLetivos.ToListAsync());
        }

        // GET: AnosLetivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _baseDados.AnosLetivos == null)
            {
                return NotFound();
            }

            var anoLetivo = await _baseDados.AnosLetivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anoLetivo == null)
            {
                return NotFound();
            }

            return View(anoLetivo);
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
        public async Task<IActionResult> Create([Bind("Id,AnoLetivo")] AnoLetivo anosLetivos)
        {
            if (ModelState.IsValid)
            {
                _baseDados.Add(anosLetivos);
                await _baseDados.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anosLetivos);
        }

        // GET: AnosLetivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _baseDados.AnosLetivos == null)
            {
                return NotFound();
            }

            var anosLetivos = await _baseDados.AnosLetivos.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnoLetivo")] AnoLetivo anosLetivos)
        {
            if (id != anosLetivos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _baseDados.Update(anosLetivos);
                    await _baseDados.SaveChangesAsync();
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
            if (id == null || _baseDados.AnosLetivos == null)
            {
                return NotFound();
            }

            var anosLetivos = await _baseDados.AnosLetivos
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
            if (_baseDados.AnosLetivos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnosLetivos'  is null.");
            }
            var anosLetivos = await _baseDados.AnosLetivos.FindAsync(id);
            if (anosLetivos != null)
            {
                _baseDados.AnosLetivos.Remove(anosLetivos);
            }
            
            await _baseDados.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnosLetivosExists(int id)
        {
          return _baseDados.AnosLetivos.Any(e => e.Id == id);
        }
    }
}
