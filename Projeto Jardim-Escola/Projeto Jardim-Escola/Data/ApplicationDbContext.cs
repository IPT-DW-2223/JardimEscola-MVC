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

            // Garante que uma Pessoa (Professor) tem várias Turmas.
            modelBuilder.Entity<Pessoas>()
                .HasMany(p => p.Turmas);

            // Garante que uma Turma tem várias Pessoas (Alunos).
            modelBuilder.Entity<Turmas>()
                .HasMany(p => p.Alunos);

            // Adicionar os dados dos cargos (Roles).
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "adm",  Name = "Admin",             NormalizedName = "ADMIN" },         
                new IdentityRole { Id = "prof", Name = "Professor",         NormalizedName = "PROFESSOR" },        
                new IdentityRole { Id = "enc",  Name = "Enc. de Educação",  NormalizedName = "ENC. DE EDUCAÇÃO" }  
                );

            // Gerar o instância para a classe que cria e verifica hashes seguros de passwords.
            var hasher = new PasswordHasher<IdentityUser>();

            // Adicionar utilizadores default.
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser {
                    Id = "0",
                    Email = "admin@jardimescola.com", NormalizedEmail = "ADMIN@JARDIMESCOLA.COM", EmailConfirmed = true,
                    UserName = "admin@jardimescola.com", NormalizedUserName = "ADMIN@JARDIMESCOLA.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin123.")
                }
                );

            // Adicionar o cargo "Admin" ao utilizador "admin@jardimescola.com".
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "adm", UserId = "0" }
                );

        }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Adicionar tabelas à base de dados] ---------------------------------------------- //
        // ---------------------------------------------------------------------------------------- //

        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Turmas> Turmas { get; set; }

    }
}