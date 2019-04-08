using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PBBackend.Api.Models;
using PBBackend.Api.Repositories;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.EstadoViewModels;

namespace PBBackend.Api.Controllers
{
    public class EstadoController : Controller
    {
        private readonly EstadoRepository _repository;

        public EstadoController(EstadoRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/estados")]
        [HttpGet]
        public IEnumerable<Estado> Get()
        {
            return _repository.Get();
        }

        [Route("v1/estados/{id}")]
        [HttpGet]
        public Estado Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/estados")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorEstadoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a estado",
                    Data = model.Notifications
                };

            var estado = new Estado();
            estado.Descricao = model.Descricao;
            estado.Sigla = model.Sigla;
            estado.DataCriacao = DateTime.Now;
            estado.DataUltimaAlteracao = DateTime.Now;

            _repository.Save(estado);

            return new ResultViewModel
            {
                Success = true,
                Message = "Estado cadastrada com sucesso!",
                Data = estado
            };
        }

        [Route("v1/estados")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorEstadoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o estado",
                    Data = model.Notifications
                };

            var estado = _repository.Get(model.Id);
            estado.Descricao = model.Descricao;
            estado.Sigla = model.Sigla;
            //estado.DataCriacao = DateTime.Now;
            estado.DataUltimaAlteracao = DateTime.Now;

            _repository.Update(estado);

            return new ResultViewModel
            {
                Success = true,
                Message = "Estado alterado com sucesso!",
                Data = estado
            };
        }

        [Route("v1/estados")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]EditorEstadoViewModel model)
        {
            var estado = _repository.Get(model.Id);

            _repository.Delete(estado);

            return new ResultViewModel
            {
                Success = true,
                Message = "Estado excluída com sucesso!",
                Data = estado
            };
        }
    }
}