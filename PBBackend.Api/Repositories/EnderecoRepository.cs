using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBBackend.Api.Data;
using PBBackend.Api.Models;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.EnderecoViewModels;

namespace PBBackend.Api.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly StoreDataContext _context;
        public EnderecoRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Endereco> Get()
        {
            return _context.Enderecos.AsNoTracking().ToList();
        }
        public Endereco Get(int id)
        {
            return _context.Enderecos.Find(id);
        }

        public void Save(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void Update(Endereco endereco)
        {
            _context.Entry<Endereco>(endereco).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
        }
    }
}