using System.Collections.Generic;
using PBBackend.Api.Models;

namespace PBBackend.Api.Repositories
{
    interface IEstadoRepository
    {
        IEnumerable<Estado> Get();
        Estado Get(int id);
        void Save(Estado estado);
        void Update(Estado estado);
        void Delete(Estado estado);
    }
}