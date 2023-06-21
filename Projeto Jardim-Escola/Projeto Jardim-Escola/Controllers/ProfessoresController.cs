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
    public class ProfessoresController : Controller
    {
        private readonly ApplicationDbContext _baseDados;

        public ProfessoresController(ApplicationDbContext context)
        {
            _baseDados = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _baseDados.Professores.Include(p => p.TipoIdentificacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _baseDados.Professores == null)
            {
                return NotFound();
            }

            var professor = await _baseDados.Professores
                .Include(p => p.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome");
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Telemovel,Email,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Professor professores)
        {
            if (ModelState.IsValid)
            {
                _baseDados.Add(professores);
                await _baseDados.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", professores.TipoIdentificacaoFK);
            return View(professores);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _baseDados.Professores == null)
            {
                return NotFound();
            }

            var professores = await _baseDados.Professores.FindAsync(id);
            if (professores == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", professores.TipoIdentificacaoFK);
            return View(professores);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Telemovel,Email,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Professor professores)
        {
            if (id != professores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _baseDados.Update(professores);
                    await _baseDados.SaveChangesAsync();
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
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", professores.TipoIdentificacaoFK);
            return View(professores);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _baseDados.Professores == null)
            {
                return NotFound();
            }

            var professores = await _baseDados.Professores
                .Include(p => p.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professores == null)
            {
                return NotFound();
            }

            return View(professores);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_baseDados.Professores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Professor'  is null.");
            }
            var professores = await _baseDados.Professores.FindAsync(id);
            if (professores != null)
            {
                _baseDados.Professores.Remove(professores);
            }
            
            await _baseDados.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessoresExists(int id)
        {
          return _baseDados.Professores.Any(e => e.Id == id);
        }
    }
}
