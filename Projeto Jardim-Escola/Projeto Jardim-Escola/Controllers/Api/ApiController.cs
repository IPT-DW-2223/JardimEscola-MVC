using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="baseDados"></param>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        public ApiController(
            ApplicationDbContext baseDados,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager) { 
            _baseDados = baseDados;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Efetua o login e verifica se existe na base de dados.
        /// POST: Api/Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Login autorizado ou não autorizado.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model) {
            
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)) {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            return Unauthorized();
        }

        /// <summary>
        /// Retorna todos os dados da tabela Alunos.
        /// GET: Api/Alunos/Lista
        /// </summary>
        /// <returns>Lista de alunos.</returns>
        [Authorize]
        [HttpGet("Alunos/Lista")]
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

        // TODO: Verificar se é necessário fazer a API retornar os dados dos Responsáveis.

    }
}
