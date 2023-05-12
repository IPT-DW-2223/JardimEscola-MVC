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
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _baseDados;

        public TurmasController(ApplicationDbContext context)
        {
            _baseDados = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _baseDados.Turmas.Include(t => t.AnoLetivo).Include(t => t.Professor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _baseDados.Turmas == null)
            {
                return NotFound();
            }

            var turma = await _baseDados.Turmas
                .Include(t => t.AnoLetivo)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "AnoLetivo");
            ViewData["ProfessorFK"] = new SelectList(_baseDados.Professores, "Id", "Nome");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,AnoLetivoFK,ProfessorFK")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                _baseDados.Add(turmas);
                await _baseDados.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "AnoLetivo", turmas.AnoLetivoFK);
            ViewData["ProfessorFK"] = new SelectList(_baseDados.Professores, "Id", "Nome", turmas.ProfessorFK);
            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _baseDados.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _baseDados.Turmas.FindAsync(id);
            if (turmas == null)
            {
                return NotFound();
            }
            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "AnoLetivo", turmas.AnoLetivoFK);
            ViewData["ProfessorFK"] = new SelectList(_baseDados.Professores, "Id", "Nome", turmas.ProfessorFK);
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,AnoLetivoFK,ProfessorFK")] Turmas turmas)
        {
            if (id != turmas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _baseDados.Update(turmas);
                    await _baseDados.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmasExists(turmas.Id))
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
            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "AnoLetivo", turmas.AnoLetivoFK);
            ViewData["ProfessorFK"] = new SelectList(_baseDados.Professores, "Id", "Nome", turmas.ProfessorFK);
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _baseDados.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _baseDados.Turmas
                .Include(t => t.AnoLetivo)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_baseDados.Turmas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Turmas'  is null.");
            }
            var turmas = await _baseDados.Turmas.FindAsync(id);
            if (turmas != null)
            {
                _baseDados.Turmas.Remove(turmas);
            }
            
            await _baseDados.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmasExists(int id)
        {
          return _baseDados.Turmas.Any(e => e.Id == id);
        }
    }
}
