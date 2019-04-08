using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBBackend.Api.Data;
using PBBackend.Api.Models;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.CidadeViewModels;

namespace PBBackend.Api.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly StoreDataContext _context;
        public CidadeRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Cidade> Get()
        {
            return _context.Cidades.AsNoTracking().ToList();
        }
        public Cidade Get(int id)
        {
            return _context.Cidades.Find(id);
        }

        public void Save(Cidade Cidade)
        {
            _context.Cidades.Add(Cidade);
            _context.SaveChanges();
        }

        public void Update(Cidade Cidade)
        {
            _context.Entry<Cidade>(Cidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Cidade Cidade)
        {
            _context.Cidades.Remove(Cidade);
            _context.SaveChanges();
        }
    }
}