using HairProduct.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HairProduct.ado
{
    public class OperacoesBD
    {


        public void InsercaoBD_Produto(Produto produto)
        {
            string query = "INSERT INTO SalesProducts.dbo.PRODUTOS (Produto,Categoria,Marca,Preco,Url) VALUES (@Produto,@Categoria,@Marca,@Preco,@Url)";

            SqlParameter[] parameterList = { new SqlParameter("@Produto", produto.Nome),
                                             new SqlParameter("@Categoria", produto.Categoria),
                                             new SqlParameter("@Marca", produto.Marca),
                                             new SqlParameter("@Preco", produto.Preco),
                                             new SqlParameter("@Url", produto.Url) };
            Connection.ExecuteNonQuery(query, parameterList);

        }

        public void InsercaoBD_Image(Imagem imagem)
        {
            string query = "INSERT INTO SalesProducts.dbo.Images (Nome, Url) VALUES (@Nome,@Url) ";

            SqlParameter[] parameterList = { new SqlParameter("@Nome", imagem.Nome),
                                             new SqlParameter("@Url", imagem.Url) };

            Connection.ExecuteNonQuery(query, parameterList);
        }

    }
}