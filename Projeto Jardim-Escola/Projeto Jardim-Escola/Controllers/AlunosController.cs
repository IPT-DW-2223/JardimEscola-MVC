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

    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _baseDados;

        public AlunosController(ApplicationDbContext context)
        {
            _baseDados = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _baseDados.Alunos.Include(a => a.TipoIdentificacao).Include(a => a.Responsavel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _baseDados.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _baseDados.Alunos
                .Include(a => a.TipoIdentificacao)
                .Include(a => a.Responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome");
            ViewData["ResponsavelFK"] = new SelectList(_baseDados.Responsaveis, "Id", "Nome");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataNascimento,Genero,Foto,ResponsavelFK,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Alunos alunos, IFormFile fotografia)
        {
            if (ModelState.IsValid)
            {
                _baseDados.Add(alunos);
                await _baseDados.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", alunos.TipoIdentificacaoFK);
            ViewData["ResponsavelFK"] = new SelectList(_baseDados.Responsaveis, "Id", "Nome", alunos.ResponsavelFK);
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _baseDados.Alunos == null)
            {
                return NotFound();
            }

            var alunos = await _baseDados.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", alunos.TipoIdentificacaoFK);
            ViewData["ResponsavelFK"] = new SelectList(_baseDados.Responsaveis, "Id", "Nome", alunos.ResponsavelFK);
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataNascimento,Genero,Foto,ResponsavelFK,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Alunos alunos)
        {
            if (id != alunos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _baseDados.Update(alunos);
                    await _baseDados.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunosExists(alunos.Id))
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
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", alunos.TipoIdentificacaoFK);
            ViewData["ResponsavelFK"] = new SelectList(_baseDados.Responsaveis, "Id", "Nome", alunos.ResponsavelFK);
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _baseDados.Alunos == null)
            {
                return NotFound();
            }

            var alunos = await _baseDados.Alunos
                .Include(a => a.TipoIdentificacao)
                .Include(a => a.Responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_baseDados.Alunos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alunos'  is null.");
            }
            var alunos = await _baseDados.Alunos.FindAsync(id);
            if (alunos != null)
            {
                _baseDados.Alunos.Remove(alunos);
            }
            
            await _baseDados.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunosExists(int id)
        {
          return _baseDados.Alunos.Any(e => e.Id == id);
        }
    }
}
