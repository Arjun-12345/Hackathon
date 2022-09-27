using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill_Grid("BUF039");
            }
        }

        private void Fill_Grid(string storeNo)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["RMConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand("GetUnavailableProduct", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@StoreNumber", storeNo);
            connection.Open();

            DataTable dt = new DataTable();

            dt.Load(command.ExecuteReader());
            grdProductReport.DataSource = dt;
            grdProductReport.DataBind();

        }

        protected void getReport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=ProductsNotAvailable.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            grdProductReport.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}