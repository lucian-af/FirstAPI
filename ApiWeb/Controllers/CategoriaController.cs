using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ApiWeb.Data;
using ApiWeb.Models.Produto;
using ApiWeb.Repositorios.Produto;
using ApiWeb.ViewModels;
using ApiWeb.ViewModels.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Controllers
{    
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly CategoriaRepositorio _repositorio;

        public CategoriaController(CategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #region HttpGet
        [Route("v1/categoria")]
        [HttpGet]
        public IEnumerable<lstCategoriaViewModel> GetAll()
        {
            return _repositorio.GetAll();
        }

        [Route("v1/categoria/{id}")]
        [HttpGet]
        public Categoria Get(int id)
        {
            return _repositorio.Get(id);
        }

        [Route("v1/categoria/{id}/produtos")]
        [HttpGet]
        public IEnumerable<lstProdutoViewModel> GetAllProdutos(int id)
        {
            return _repositorio.GetAllProdutosPorCategoria(id);
        }
        #endregion

        #region HttpPost
        [Route("v1/categoria")]
        [HttpPost]
        public ResultViewModel Post([FromBody] EdtCategoriaViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Mensagem = "Não foi possível cadastrar a categoria!",
                    Data = model.Notifications
                };
            }

            Categoria categoria = new Categoria();
            categoria.Titulo = model.Titulo;

            _repositorio.Save(categoria);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Categoria cadastrada com sucesso!",
                Data = categoria
            };
        }
        #endregion

        #region HttpPut
        [Route("v1/categoria")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EdtCategoriaViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Mensagem = "Não foi possível alterar o categoria!",
                    Data = model.Notifications
                };
            }

            Categoria categoria = _repositorio.Get(model.Id);
            categoria.Titulo = model.Titulo;            

            _repositorio.Update(categoria);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Categoria alterada com sucesso!",
                Data = categoria
            };
        }
        #endregion

        #region HttpDelete
        [Route("v1/categoria")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody] EdtCategoriaViewModel model)
        {
            Categoria categoria = _repositorio.Get(model.Id);

            if (categoria is null)
            {
                return new ResultViewModel
                {
                    Mensagem = "Categoria não encontrada!",
                    Data = categoria
                };
            }

            _repositorio.Delete(categoria);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Categoria excluída com sucesso!"
            };
        }
        #endregion
    }
}
