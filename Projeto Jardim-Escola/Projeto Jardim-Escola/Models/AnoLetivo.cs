﻿using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos anos letivos.
    /// </summary>
    public class AnoLetivo {

        // ----- [Construtor] --------------------------------------------------------------------- //
        public AnoLetivo() {
            Turmas = new HashSet<Turma>();
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
        public string NomeAnoLetivo { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// Lista de turmas associadas a um ano letivo.
        /// </summary>
        public ICollection<Turma> Turmas { get; set; }

    }

}
