using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProduto.Repositories
{
    public class ProdutoRepository
    {
        public CatalagoContext CatalagoContext;
        public ProdutoRepository(CatalagoContext catalagoContext)
        {
            CatalagoContext = catalagoContext;
        }

        public void Insert(Produto produto)
        {
            CatalagoContext.Produtos.Add(produto);
            CatalagoContext.SaveChanges();
        }

        public void Update(Produto produto)
        {
            //CatalagoContext.Entry<Produto>(produto).State = EntityState.Modified;
            CatalagoContext.Update(produto);
            CatalagoContext.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            CatalagoContext.Remove(produto);
            CatalagoContext.SaveChanges();
        }

        public Produto Get(int id)
        {
            var result = CatalagoContext.Produtos.Find(id);
            return result;
        }

        public IEnumerable<Produto> GetAll()
        {
            //Não retorna o controle de proxy do objeto (rastreamento se foi ou não modificado)
            var result = CatalagoContext.Produtos.AsNoTracking().ToList();
            return result;
        }
    }
}