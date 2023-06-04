using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;

using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;
using System.Diagnostics.CodeAnalysis;

namespace Projeto_Jardim_Escola.Controllers.Api {
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase {

        private readonly ApplicationDbContext _baseDados;

        public ApiController(ApplicationDbContext baseDados) { _baseDados = baseDados; }

        /// <summary>
        /// GET: Api/Alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Alunos")]
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos() {
            return await _baseDados.Alunos
                .Include(a => a.Responsavel)
                .OrderBy(a => a.Nome)
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
