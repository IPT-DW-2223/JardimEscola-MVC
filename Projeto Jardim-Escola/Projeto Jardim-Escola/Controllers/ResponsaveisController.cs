﻿using System;
using System.Collections.Generic;
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
    public class ResponsaveisController : Controller
    {
        private readonly ApplicationDbContext _baseDados;

        public ResponsaveisController(ApplicationDbContext context)
        {
            _baseDados = context;
        }

        // GET: Responsavel
        public async Task<IActionResult> Index()
        {
            var responsaveis = _baseDados.Responsaveis.Include(r => r.TipoIdentificacao);
            return View(await responsaveis.ToListAsync());
        }

        // GET: Responsavel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _baseDados.Responsaveis == null)
            {
                return NotFound();
            }

            var responsavel = await _baseDados.Responsaveis
                .Include(r => r.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // GET: Responsavel/Create
        public IActionResult Create()
        {
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome");
            return View();
        }

        // POST: Responsavel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Morada,CodPostal,Telemovel,Email,Escolaridade,Profissao,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Responsavel responsaveis)
        {
            if (ModelState.IsValid)
            {
                _baseDados.Add(responsaveis);
                await _baseDados.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", responsaveis.TipoIdentificacaoFK);
            return View(responsaveis);
        }

        // GET: Responsavel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _baseDados.Responsaveis == null)
            {
                return NotFound();
            }

            var responsaveis = await _baseDados.Responsaveis.FindAsync(id);
            if (responsaveis == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", responsaveis.TipoIdentificacaoFK);
            return View(responsaveis);
        }

        // POST: Responsavel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Morada,CodPostal,Telemovel,Email,Escolaridade,Profissao,Id,Nome,Identificacao,NIF,TipoIdentificacaoFK")] Responsavel responsaveis)
        {
            if (id != responsaveis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _baseDados.Update(responsaveis);
                    await _baseDados.SaveChangesAsync();
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
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome", responsaveis.TipoIdentificacaoFK);
            return View(responsaveis);
        }

        // GET: Responsavel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _baseDados.Responsaveis == null)
            {
                return NotFound();
            }

            var responsaveis = await _baseDados.Responsaveis
                .Include(r => r.TipoIdentificacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsaveis == null)
            {
                return NotFound();
            }

            return View(responsaveis);
        }

        // POST: Responsavel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_baseDados.Responsaveis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Responsavel'  is null.");
            }
            var responsaveis = await _baseDados.Responsaveis.FindAsync(id);
            if (responsaveis != null)
            {
                _baseDados.Responsaveis.Remove(responsaveis);
            }
            
            await _baseDados.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsaveisExists(int id)
        {
          return _baseDados.Responsaveis.Any(e => e.Id == id);
        }
    }
}
