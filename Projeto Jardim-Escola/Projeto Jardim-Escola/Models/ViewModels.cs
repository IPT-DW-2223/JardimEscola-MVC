namespace Projeto_Jardim_Escola.Models {

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
    }
}