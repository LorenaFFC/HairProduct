using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairProduct.Entities
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Preco { get; set; }
        public string Url { get; set; }

        public Produto()
        {
        }
        public Produto(string nome, string categoria, string marca, string preco, string url)
        {
            Nome = nome;
            Categoria = categoria;
            Marca = marca;
            Preco = preco;
            Url= url;
        }
    }
}