using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBBackend.Api.Data;
using PBBackend.Api.Models;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.PessoaViewModels;

namespace PBBackend.Api.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly StoreDataContext _context;
        public PessoaRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Pessoa> Get()
        {
            return _context.Pessoas.AsNoTracking().ToList();
        }
        public Pessoa Get(int id)
        {
            return _context.Pessoas.Find(id);
        }

        public void Save(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            _context.Entry<Pessoa>(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
        }

         public void Delete(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}