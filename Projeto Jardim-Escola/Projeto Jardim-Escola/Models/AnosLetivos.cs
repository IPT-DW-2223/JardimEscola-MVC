using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos anos letivos.
    /// </summary>
    public class AnosLetivos {

        // ----- [Construtor] --------------------------------------------------------------------- //
        public AnosLetivos() {
            Turmas = new HashSet<Turmas>();
        }

        /// <summary>
        /// Chave primária do tipo de identificação.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Ano letivo das turmas.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Ano Letivo")]
        public string AnoLetivo { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// Lista de turmas associadas a um ano letivo.
        /// </summary>
        public ICollection<Turmas> Turmas { get; set; }

    }

}
