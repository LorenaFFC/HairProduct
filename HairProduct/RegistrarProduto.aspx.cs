using HairProduct.ado;
using HairProduct.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairProduct
{
    public partial class RegistrarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Message = "asas";
            Response.Write("<script> alert('" + img_Produto.PostedFile.FileName.ToString() + "'); </script>");
            CadastraProduto();
        }

        protected void CadastraProduto()
        {
            string nomeImagem = img_Produto.PostedFile.FileName.ToString();
            OperacoesBD BD = new OperacoesBD();
            Produto prod = new Produto();
            prod.Nome = txt_Produto.Text;
            prod.Categoria = Categoria.SelectedValue.ToString();
            prod.Marca = txt_Marca.Text;
            prod.Preco = txt_Preco.Text;
            prod.Url = salvarImagem(nomeImagem);
            BD.InsercaoBD_Produto(prod);
            CadastrarImagem(nomeImagem, salvarImagem(nomeImagem));
        }

        private string salvarImagem(string url)
        {
            string path = "root/imagens/" + url.ToString();
            img_Produto.PostedFile.SaveAs(Server.MapPath(path));
            return path;
        }

        protected void CadastrarImagem(string nome, string url)
        {
            Imagem img = new Imagem();
            OperacoesBD bd = new OperacoesBD();
            img.Nome = nome;
            img.Url = url;
            bd.InsercaoBD_Image(img);
        }


    }
}