using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Data;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

using Projeto_Jardim_Escola.Models;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        /// Retorna uma lista de professores.
        /// </summary>
        /// <returns>Lista de professores</returns>
        [HttpGet("Professores/Lista")]
        public async Task<ActionResult<IEnumerable<PessoaViewModel>>> GetProfessores() {
            return await _baseDados.Professores.OrderBy(p => p.Nome).Select(p => new PessoaViewModel {
                    Id = p.Id,
                    Nome = p.Nome
                }).ToListAsync();
        }

        /// <summary>
        /// Retorna uma lista de responsáveis.
        /// </summary>
        /// <returns>Lista de responsáveis</returns>
        [HttpGet("Responsaveis/Lista")]
        public async Task<ActionResult<IEnumerable<PessoaViewModel>>> GetResponsaveis() {
            return await _baseDados.Responsaveis.OrderBy(r => r.Nome).Select(r => new PessoaViewModel {
                Id = r.Id,
                Nome = r.Nome
            }).ToListAsync();
        }

        /// <summary>
        /// Valida se o utilizador existe.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True: existe; False: não existe</returns>
        private async Task<bool> IsValidUser(string username, string password) {

            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

            if (result.Succeeded) {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gera um token para o utilizador.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Token gerado.</returns>
        private string GenerateToken(string username) {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Gerar uma chave secreta aleatória com 32 bytes de comprimento
            byte[] keyBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider()) {
                rng.GetBytes(keyBytes);
            }

            // Converter a chave em uma string base64 para uso posterior
            string secretKey = Convert.ToBase64String(keyBytes);
            var key = Encoding.ASCII.GetBytes(secretKey); // Substitua pela sua chave secreta

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)
                }),

                Expires = DateTime.UtcNow.AddDays(7), // Define a expiração do token.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Efetua o login e verifica se existe na base de dados.
        /// POST: Api/Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Login autorizado ou não autorizado.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model) {
            // Validar as credenciais do usuário
            if (await IsValidUser(model.Username, model.Password)) {
                // Crie um token de autenticação para o usuário
                var token = GenerateToken(model.Username);

                // Retorne o token como resposta
                return Ok(token);
            }

            // Se as credenciais forem inválidas, retorne uma resposta de erro
            return BadRequest("Credenciais inválidas.");
        }

        /// <summary>
        /// Retorna uma lista de alunos associados ao utilizador autenticado.
        /// GET: Api/Alunos/Lista
        /// </summary>
        /// <returns>Lista de alunos do utilizador autenticado.</returns>
        [Authorize]
        [HttpGet("Alunos/Lista")]
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos() {
            
            var loggedUser = await _userManager.GetUserAsync(User);
            var loggedUserId = await _userManager.GetUserIdAsync(loggedUser);

            if (User.IsInRole("Enc. de Educação")) {
                var loggedResponsavelId = await _baseDados.Responsaveis
                    .Where(r => r.UserID.Equals(loggedUserId))
                    .Select(r => r.Id)
                    .FirstOrDefaultAsync();

                return await _baseDados.Alunos
                    .Include(a => a.Responsavel)
                    .Where(a => a.ResponsavelFK.Equals(loggedResponsavelId))
                    .OrderBy(a => a.Nome)
                    .Select(a => new AlunoViewModel {
                        Id = a.Id,
                        Nome = a.Nome,
                        Identificacao = a.Identificacao,
                        TipoIdentificacao = a.TipoIdentificacaoFK,
                        NIF = a.NIF,
                        DataNascimento = a.DataNascimento,
                        Responsavel = a.Responsavel.Nome,
                        Avaliacao = a.Avaliacao
                    })
                    .ToListAsync();
            } else if (User.IsInRole("Professor")) {
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
                        Responsavel = a.Responsavel.Nome,
                        Avaliacao = a.Avaliacao
                    })
                    .ToListAsync();
            }

            return NoContent();
        }

        /// <summary>
        /// Função para inserir a avaliação de um aluno via API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize("Professor")]
        [HttpPost("Alunos/Avaliar")]
        public async Task<IActionResult> AvaliarAluno([FromQuery] int alunoId, [FromBody] string avaliacao) {

            if (avaliacao == "") { avaliacao = "Não revela progressos"; } 

            // Encontrar o aluno com o Id fornecido.
            var aluno = await _baseDados.Alunos.FindAsync(alunoId);

            // Se não encontrar o aluno, retorna NotFound.
            if (aluno == null) {
                return NotFound();
            }

            // Se chegámos aqui, é porque encontrou o aluno e então associa a avaliação fornecida a ele.
            aluno.Avaliacao = avaliacao;

            // Tenta guardar na base dados.
            try {
                await _baseDados.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!existeAluno(alunoId)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Verifica se o aluno existe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True: existe; False: não existe</returns>
        private bool existeAluno(int id) {
            return _baseDados.Alunos.Any(a => a.Id == id);
        }

    }
}
