using System;
using System.Collections.Generic;

namespace PBBackend.Api.Models
{
    public class Estado : Base
    {
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public IEnumerable<Cidade> Cidades { get; set; }
    }
}