using System;
using System.Collections.Generic;

namespace PBBackend.Api.Models
{
    public class Cidade : Base
    {
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}