using Pais.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pais.Domain.Entities
{
    public class Federacao : Entity<uint>
    {
        /// <summary>
        /// Número
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; }

        /// <summary>
        /// Sigla
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// DDI
        /// </summary>
        public string Ddi { get; set; }

        public Federacao(string nome)
        {
            this.Nome = nome;

            Validate(this, new FederacaoValidator());
        }
    }
}
