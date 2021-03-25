using HairProduct.ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairProduct
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string querytop = "select TOP 5 NOME, PRECO,IM.Url FROM SalesProducts.dbo.Images IM INNER JOIN SalesProducts.dbo.PRODUTOS  PM on ( IM.Nome = PM.Produto AND IM.Url = PM.Url) ORDER BY IM.Id ASC;";
            string query = "SELECT NOME, PRECO, IM.Url FROM SalesProducts.dbo.Images IM INNER JOIN SalesProducts.dbo.PRODUTOS  PM on ( IM.Nome = PM.Produto AND IM.Url = PM.Url) where IM.id not in('1','2','3','4','5')";
            Connection.GetSqlConnection();
            DataTable dttop = Connection.ExecuteQuery(querytop);
            DataTable dt = Connection.ExecuteQuery(query);
            Repeater1.DataSource = dttop;
            Repeater1.DataBind();
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
            
        }
    }
}