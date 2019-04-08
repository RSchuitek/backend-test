using System.Collections.Generic;
using PBBackend.Api.Models;

namespace PBBackend.Api.Repositories
{
    interface IPessoaRepository
    {
        IEnumerable<Pessoa> Get();
        Pessoa Get(int id);
        void Save(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(Pessoa pessoa);
    }
}