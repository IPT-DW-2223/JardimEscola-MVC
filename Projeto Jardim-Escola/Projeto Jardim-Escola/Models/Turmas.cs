using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição de uma turma.
    /// </summary>
    public class Turmas {

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

    }

}
