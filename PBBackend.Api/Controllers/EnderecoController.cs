using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PBBackend.Api.Models;
using PBBackend.Api.Repositories;
using PBBackend.Api.ViewModels;
using PBBackend.Api.ViewModels.EnderecoViewModels;

namespace PBBackend.Api.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoRepository _repository;

        public EnderecoController(EnderecoRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/enderecos")]
        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            return _repository.Get();
        }

        [Route("v1/enderecos/{id}")]
        [HttpGet]
        public Endereco Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/enderecos")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorEnderecoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o endereço",
                    Data = model.Notifications
                };

            var endereco = new Endereco();
            endereco.Cep = model.Cep;
            endereco.Logradouro = model.Logradouro;
            endereco.Numero = model.Numero;
            endereco.Complemento = model.Complemento;
            endereco.Bairro = model.Bairro;
            endereco.CidadeId = model.CidadeId;
            endereco.PessoaId = model.PessoaId;
            endereco.DataCriacao = DateTime.Now;
            endereco.DataUltimaAlteracao = DateTime.Now;
            
            _repository.Save(endereco);
            return new ResultViewModel
            {
                Success = true,
                Message = "Endereço cadastrada com sucesso!",
                Data = endereco
            };
        }

        [Route("v1/enderecos")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorEnderecoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o endereço",
                    Data = model.Notifications
                };

            var endereco = _repository.Get(model.Id);
            endereco.Cep = model.Cep;
            endereco.Logradouro = model.Logradouro;
            endereco.Numero = model.Numero;
            endereco.Complemento = model.Complemento;
            endereco.Bairro = model.Bairro;
            endereco.CidadeId = model.CidadeId;
            endereco.PessoaId = model.PessoaId;
            //endereco.DataCriacao = DateTime.Now;
            endereco.DataUltimaAlteracao = DateTime.Now;

            _repository.Update(endereco);
            return new ResultViewModel
            {
                Success = true,
                Message = "Endereço alterado com sucesso!",
                Data = endereco
            };
        }

        [Route("v1/enderecos")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]EditorEnderecoViewModel model)
        {
            var endereco = _repository.Get(model.Id);

            _repository.Delete(endereco);

            return new ResultViewModel
            {
                Success = true,
                Message = "Endereço excluído com sucesso!",
                Data = endereco
            };
        }
    }
}