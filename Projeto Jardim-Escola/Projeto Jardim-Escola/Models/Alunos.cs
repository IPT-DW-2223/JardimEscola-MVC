using System.ComponentModel.DataAnnotations;

namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição dos alunos.
    /// </summary>
    public class Alunos : Pessoas {

        /// <summary>
        /// Data de nascimento do aluno.
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Género do aluno:
        /// Masculino/Feminino
        /// </summary>
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [Display(Name = "Género")]
        public string Genero { get; set; }

        /// <summary>
        /// Diretoria da foto do aluno.
        /// </summary>
        public string Foto { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

    }

}
