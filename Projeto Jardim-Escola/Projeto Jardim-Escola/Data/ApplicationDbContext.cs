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

            // Adicionar utilizador admin default.
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser {
                    Id = "0",
                    Email = "admin@jardimescola.com", NormalizedEmail = "ADMIN@JARDIMESCOLA.COM", EmailConfirmed = true,
                    UserName = "admin@jardimescola.com", NormalizedUserName = "ADMIN@JARDIMESCOLA.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin123.")
                });

            // Relacionar os cargos criados com os utilizadores criados.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "adm", UserId = "0" }
                );

            // Adicionar tipos de identificação à base de dados.
            modelBuilder.Entity<TipoIdentificacao>().HasData(
                new TipoIdentificacao { Id = 1, Nome = "Cartão de Cidadão" },
                new TipoIdentificacao { Id = 2, Nome = "Bilhete de Identidade" },
                new TipoIdentificacao { Id = 3, Nome = "Passaporte" },
                new TipoIdentificacao { Id = 4, Nome = "Título de Residência"}
                );

            // Adicionar anos letivos.
            modelBuilder.Entity<AnoLetivo>().HasData(
                new AnoLetivo { Id = 1, NomeAnoLetivo = "2021-2022" },
                new AnoLetivo { Id = 2, NomeAnoLetivo = "2022-2023" },
                new AnoLetivo { Id = 3, NomeAnoLetivo = "2023-2024" },
                new AnoLetivo { Id = 4, NomeAnoLetivo = "2024-2025" }
                );

        }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Adicionar tabelas à base de dados] ---------------------------------------------- //
        // ---------------------------------------------------------------------------------------- //

        public DbSet<Pessoa> Pessoas { get; set; }                                           
        public DbSet<Turma> Turmas { get; set; }                                              
        public DbSet<Aluno> Alunos { get; set; }                                                 
        public DbSet<AnoLetivo> AnosLetivos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<TipoIdentificacao> TiposIdentificacao { get; set; }

    }
}