using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Projeto_Jardim_Escola.Controllers
{
    [Authorize(Roles = "Admin, Professor")]
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _baseDados;

        // Criar uma instância de acesso aos dados do utilizador logado.
        private readonly UserManager<IdentityUser> _userManager;

        public TurmasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _baseDados = context;
            _userManager = userManager;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var turmas = _baseDados.Turmas.Include(t => t.AnoLetivo).Include(t => t.Professor);

            // Se o utilizador for um Professor..
            //      mostra só as turmas associadas a ele.
            if (User.IsInRole("Professor")) {

                var loggedUser = await _userManager.GetUserAsync(User);
                var loggedUserId = await _userManager.GetUserIdAsync(loggedUser); // Guarda o Id (GUID) do atual utilizador logado.

                var professorId = _baseDados.Professores.FirstOrDefault(p => p.UserID == loggedUserId)?.Id;

                if (professorId == null) {
                    return NoContent();
                }

                var turmasProfessor = _baseDados.Turmas.Include(t => t.AnoLetivo).Include(t => t.Professor).Where(t => t.ProfessorFK == professorId);

                //var alunosResp = _baseDados.Alunos.Include(a => a.TipoIdentificacao).Include(a => a.Responsavel).Where(a => a.ResponsavelFK == responsavelId);

                return View(await turmasProfessor.ToListAsync());

            }

            return View(await turmas.ToListAsync());
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
                .Include(t => t.Alunos)
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
            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "NomeAnoLetivo");
            ViewData["ProfessorFK"] = new SelectList(_baseDados.Professores, "Id", "Nome");

            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,AnoLetivoFK,ProfessorFK")] Turma turmas, string alunosSelecionados)
        {
            if (ModelState.IsValid) {
                // Adicionar a turma à base de dados.
                _baseDados.Add(turmas);

                // Sincroniza a base de dados.
                await _baseDados.SaveChangesAsync();

                List<int> listaAlunosIds = JsonConvert.DeserializeObject<List<int>>(alunosSelecionados);

                // Associar os alunos selecionados à turma.
                foreach (var alunoId in listaAlunosIds) {
                    var aluno = _baseDados.Alunos.Include(a => a.Turmas).FirstOrDefault(a => a.Id == alunoId);
                    if (aluno != null) {
                        aluno.Turmas.Add(turmas);
                    }
                }

                // Sincroniza a base de dados.
                await _baseDados.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "NomeAnoLetivo", turmas.AnoLetivoFK);
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

            var turma = await _baseDados.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "NomeAnoLetivo", turma.AnoLetivoFK);
            ViewData["ProfessorFK"] = new SelectList(_baseDados.Professores, "Id", "Nome", turma.ProfessorFK);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,AnoLetivoFK,ProfessorFK")] Turma turmas)
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
            ViewData["AnoLetivoFK"] = new SelectList(_baseDados.AnosLetivos, "Id", "NomeAnoLetivo", turmas.AnoLetivoFK);
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

        /// <summary>
        /// Devolve a lista de todos os alunos da base de dados.
        /// </summary>
        /// <returns>Lista de alunos.</returns>
        [HttpGet]
        public ActionResult GetListaAlunos(int anoLetivoId) {

            // Recebe a lista de alunos da base de dados.
            var alunos = _baseDados.Alunos
                .Where(a => a.Ativo && !a.Turmas.Any(t => t.AnoLetivoFK == anoLetivoId))
                .OrderBy(a => a.Nome);

            // Coverte a variável alunos que é uma DbSet para uma string
            //      para que possa ser criada uma lista de alunos em JSON.
            string json = JsonConvert.SerializeObject(alunos);

            // Cria uma lista de alunos do tipo List que terá o formato JSON.
            List<Aluno> listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

            return Json(listaAlunos);
        }

        private bool TurmasExists(int id)
        {
          return _baseDados.Turmas.Any(e => e.Id == id);
        }
    }
}
