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

        }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Adicionar tabelas à base de dados] ---------------------------------------------- //
        // ---------------------------------------------------------------------------------------- //

        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Turmas> Turmas { get; set; }

    }
}