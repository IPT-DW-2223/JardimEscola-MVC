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
    public class PessoasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pessoas.Include(p => p.EncEducacao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pessoas == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas
                .Include(p => p.EncEducacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return View(pessoas);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            ViewData["EncEducacaoFK"] = new SelectList(_context.Pessoas, "Id", "CodPostal");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Morada,CodPostal,Identificacao,IdentificacaoTipo,NIF,Telemovel,Email,Escolariedade,Profissao,EncEducacaoFK")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncEducacaoFK"] = new SelectList(_context.Pessoas, "Id", "CodPostal", pessoas.EncEducacaoFK);
            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pessoas == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }
            ViewData["EncEducacaoFK"] = new SelectList(_context.Pessoas, "Id", "CodPostal", pessoas.EncEducacaoFK);
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Morada,CodPostal,Identificacao,IdentificacaoTipo,NIF,Telemovel,Email,Escolariedade,Profissao,EncEducacaoFK")] Pessoas pessoas)
        {
            if (id != pessoas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoasExists(pessoas.Id))
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
            ViewData["EncEducacaoFK"] = new SelectList(_context.Pessoas, "Id", "CodPostal", pessoas.EncEducacaoFK);
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pessoas == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas
                .Include(p => p.EncEducacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pessoas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pessoas'  is null.");
            }
            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas != null)
            {
                _context.Pessoas.Remove(pessoas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoasExists(int id)
        {
          return _context.Pessoas.Any(e => e.Id == id);
        }
    }
}
