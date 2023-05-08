namespace Projeto_Jardim_Escola.Models {

    /// <summary>
    /// Descrição dos responsáveis (Encarregados de Educação).
    /// </summary>
    public class Responsaveis : Pessoas {

        /// <summary>
        /// Morada do encarregado de educação.
        /// </summary>
        public string Morada { get; set; }

        public string CodPostal { get; set; }

        public string Telemovel { get; set; }

        public string Email { get; set; }

        public string Escolaridade { get; set; }

        public string Profissao { get; set; }

        // ---------------------------------------------------------------------------------------- //
        // ----- [Chaves Estrangeiras] ------------------------------------------------------------ //
        // ---------------------------------------------------------------------------------------- //

    }

}
