﻿using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos responsáveis (Encarregados de Educação).
    /// </summary>
    public class Responsaveis : Pessoas {

        /// <summary>
        /// Morada do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Morada")]
        [StringLength(60)]
        public string Morada { get; set; }

        /// <summary>
        /// Código Postal do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Código Postal")]
        [RegularExpression("[1-9][0-9]{3}-[0-9]{3}(){1,3}[A-Z -ÇÀÁÉÍÓÚÃÂÊÎÔÛ]+", ErrorMessage = " O {0} deve ter o formato")]
        [StringLength(40)]
        public string CodPostal { get; set; }

        /// <summary>
        /// Telemóvel do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Telemóvel")]
        [StringLength(14, MinimumLength = 5, ErrorMessage = "Deve escrever {1} digitos no número {0} ")]
        [RegularExpression("((+|00)351)?9[1236][0123456789]{7}")]
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Escolaridade do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Escolaridade")]
        public string Escolaridade { get; set; }

        /// <summary>
        /// Profissão do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

    }

}
