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
    public class ResponsaveisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsaveisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responsaveis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Responsaveis.Include(r => r.TipoIdentificacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Responsaveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsaveis = await _context.Responsaveis
                .Include(r => r.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsaveis == null)
            {
                return NotFound();
            }

            return View(responsaveis);
        }

        // GET: Responsaveis/Create
        public IActionResult Create()
        {
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome");
            return View();
        }

        // POST: Responsaveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Morada,CodPostal,Telemovel,Email,Escolaridade,Profissao,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Responsaveis responsaveis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsaveis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome", responsaveis.TipoIdentificacaoFK);
            return View(responsaveis);
        }

        // GET: Responsaveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsaveis = await _context.Responsaveis.FindAsync(id);
            if (responsaveis == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome", responsaveis.TipoIdentificacaoFK);
            return View(responsaveis);
        }

        // POST: Responsaveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Morada,CodPostal,Telemovel,Email,Escolaridade,Profissao,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Responsaveis responsaveis)
        {
            if (id != responsaveis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsaveis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsaveisExists(responsaveis.Id))
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
            ViewData["TipoIdentificacaoFK"] = new SelectList(_context.TiposIdentificacao, "Id", "Nome", responsaveis.TipoIdentificacaoFK);
            return View(responsaveis);
        }

        // GET: Responsaveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Responsaveis == null)
            {
                return NotFound();
            }

            var responsaveis = await _context.Responsaveis
                .Include(r => r.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsaveis == null)
            {
                return NotFound();
            }

            return View(responsaveis);
        }

        // POST: Responsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Responsaveis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Responsaveis'  is null.");
            }
            var responsaveis = await _context.Responsaveis.FindAsync(id);
            if (responsaveis != null)
            {
                _context.Responsaveis.Remove(responsaveis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsaveisExists(int id)
        {
          return _context.Responsaveis.Any(e => e.Id == id);
        }
    }
}
