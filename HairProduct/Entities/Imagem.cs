using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HairProduct.Entities
{
    public class Imagem
    {
        public string Nome { get; set; }
        public string Url { get; set; }

        public Imagem()
        {
        }

        public Imagem(string nome, string url)
        {
            Nome = nome;
            Url = url;
        }
    }
}