using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Jardim_Escola.Models
{       
    /// <summary>
    /// Descrição das pessoas.
    /// </summary>
    public class Pessoas{

        public Pessoas() {
            Alunos = new HashSet<Pessoas>();
            Turmas = new HashSet<Turmas>();
        }

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
        /// Data de nascimento da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Morada da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Morada { get; set; }

        /// <summary>
        /// Código postal da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

        /// <summary>
        /// Número de identificação da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }
        
        /// <summary>
        /// Tipo de identificação da pessoa:
        /// CC - cartão de cidadão
        /// BI - bilhete de identidade
        /// P - passaport
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Tipo de Identificação")]
        public string IdentificacaoTipo { get; set; }
        
        /// <summary>
        /// Número de identificção fiscal da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string NIF { get; set; }
        
        /// <summary>
        /// Número de telemóvel da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Telemóvel")]
        [RegularExpression("^\\d{9}$", ErrorMessage = "O número de telemóvel não é válido.")]
        public string Telemovel { get; set; }
        
        /// <summary>
        /// Email da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
        public string Email { get; set; }
        
        /// <summary>
        /// Escolariedade da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        public string Escolariedade { get; set; }

        /// <summary>
        /// Profissão da pessoa.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// Lista de alunos associados a cada professor ou encarregado de educação.
        /// </summary>
        public ICollection<Pessoas> Alunos { get; set; }

        /// <summary>
        /// Lista de turmas associadas a cada aluno(a) e professor(a).
        /// </summary>
        public ICollection<Turmas> Turmas { get; set; }

        /// <summary>
        /// Encarregado(a) de educação associado(a) a cada aluno(a).
        /// </summary>
        [ForeignKey(nameof(EncEducacao))]
        public int EncEducacaoFK { get; set; }
        public Pessoas EncEducacao { get; set; }

        /// <summary>
        /// Professor(a) associado(a) a cada aluno(a). (!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!)
        /// </summary>
        //public int ProfessorFK { get; set; }
        //public Pessoas Professor { get; set; }

    }
}
