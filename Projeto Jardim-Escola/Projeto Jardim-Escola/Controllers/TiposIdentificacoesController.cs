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
    public class TiposIdentificacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposIdentificacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposIdentificacoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TiposIdentificacao.ToListAsync());
        }

        // GET: TiposIdentificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposIdentificacao == null)
            {
                return NotFound();
            }

            var tiposIdentificacao = await _context.TiposIdentificacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposIdentificacao == null)
            {
                return NotFound();
            }

            return View(tiposIdentificacao);
        }

        // GET: TiposIdentificacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposIdentificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TiposIdentificacao tiposIdentificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposIdentificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposIdentificacao);
        }

        // GET: TiposIdentificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposIdentificacao == null)
            {
                return NotFound();
            }

            var tiposIdentificacao = await _context.TiposIdentificacao.FindAsync(id);
            if (tiposIdentificacao == null)
            {
                return NotFound();
            }
            return View(tiposIdentificacao);
        }

        // POST: TiposIdentificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TiposIdentificacao tiposIdentificacao)
        {
            if (id != tiposIdentificacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposIdentificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposIdentificacaoExists(tiposIdentificacao.Id))
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
            return View(tiposIdentificacao);
        }

        // GET: TiposIdentificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposIdentificacao == null)
            {
                return NotFound();
            }

            var tiposIdentificacao = await _context.TiposIdentificacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposIdentificacao == null)
            {
                return NotFound();
            }

            return View(tiposIdentificacao);
        }

        // POST: TiposIdentificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposIdentificacao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TiposIdentificacao'  is null.");
            }
            var tiposIdentificacao = await _context.TiposIdentificacao.FindAsync(id);
            if (tiposIdentificacao != null)
            {
                _context.TiposIdentificacao.Remove(tiposIdentificacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposIdentificacaoExists(int id)
        {
          return _context.TiposIdentificacao.Any(e => e.Id == id);
        }
    }
}
