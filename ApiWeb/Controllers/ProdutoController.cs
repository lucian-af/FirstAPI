using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _repositorio;

        public ProdutoController(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #region HttpGet
        [Route("v1/produto")]
        [HttpGet]
        [ResponseCache(Duration = 15)]
        public IEnumerable<lstProdutoViewModel> GetAll()
        {
            return _repositorio.GetAll();
        }

        [Route("v1/produto/{id}")]
        [HttpGet]
        public Produto Get(int id)
        {
            return _repositorio.Get(id);
        }
        #endregion

        #region HttpPost
        [Route("v1/produto")]
        [HttpPost]
        public ResultViewModel Post([FromBody] EdtProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Mensagem = "Não foi possível cadastrar o produto!",
                    Data = model.Notifications
                };
            }

            Produto produto = new Produto();
            produto.Titulo = model.Titulo;
            produto.CategoriaId = model.CategoriaId;
            produto.DataCriacao = DateTime.Now;
            produto.Descricao = model.Descricao;
            produto.CaminhoImagem = model.CaminhoImagem;
            produto.DataAlteracao = DateTime.Now;
            produto.Preco = model.Preco;
            produto.Quantidade = model.Quantidade;

            _repositorio.Save(produto);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Produto cadastrado com sucesso!",
                Data = produto
            };
        }
        #endregion

        #region HttpPost
        /// <summary>
        /// Solução alternativa para versionamento v1, v2, v3... etc;
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [Route("v2/produto")]
        [HttpPost]
        public ResultViewModel Post([FromBody] Produto produto)
        {
            _repositorio.Save(produto);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Produto cadastrado com sucesso!",
                Data = produto
            };
        }
        #endregion

        #region HttpPut
        [Route("v1/produto")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EdtProdutoViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Mensagem = "Não foi possível alterar o produto!",
                    Data = model.Notifications
                };
            }

            Produto produto = _repositorio.Get(model.Id);
            produto.Titulo = model.Titulo;
            produto.Descricao = model.Descricao;
            produto.Preco = model.Preco;
            produto.Quantidade = model.Quantidade;
            produto.CaminhoImagem = model.CaminhoImagem;
            produto.DataAlteracao = DateTime.Now;
            produto.CategoriaId = model.CategoriaId;

            _repositorio.Update(produto);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Produto alterado com sucesso!",
                Data = produto
            };
        }
        #endregion

        #region HttpDelete
        [Route("v1/produto")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody] EdtProdutoViewModel model)
        {
            Produto produto = _repositorio.Get(model.Id);

            if (produto is null)
            {
                return new ResultViewModel
                {
                    Mensagem = "Produto não encontrado!",
                    Data = produto
                };
            }

            _repositorio.Delete(produto);

            return new ResultViewModel
            {
                Sucesso = true,
                Mensagem = "Produto excluído com sucesso!"
            };
        }
        #endregion
    }
}