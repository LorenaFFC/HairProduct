using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairProduct.Entities
{
    public class Carrinho
    {
        public string Produto { get; set; }
        public string Preco { get; set; }
        public int Quantidade { get; set; }

        public Carrinho()
        {
        }

        public Carrinho(string produto, string preco, int quantidade)
        {
            Produto = produto;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}