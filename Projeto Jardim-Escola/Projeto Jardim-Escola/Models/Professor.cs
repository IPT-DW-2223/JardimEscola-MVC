using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos professores.
    /// </summary>
    public class Professor : Pessoa {

        // ----- [Construtor] --------------------------------------------------------------------- //
        public Professor() {
            Turmas = new HashSet<Turma>();
        }

        /// <summary>
        /// Atributo que conecta o utilizador à autenticação da base de dados.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Número de telemóvel do professor.
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Telemóvel")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve ter {1} dígitos")]
        [RegularExpression("9[1236][0-9]{7}", ErrorMessage = "O número de {0} deve começar por 91, 92, 93 ou 96, e ter 9 dígitos")]
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do professor.
        /// </summary>
        [EmailAddress(ErrorMessage = "O {0} não está corretamente escrito")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[a-z._0-9]+@gmail.com", ErrorMessage = "O {0} tem de ser do GMail")]
        [StringLength(40)]
        public string Email { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// Lista de turmas a que o professor está associado.
        /// </summary>
        public ICollection<Turma> Turmas { get; set; }

    }

}
