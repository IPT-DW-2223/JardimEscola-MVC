using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Jardim_Escola.Models
{       
    /// <summary>
    /// Descrição das pessoas.
    /// </summary>
    public class Pessoas{

        /// <summary>
        /// Chave primária da turma.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Número de identificação da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }
        
        /// <summary>
        /// Número de identificção fiscal da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string NIF { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

    }
}
