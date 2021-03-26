using HairProduct.ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairProduct
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1_SelectedIndexChanged();
                lit_value_total.Text = Subtotal();
            }
        }
      

        protected void GridView1_SelectedIndexChanged()
        {
            string query = "SELECT *, quantidade* cast(preco as numeric(9,2) ) as total FROM SalesProducts.dbo.Carrinho ";
            Connection.GetSqlConnection();
            DataTable dt = Connection.ExecuteQuery(query);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1_SelectedIndexChanged();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var quantidadeProduto = ((GridView1.Rows[e.RowIndex].FindControl("txt_qtde") as TextBox).Text.Trim());

            

            string query = "UPDATE [SalesProducts].[dbo].[CARRINHO] SET [Quantidade] = @Quantidade WHERE [ID]=@ID";

            SqlCommand command = new SqlCommand(query, Connection.GetSqlConnection());
            command.Parameters.AddWithValue("@Quantidade", quantidadeProduto);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            command.ExecuteNonQuery();

            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();
            lit_value_total.Text = Subtotal();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GridView1_SelectedIndexChanged();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String query = "Delete [SalesProducts].[dbo].[CARRINHO]  WHERE [ID]=@ID";

            SqlCommand command = new SqlCommand(query, Connection.GetSqlConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            command.ExecuteNonQuery();

            GridView1.EditIndex = -1;
            GridView1_SelectedIndexChanged();
            lit_value_total.Text = Subtotal();
        }

        protected string Subtotal()
        {
            string query_Qtd_Produtos = "select quantidade* cast(preco as numeric(9,2) ) as total  from SalesProducts.dbo.Carrinho";
            Connection.GetSqlConnection();
            DataTable dttop = Connection.ExecuteQuery(query_Qtd_Produtos);

            object qtd_Total;
            qtd_Total = dttop.Compute("Sum(total)", string.Empty);

            return qtd_Total.ToString();
        }

        protected void ContinuarComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}