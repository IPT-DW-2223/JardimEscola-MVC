namespace Projeto_Jardim_Escola.Models
{       
    /// <summary>
    /// Descrição das pessoas
    /// </summary>
    public class Pessoas{

        public int Id { get; set; }

        /// <summary>
        /// nome das pessoas
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// data de nascimento das pessoas
        /// </summary>
        public DateTime DataNascimento { get; set;}
       
        /// <summary>
        /// morada das pessoas
        /// </summary>
        public string Morada { get; set; }
       
        /// <summary>
        /// código postal das pessoas
        /// </summary>
        public string CodPostal { get; set; }
        
        /// <summary>
        /// número de identificação das pessoas
        /// </summary>
        public string Identificacao { get; set; }
        
        /// <summary>
        /// tipo de identificação das pessoas:
        /// CC - cartão de cidadão
        /// BI - bilhete de identidade
        /// P - passaport
        /// </summary>
        public string IdentificacaoTipo { get; set; }
        
        /// <summary>
        /// número de identificção fiscal das pessoas
        /// </summary>
        public string NIF { get; set; }
        
        /// <summary>
        /// número de telemóvel das pessoas
        /// </summary>
        public string Telemovel { get; set; }
        
        /// <summary>
        /// email das pessoas
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// escolariedade das pessoas
        /// </summary>
        public string Escolariedade { get; set; }

        /// <summary>
        /// profissão das pessoas
        /// </summary>
        public string Profissao { get; set; }
       

    }
}
