using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição de uma turma.
    /// </summary>
    public class Turmas {

        // ----- [Construtor] --------------------------------------------------------------------- //
        public Turmas() { 
            Alunos = new HashSet<Alunos>();
        }

        /// <summary>
        /// Chave primária da turma.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da turma.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// FK para o ano letivo da turma.
        /// </summary>
        [ForeignKey(nameof(AnoLetivo))]
        [Display(Name = "Ano letivo")]
        public int AnoLetivoFK { get; set; }
        public AnosLetivos AnoLetivo { get; set; }

        /// <summary>
        /// FK para o professor da turma.
        /// </summary>
        [ForeignKey(nameof(Professor))]
        [Display(Name = "Professor")]
        public int ProfessorFK { get; set; }
        public Professores Professor { get; set; }

        /// <summary>
        /// Lista de alunos da turma.
        /// </summary>
        public ICollection<Alunos> Alunos { get; set; }

    }

}
