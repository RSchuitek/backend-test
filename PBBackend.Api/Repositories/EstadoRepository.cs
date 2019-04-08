using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBBackend.Api.Data;
using PBBackend.Api.Models;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.EstadoViewModels;

namespace PBBackend.Api.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly StoreDataContext _context;
        public EstadoRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Estado> Get()
        {
            return _context.Estados.AsNoTracking().ToList();
        }
        public Estado Get(int id)
        {
            return _context.Estados.Find(id);
        }

        public void Save(Estado estado)
        {
            _context.Estados.Add(estado);
            _context.SaveChanges();
        }

        public void Update(Estado estado)
        {
            _context.Entry<Estado>(estado).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Estado estado)
        {
            _context.Estados.Remove(estado);
            _context.SaveChanges();
        }
    }
}