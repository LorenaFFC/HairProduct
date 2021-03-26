using HairProduct.ado;
using HairProduct.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairProduct
{
    public partial class Products : System.Web.UI.Page
    {
        string qtd = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                add_Nomes();
                CarregaProdutos();
               
            }
        }


        protected void add_Nomes()
        {
            //Inserindo Primeira Linha Categoria
            CategoriaFiltro.AppendDataBoundItems = true;
            CategoriaFiltro.Items.Insert(0, ".Selecione Categoria.");

            //Inserindo Primeira Linha Marca
            MARCAfiltro.AppendDataBoundItems = true;
            MARCAfiltro.Items.Insert(0, new ListItem(".Selecione Marca."));
        }
        protected void Btn_FiltrarProdutos(object sender, EventArgs e)
        {
            
            string nomeCategoria = CategoriaFiltro.SelectedValue.ToString();
            string nomeMarca = MARCAfiltro.SelectedValue.ToString();
            string nomeProduto = txt_nomeproduto.Text;

            if (nomeCategoria==".Selecione Categoria." || nomeMarca== ".Selecione Categoria.")
            {
                nomeCategoria = null;
                nomeMarca = null;
            }
            Connection.GetSqlConnection();
            OperacoesBD bd = new OperacoesBD();
     
            Repeater1.DataSource = bd.RetornaProdutosFiltrados(nomeCategoria, nomeMarca, nomeProduto); 
            Repeater1.DataBind();

            Repeater2.Visible = false;



        }

        protected void CarregaProdutos()
        {//where IM.id not in('1','2','3','4','5')
            string querytop = "select TOP 5 NOME, PRECO,IM.Url FROM SalesProducts.dbo.Images IM INNER JOIN SalesProducts.dbo.PRODUTOS  PM on ( IM.Nome = PM.Produto AND IM.Url = PM.Url) ;";
            string query = "SELECT NOME, PRECO, IM.Url FROM SalesProducts.dbo.Images IM INNER JOIN SalesProducts.dbo.PRODUTOS  PM on ( IM.Nome = PM.Produto AND IM.Url = PM.Url)where IM.id not in('1','2','3','4','5') ";
            Connection.GetSqlConnection();
            DataTable dttop = Connection.ExecuteQuery(querytop);
            DataTable dt = Connection.ExecuteQuery(query);
            Repeater1.DataSource = dttop;
            Repeater1.DataBind();
           Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }



        protected void BTN_AdicionarCarrinho_Click(object sender, EventArgs e)
        {
            OperacoesBD operacoesBD = new OperacoesBD();
                   
            Button saveOrUpdate = (sender as Button);
            RepeaterItem item = saveOrUpdate.NamingContainer as RepeaterItem;
            string nome_Produto = (item.FindControl("Lbl_NomeProduto") as Label).Text;
            string preco_Produto = (item.FindControl("Lbl_PrecoProduto") as Label).Text;

            // definindo Carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.Produto = nome_Produto;
            carrinho.Preco = preco_Produto;
            carrinho.Quantidade = 1;

            // funcao para adicionar no BD
            operacoesBD.InsercaoBD_Carrinho(carrinho);
            lit_qtd.Text = qtdProdutos();
        }

        protected string  qtdProdutos()
        {
            string query_Qtd_Produtos = "select Quantidade  from SalesProducts.dbo.Carrinho";
            Connection.GetSqlConnection();
            DataTable dttop = Connection.ExecuteQuery(query_Qtd_Produtos);

            object qtd_Total;
            qtd_Total = dttop.Compute("Sum(Quantidade)", string.Empty);

            return qtd_Total.ToString();
        }
        
   

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}

//SELECT DISTINCT '.. Selecione ..' as Categoria from  SalesProducts.dbo.PRODUTOS union all 