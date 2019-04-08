using System;

namespace PBBackend.Api.ViewModels.EstadoViewModels
{
    public class ListEstadoViewModel 
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}