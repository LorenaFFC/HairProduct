using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HairProduct
{
    public partial class RegistrarProdutoArquivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void download_ModeloPlanilha(object sender, EventArgs e)
        {
            Response.ContentType = "Application/xlsx";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ModeloPlanilha.xlsx");
            Response.TransmitFile(Server.MapPath("Files/ModeloPlanilha.xlsx"));
            Response.End();
        }
    }
}