using System.Collections.Generic;
using PBBackend.Api.Models;

namespace PBBackend.Api.Repositories
{
    interface ICidadeRepository
    {
        IEnumerable<Cidade> Get();
        Cidade Get(int id);
        void Save(Cidade Cidade);
        void Update(Cidade Cidade);
        void Delete(Cidade Cidade);
    }
}