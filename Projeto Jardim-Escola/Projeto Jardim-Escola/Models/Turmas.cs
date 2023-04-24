using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição de uma turma.
    /// </summary>
    public class Turmas {

        public Turmas() {
            Alunos = new HashSet<Pessoas>();
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

        /// <summary>
        /// Ano letivo da turma.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string AnoLetivo { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// Lista de alunos associados a cada turma.
        /// </summary>
        public ICollection<Pessoas> Alunos { get; set; }

        /// <summary>
        /// Professor(a) associado(a) à turma.
        /// </summary>
        [ForeignKey(nameof(Professor))]
        public int ProfessorFK { get; set; }
        public Pessoas Professor { get; set; }

    }

}
