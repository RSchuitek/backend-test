using System;
using System.Collections.Generic;

namespace PBBackend.Api.Models
{
    public class Base 
    {
        public int Id {get; set;}
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}