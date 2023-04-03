namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição de uma turma.
    /// </summary>
    public class Turmas {

        /// <summary>
        /// Chave primária da turma.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da turma.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Ano letivo da turma.
        /// </summary>
        public string AnoLetivo { get; set; }

    }

}
