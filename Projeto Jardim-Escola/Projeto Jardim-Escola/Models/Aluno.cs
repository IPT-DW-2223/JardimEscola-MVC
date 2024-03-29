﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Jardim_Escola.Models {
    
    /// <summary>
    /// Descrição dos alunos.
    /// </summary>
    public class Aluno : Pessoa {

        // ----- [Construtor] --------------------------------------------------------------------- //
        public Aluno() {
            Turmas = new HashSet<Turma>();
        }

        /// <summary>
        /// Data de nascimento do aluno.
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
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
        [Display(Name = "Fotografia")]
        public string Foto { get; set; }

        /// <summary>
        /// Identifica se o aluno está ativo ou não.
        /// True - Ativo; False - Não ativo.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Avaliação do aluno.
        /// </summary>
        [Display(Name = "Avalição")]
        public string Avaliacao { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

        /// <summary>
        /// FK para o responsável do aluno.
        /// </summary>
        [ForeignKey(nameof(Responsavel))]
        [Display(Name ="Responsável")]
        public int ResponsavelFK { get; set; }
        public Responsavel Responsavel { get; set; }

        /// <summary>
        /// Lista de turmas.
        /// </summary>
        public ICollection<Turma> Turmas { get; set; }

    }

}
