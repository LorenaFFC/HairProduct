using HairProduct.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HairProduct.ado
{
    public class OperacoesBD
    {


        public void InsercaoBD_Produto(Produto produto)
        {
            string query = "INSERT INTO SalesProducts.dbo.PRODUTOS (Produto,Categoria,Marca,Status,Preco,Url) VALUES (@Produto,@Categoria,@Marca, @Status, @Preco,@Url)";

            SqlParameter[] parameterList = { new SqlParameter("@Produto", produto.Nome),
                                             new SqlParameter("@Categoria", produto.Categoria),
                                             new SqlParameter("@Marca", produto.Marca),
                                             new SqlParameter("@Marca", produto.Status),
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

        public void InsercaoBD_Carrinho(Carrinho carrinho)
        {
            string query = "INSERT INTO SalesProducts.dbo.Carrinho (Produto, Preco, Quantidade) VALUES (@Produto,@Preco, @Quantidade) ";

            SqlParameter[] parameterList = { new SqlParameter("@Produto", carrinho.Produto),
                                             new SqlParameter("@Preco", carrinho.Preco),
                                              new SqlParameter("@Quantidade", carrinho.Quantidade)};

            Connection.ExecuteNonQuery(query, parameterList);
        }

       
        public DataSet RetornaProdutosFiltrados(string categoria, string marca, string status, string nome)
        {
            string query = "SalesProducts.dbo.Filter_Produtos";
            SqlCommand com = new SqlCommand(query, Connection.GetSqlConnection());
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter param = com.CreateParameter();
            param.ParameterName = "@nomeCategoria";
            param.Value = categoria;
            param.DbType = DbType.String;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@nomeMarca";
            param.Value = marca;
            param.DbType = DbType.String;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@nomeStatus";
            param.Value = status;
            param.DbType = DbType.String;
            com.Parameters.Add(param);

            param = com.CreateParameter();
            param.ParameterName = "@nomeProduto";
            param.Value = nome;
            param.DbType = DbType.String;
            com.Parameters.Add(param);

          

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet dset = new DataSet();
            adapter.Fill(dset, "t1");
            var result = com.ExecuteReader();
            return dset;

            /* PROCEDURE CRIADA:
             use SalesProducts
                go
                CREATE PROCEDURE Filter_Produtos
                @nomeCategoria VARCHAR(MAX),
                @nomeMarca	   VARCHAR(MAX),
                @nomeProduto VARCHAR(MAX),
				@nomeStatus VARCHAR(MAX)
                AS
                SELECT 
	                NOME, 
	                PRECO,
	                IM.Url 
                FROM SalesProducts.dbo.Images IM 
                INNER JOIN SalesProducts.dbo.PRODUTOS  PM on (IM.Nome = PM.Produto AND IM.Url = PM.Url)
                WHERE 
	                1=1
	                AND (@nomeCategoria IS NULL OR(PM.CATEGORIA = @nomeCategoria))
	                AND (@nomeMarca IS NULL OR (PM.MARCA = @nomeMarca)) 
	                AND (@nomeProduto IS NULL OR (PM.PRODUTO like '%' + @nomeProduto + '%'))
					AND (@nomeStatus IS NULL OR (PM.STATUS = @nomeStatus));
                RETURN 
                GO


                      */
        }

        public void AlterQtdeCarrinho(int quantidade)
        {

        }
    }
}