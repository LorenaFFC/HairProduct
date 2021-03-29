using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HairProduct.ado
{
    public class Connection
    {
        public static SqlConnection GetSqlConnection()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connStrig;
            connStrig = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            var SQLConnection = new SqlConnection(connStrig.ToString());
            SQLConnection.Open();
            return SQLConnection;
        }
        public static DataTable ExecuteQuery(string QueryCliente)
        {
            var connection = GetSqlConnection();
            SqlDataAdapter sqlData = new SqlDataAdapter(QueryCliente, connection);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            return dtbl;
        }
        public static void ExecuteNonQuery(string CommandText, params SqlParameter[] commandParameters)
        {
            var conection = GetSqlConnection();
            SqlCommand cmd = new SqlCommand(CommandText, conection);

            //  cmd.Connection = GetSqlConnection();*/
            cmd.Parameters.AddRange(commandParameters);
            cmd.ExecuteNonQuery();
        }

        public static OleDbConnection ConnectionExcel(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)

            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;

                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }

            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            cmdExcel.Connection = connExcel;
            connExcel.Open();
            return connExcel;
        }
        public static OleDbConnection DisconnectionExcel(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)

            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;

                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }

            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            cmdExcel.Connection = connExcel;
            connExcel.Close();
            return connExcel;
        }

    }
}