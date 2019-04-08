using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PBBackend.Api.Models;
using PBBackend.Api.Repositories;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.PessoaViewModels;

namespace PBBackend.Api.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaRepository _repository;

        public PessoaController(PessoaRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/pessoas")]
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return _repository.Get();
        }

        [Route("v1/pessoas/{id}")]
        [HttpGet]
        public Pessoa Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/pessoas")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorPessoaViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a pessoa",
                    Data = model.Notifications
                };

            var pessoa = new Pessoa();
            pessoa.Nome = model.Nome;
            pessoa.Email = model.Email;
            pessoa.DddTelefone = model.DddTelefone;
            pessoa.Telefone = model.Telefone;
            pessoa.DataCriacao = DateTime.Now;
            pessoa.DataUltimaAlteracao = DateTime.Now;

            _repository.Save(pessoa);

             return new ResultViewModel
            {
                Success = true,
                Message = "Pessoa cadastrada com sucesso!",
                Data = pessoa
            };
        }

        [Route("v1/pessoas")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorPessoaViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o pessoa",
                    Data = model.Notifications
                };

            var pessoa = _repository.Get(model.Id);
            pessoa.Nome = model.Nome;
            pessoa.Email = model.Email;
            pessoa.DddTelefone = model.DddTelefone;
            pessoa.Telefone = model.Telefone;
            pessoa.DataUltimaAlteracao = DateTime.Now;

            _repository.Update(pessoa);

            return new ResultViewModel
            {
                Success = true,
                Message = "Pessoa alterada com sucesso!",
                Data = pessoa
            };
        }

        [Route("v1/pessoas")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]EditorPessoaViewModel model)
        {
            var pessoa = _repository.Get(model.Id);

            _repository.Delete(pessoa);
            return new ResultViewModel
            {
                Success = true,
                Message = "Pessoa excluída com sucesso!",
                Data = pessoa
            };
        }
    }
}