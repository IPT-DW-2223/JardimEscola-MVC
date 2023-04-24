namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição de uma turma.
    /// </summary>
    public class Turmas {

        public Turmas() {
            Alunos = new HashSet<Pessoas>();
        }

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

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// Lista de alunos associados a cada turma.
        /// </summary>
        public ICollection<Pessoas> Alunos { get; set; }

        /// <summary>
        /// Professor(a) associado(a) à turma.
        /// </summary>
        public int ProfessorFK { get; set; }
        public Pessoas Professor { get; set; }

    }

}
