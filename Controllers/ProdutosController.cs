using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.ViewModels;
using CatalogoProduto.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepository ProdutoRepository; 
        public ProdutosController(ProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        [HttpGet]
        [Route("versao")]
        public string Versao()
        {
            return "Versão: 2.0";
        }

        [HttpPost]
        [Route("incluir")]
        public void Insert([FromBody] InserirProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto(); 
            produto.Nome = produtoViewModel.Nome;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Preco = produtoViewModel.Preco;
            produto.Criacao = DateTime.Now;

            ProdutoRepository.Insert(produto);
        }

        [HttpPut]
        [Route("editar")]
        public void Edit([FromBody] EditarProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto(); 
            produto.Id = produtoViewModel.Id;
            produto.Nome = produtoViewModel.Nome;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Preco = produtoViewModel.Preco;
            produto.Alteracao = DateTime.Now;

            ProdutoRepository.Update(produto);
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public void Delete(int id)
        {
            var result = ProdutoRepository.Get(id);
            if (result.Id > 0)
            {
                ProdutoRepository.Delete(result);
            }
        }

        [HttpGet]
        [Route("obter/{id}")]
        public ObterProdutoViewModel Get(int id)
        {
            var result = ProdutoRepository.Get(id);

            return new ObterProdutoViewModel(){
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                Preco = result.Preco,
                Quantidade = result.Quantidade
            };
        }

        [HttpGet]
        [Route("obtertodos")]
        public IEnumerable<ObterTodosProdutoViewModel> GetAll()
        {
            IList<ObterTodosProdutoViewModel> lista = new List<ObterTodosProdutoViewModel>();
            
            var result = ProdutoRepository.GetAll();

            foreach (var produto in result)
            {
                lista.Add(new ObterTodosProdutoViewModel(){
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    DataCriacao = produto.Criacao,
                    DataAlteracao = produto.Alteracao
                });
            }
            
            return lista;
        }
    }
}
