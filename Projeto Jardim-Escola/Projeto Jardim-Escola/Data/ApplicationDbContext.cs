using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_Jardim_Escola.Models;

namespace Projeto_Jardim_Escola.Data
{

    /// <summary>
    /// Esta classe representa a base de dados da aplicação.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Executa o código antes da criação do model.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Importa a última execução deste método.
            base.OnModelCreating(modelBuilder);

            // Adicionar os dados dos cargos (Roles).
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "adm",  Name = "Admin",             NormalizedName = "ADMIN" },         
                new IdentityRole { Id = "prof", Name = "Professor",         NormalizedName = "PROFESSOR" },        
                new IdentityRole { Id = "enc",  Name = "Enc. de Educação",  NormalizedName = "ENC. DE EDUCAÇÃO" }  
                );

            // Gerar a instância para a classe que cria e verifica hashes seguros de passwords.
            var hasher = new PasswordHasher<IdentityUser>();

            // Adicionar utilizadores default.
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser {
                    Id = "0",
                    Email = "admin@jardimescola.com", NormalizedEmail = "ADMIN@JARDIMESCOLA.COM", EmailConfirmed = true,
                    UserName = "admin@jardimescola.com", NormalizedUserName = "ADMIN@JARDIMESCOLA.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin123.")
                },
                new IdentityUser {
                    Id = "1",
                    Email = "resp@jardimescola.com", NormalizedEmail = "RESP@JARDIMESCOLA.COM", EmailConfirmed = true,
                    UserName = "resp@jardimescola.com", NormalizedUserName = "RESP@JARDIMESCOLA.COM",
                    PasswordHash = hasher.HashPassword(null, "Responsavel123.")
                },
                new IdentityUser {
                    Id = "2",
                    Email = "prof@jardimescola.com", NormalizedEmail = "PROF@JARDIMESCOLA.COM", EmailConfirmed = true,
                    UserName = "prof@jardimescola.com", NormalizedUserName = "PROF@JARDIMESCOLA.COM",
                    PasswordHash = hasher.HashPassword(null, "Professor123.")
                }
                );

            // Relacionar os cargos criados com os utilizadores criados.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "adm", UserId = "0" },
                new IdentityUserRole<string> { RoleId = "enc", UserId = "1" },
                new IdentityUserRole<string> { RoleId = "prof", UserId = "2" }
                );

        }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Adicionar tabelas à base de dados] ---------------------------------------------- //
        // ---------------------------------------------------------------------------------------- //

        public DbSet<Pessoas> Pessoas { get; set; }                                           
        public DbSet<Turmas> Turmas { get; set; }                                              
        public DbSet<Alunos> Alunos { get; set; }                                                 
        public DbSet<AnosLetivos> AnosLetivos { get; set; }
        public DbSet<Professores> Professores { get; set; }
        public DbSet<Responsaveis> Responsaveis { get; set; }
        public DbSet<TiposIdentificacao> TiposIdentificacao { get; set; }

    }
}