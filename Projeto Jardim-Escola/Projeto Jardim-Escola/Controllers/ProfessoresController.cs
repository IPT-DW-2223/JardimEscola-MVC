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
    public class ProfessoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Professores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Professores.Include(p => p.TipoIdentificacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Professores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professores = await _context.Professores
                .Include(p => p.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professores == null)
            {
                return NotFound();
            }

            return View(professores);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome");
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Telemovel,Email,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Professores professores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome", professores.TipoIdentificacaoFK);
            return View(professores);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professores = await _context.Professores.FindAsync(id);
            if (professores == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome", professores.TipoIdentificacaoFK);
            return View(professores);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Telemovel,Email,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Professores professores)
        {
            if (id != professores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessoresExists(professores.Id))
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
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome", professores.TipoIdentificacaoFK);
            return View(professores);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Professores == null)
            {
                return NotFound();
            }

            var professores = await _context.Professores
                .Include(p => p.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professores == null)
            {
                return NotFound();
            }

            return View(professores);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Professores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Professores'  is null.");
            }
            var professores = await _context.Professores.FindAsync(id);
            if (professores != null)
            {
                _context.Professores.Remove(professores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessoresExists(int id)
        {
          return _context.Professores.Any(e => e.Id == id);
        }
    }
}
