using System;

namespace API.ViewModels
{
    public class InserirProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }

    public class EditarProdutoViewModel : InserirProdutoViewModel
    {
        public int Id { get; set; }
    }

    public class ObterProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }

    public class ObterTodosProdutoViewModel : ObterProdutoViewModel
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}