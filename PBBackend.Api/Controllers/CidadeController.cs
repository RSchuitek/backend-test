using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PBBackend.Api.Models;
using PBBackend.Api.Repositories;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.CidadeViewModels;

namespace PBBackend.Api.Controllers
{
    public class CidadeController : Controller
    {
        private readonly CidadeRepository _repository;

        public CidadeController(CidadeRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/cidades")]
        [HttpGet]
        public IEnumerable<Cidade> Get()
        {
            return _repository.Get();
        }

        [Route("v1/cidades/{id}")]
        [HttpGet]
        public Cidade Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/cidades")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorCidadeViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a cidade",
                    Data = model.Notifications
                };

            var cidade = new Cidade();
            cidade.Descricao = model.Descricao;
            cidade.Sigla = model.Sigla;
            cidade.EstadoId = model.EstadoId;
            cidade.DataCriacao = DateTime.Now;
            cidade.DataUltimaAlteracao = DateTime.Now;

            _repository.Save(cidade);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cidade cadastrada com sucesso!",
                Data = cidade
            };
        }

        [Route("v1/cidades")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorCidadeViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o cidade",
                    Data = model.Notifications
                };

            var cidade = _repository.Get(model.Id);
            cidade.Descricao = model.Descricao;
            cidade.Sigla = model.Sigla;
            cidade.EstadoId = model.EstadoId;
            //cidade.DataCriacao = DateTime.Now;
            cidade.DataUltimaAlteracao = DateTime.Now;

            _repository.Update(cidade);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cidade alterado com sucesso!",
                Data = cidade
            };
        }

        [Route("v1/cidades")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]EditorCidadeViewModel model)
        {
            var cidade = _repository.Get(model.Id);

            _repository.Delete(cidade);

            return new ResultViewModel
            {
                Success = true,
                Message = "Cidade excluída com sucesso!",
                Data = cidade
            };
        }
    }
}