namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Esta class contém os dados de login do React para o MVC.
    /// </summary>
    public class LoginViewModel {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Esta classe colecta os dados dos Alunos para a API.
    /// </summary>
    public class AlunoViewModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Identificacao { get; set; }
        public int TipoIdentificacao { get; set; }
        public string NIF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Responsavel { get; set; }
        public string Avaliacao { get; set; }
    }

}