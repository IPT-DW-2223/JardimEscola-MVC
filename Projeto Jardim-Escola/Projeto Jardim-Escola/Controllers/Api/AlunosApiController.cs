using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;

using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;
using System.Diagnostics.CodeAnalysis;

namespace Projeto_Jardim_Escola.Controllers.Api {
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosApiController : ControllerBase {

        private readonly ApplicationDbContext _baseDados;

        public AlunosApiController(ApplicationDbContext baseDados) { _baseDados = baseDados; }

        /// <summary>
        /// GET: api/AlunosAPI
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos() {
            return await _baseDados.Alunos
                .Include(a => a.Responsavel)
                .OrderByDescending(a => a.Id)
                .Select(a => new AlunoViewModel {
                    Id = a.Id,
                    Nome = a.Nome,
                    Identificacao = a.Identificacao,
                    TipoIdentificacao = a.TipoIdentificacaoFK,
                    NIF = a.NIF,
                    DataNascimento = a.DataNascimento,
                    Responsavel = a.Responsavel.Nome
                })
                .ToListAsync();
        }

    }
}
