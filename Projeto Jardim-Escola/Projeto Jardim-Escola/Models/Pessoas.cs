namespace Projeto_Jardim_Escola.Models
{       
    /// <summary>
    /// Descrição das pessoas.
    /// </summary>
    public class Pessoas{

        /// <summary>
        /// Chave primária da turma.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de nascimento da pessoa.
        /// </summary>
        public DateTime DataNascimento { get; set;}
       
        /// <summary>
        /// Morada da pessoa.
        /// </summary>
        public string Morada { get; set; }
       
        /// <summary>
        /// Código postal da pessoa.
        /// </summary>
        public string CodPostal { get; set; }
        
        /// <summary>
        /// Número de identificação da pessoa.
        /// </summary>
        public string Identificacao { get; set; }
        
        /// <summary>
        /// Tipo de identificação da pessoa:
        /// CC - cartão de cidadão
        /// BI - bilhete de identidade
        /// P - passaport
        /// </summary>
        public string IdentificacaoTipo { get; set; }
        
        /// <summary>
        /// Número de identificção fiscal da pessoa.
        /// </summary>
        public string NIF { get; set; }
        
        /// <summary>
        /// Número de telemóvel da pessoa.
        /// </summary>
        public string Telemovel { get; set; }
        
        /// <summary>
        /// Email da pessoa.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Escolariedade da pessoa.
        /// </summary>
        public string Escolariedade { get; set; }

        /// <summary>
        /// Profissão da pessoa.
        /// </summary>
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
        public int EncEducacaoFK { get; set; }
        public Pessoas EncEducacao { get; set; }

        /// <summary>
        /// Professor(a) associado(a) a cada aluno(a). (!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!)
        /// </summary>
        public int ProfessorFK { get; set; }
        public Pessoas Professor { get; set; }

    }
}
