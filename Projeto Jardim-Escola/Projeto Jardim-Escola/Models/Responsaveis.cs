using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos responsáveis (Encarregados de Educação).
    /// </summary>
    public class Responsaveis : Pessoas {

        // ----- [Construtor] --------------------------------------------------------------------- //
        public Responsaveis() {
            Alunos = new HashSet<Alunos>();
        }

        /// <summary>
        /// Atributo que conecta o utilizador à autenticação da base de dados.
        /// </summary>
        public string UserID { get; set; }

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
        [RegularExpression("[1-9][0-9]{3}-[0-9]{3}(){1,3}[A-Z -ÇÀÁÉÍÓÚÃÂÊÎÔÛ]+", ErrorMessage = " O {0} deve ter o formato 0000-000 CIDADE")]
        [StringLength(40)]
        public string CodPostal { get; set; }

        /// <summary>
        /// Telemóvel do encarregado de educação.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Telemóvel")]
        [StringLength(14, MinimumLength = 5, ErrorMessage = "Deve escrever {1} digitos no número {0} ")]
        [RegularExpression("9[1236][0-9]{7}", ErrorMessage = "O número de {0} deve começar por 91, 92, 93 ou 96, e ter 9 dígitos")]
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do encarregado de educação.
        /// </summary>
        [EmailAddress(ErrorMessage = "O {0} não está corretamente escrito")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[a-z._0-9]+@gmail.com", ErrorMessage = "O {0} tem de ser do GMail")]
        [StringLength(40)]
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

        /// <summary>
        /// Lista de alunos da turma.
        /// </summary>
        public ICollection<Alunos> Alunos { get; set; }

    }

}
