using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;

namespace Projeto_Jardim_Escola.Controllers
{

    public class AlunosController : Controller
    {
        // Criar uma instância de acesso à base de dados.
        private readonly ApplicationDbContext _baseDados;

        // Variável que vai conter os dados do servidor.
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AlunosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _baseDados = context;
            _webHostEnvironment = webHostEnvironment;
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

            // Verifica se foi introduzida alguma foto.
            if (fotografia == null) {
                alunos.Foto = "semfoto.jpg";
            } else {
                // Verifica se é ficheiro ou imagem.
                if (!(fotografia.ContentType == "image/png" || fotografia.ContentType == "image/jpeg")) {
                    // Se não for imagem mostra erro.
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    // Devolve o controlo da app à View.
                    return View(alunos);
                } else {
                    // Se for imagem define o nome da foto.
                    Guid guid = Guid.NewGuid();
                    string nomeFoto = alunos.Nome + "_" + guid.ToString();
                    string extensaoFoto = Path.GetExtension(fotografia.FileName).ToLower();
                    nomeFoto += extensaoFoto;
                    // Atribuir ao aluno o nome da sua foto.
                    alunos.Foto = nomeFoto;
                }
            }

            if (ModelState.IsValid)
            {
                // Adiciona os dados à base de dados.
                _baseDados.Add(alunos);

                // Sincroniza os dados.
                await _baseDados.SaveChangesAsync();

                // Guarda o ficheiro da fotografia.
                if (fotografia != null) {
                    // Criar um caminho para o ficheiro.
                    string nomeLocalFicheiro = _webHostEnvironment.WebRootPath;
                    nomeLocalFicheiro = Path.Combine(nomeLocalFicheiro, "Fotos");
                    // Verifica se a pasta "Fotos" existe no projeto, se não existir, cria-a.
                    if (!Directory.Exists(nomeLocalFicheiro)) {
                        Directory.CreateDirectory(nomeLocalFicheiro);
                    }
                    // Nome do documento a guardar.
                    string nomeDaFoto = Path.Combine(nomeLocalFicheiro, alunos.Foto);
                    // Cria o objeto que vai manipular o ficheiro.
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                    // Guarda o ficheiro no disco rígido.
                    await fotografia.CopyToAsync(stream);
                }

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
