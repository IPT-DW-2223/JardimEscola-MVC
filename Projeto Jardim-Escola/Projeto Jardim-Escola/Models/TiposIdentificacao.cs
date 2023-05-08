using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos tipos de identificação.
    /// </summary>
    public class TiposIdentificacao {

        /// <summary>
        /// Chave primária do tipo de identificação.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Tipo de Identificação
        /// Cartão de Cidadão, Bilhete de Identidade, etc...
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Tipo de Identificação")]
        public string Nome { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

    }

}
