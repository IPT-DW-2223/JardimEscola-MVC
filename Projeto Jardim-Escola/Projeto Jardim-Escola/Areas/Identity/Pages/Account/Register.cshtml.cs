// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Projeto_Jardim_Escola.Data;
using Projeto_Jardim_Escola.Models;

namespace Projeto_Jardim_Escola.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Objeto que contém os dados da base de dados.
        /// </summary>
        private readonly ApplicationDbContext _baseDados;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext baseDados) {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _baseDados = baseDados;
        }

        /// <summary>
        /// Atributo responsável pelo envio e recolha dos dados da interface.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// Atributo que guarda o link para onde o utilizador é redirecionado após o registo terminar.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Lista de logins criados a partir de 'providers' externos.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Especifica a estrutura do objeto que transporta os dados de e para a interface.
        /// </summary>
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} e um máximo de {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar password")]
            [Compare("Password", ErrorMessage = "As passwords não coincidem.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// Coleta dados do responsável.
            /// </summary>
            public Responsaveis Responsavel { get; set; }

            /// <summary>
            /// Coleta dados do professor.
            /// </summary>
            public Professores Professor { get; set; }

            /// <summary>
            /// Este atributo guarda o id da tab que está ativa.
            /// </summary>
            public string ActiveTab { get; set; }

        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ViewData["TipoIdentificacaoFK"] = new SelectList(_baseDados.TiposIdentificacao, "Id", "Nome");
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null, string ActiveTab = null)
        {
            
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            string cargo = null;

            if (ActiveTab == "v-pills-resp-tab" || ActiveTab == null) { cargo = "Enc. de Educação"; }
            if (ActiveTab == "v-pills-prof-tab") { cargo = "Professor"; }
            if (ActiveTab == "v-pills-admin-tab") { cargo = "Admin"; }

            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("O utilizador criou uma nova conta com password.");

                /**
                * Associar o novo utilizador a um cargo e,
                *      adicioná-lo na tabela Pessoas.
                */

                await _userManager.AddToRoleAsync(user, cargo);

                try {
                    if (cargo == "Enc. de Educação") { 
                        Input.Responsavel.UserID = user.Id;
                        Input.Responsavel.Email = user.Email;
                        _baseDados.Add(Input.Responsavel);
                        await _baseDados.SaveChangesAsync();
                    }
                    if (cargo == "Professor") {
                        Input.Professor.UserID = user.Id;
                        Input.Professor.Email = user.Email;
                        _baseDados.Add(Input.Professor);
                        await _baseDados.SaveChangesAsync();
                    }
                } catch (Exception) {
                    await _userManager.DeleteAsync(user);
                    ModelState.AddModelError("", "Não foi ppossível criar o utilizador... Algo correu mal.");
                    return Page();
                }

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
