using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class Invoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string invoiceID = GridView1.SelectedRow.Cells[0].Text;

            using (var context = new InvoiceProjectDBEntities())
            {
                var invoices = context.Invoice_Table.Where(x => x.InvoiceID == invoiceID).ToList();

                GridView2.DataSource = invoices;
                GridView2.DataBind();

            }

            txtoid.Text = invoiceID.ToString();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        
        protected void OnInvoiceRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        
                
        public void Alert(Control Control, string Message, string Title = "Alert", string callback = "")
        {
            try
            {
                ScriptManager.RegisterStartupScript(Control.Page, Control.GetType(), "Script", "swal('" + Title + "','" + Message + "','success');", true);
            }
            catch (Exception ex)
            {
            }
        }
    }
}