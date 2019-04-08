using System.Collections.Generic;
using PBBackend.Api.Models;

namespace PBBackend.Api.Repositories
{
    interface IEnderecoRepository
    {
        IEnumerable<Endereco> Get();
        Endereco Get(int id);
        void Save(Endereco endereco);
        void Update(Endereco endereco);
        void Delete(Endereco endereco);
    }
}