using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace EInvoiceManagement
{
    public partial class InvoiceLayout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        int rowcount = 0;
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                DataRow dr;

                // Add Columns to datatablse
                dt.Columns.Add(new DataColumn("ProductName")); //'ColumnName1' represents name of datafield in grid
                dt.Columns.Add(new DataColumn("DateCreated"));
                dt.Columns.Add(new DataColumn("UnitPrice"));
                dt.Columns.Add(new DataColumn("ProductQty"));
                dt.Columns.Add(new DataColumn("ItemTotal"));

                var price = double.Parse(txtPrice.Text);
                var qty = int.Parse(txtQuantity.Text);
                var itemTotal = price * qty;

                // Add empty row first to DataTable to show as first row in gridview
                dr = dt.NewRow();
                dr["ProductName"] = productList.SelectedItem.Text;
                dr["DateCreated"] = txtDate.Text;
                dr["UnitPrice"] = txtPrice.Text;
                dr["ProductQty"] = txtQuantity.Text;
                dr["ItemTotal"] = itemTotal.ToString();
                dt.Rows.Add(dr);

                // Get each row from gridview and add it to DataTable
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    var productname = gvr.Cells[0].Text;
                    var datecreated = gvr.Cells[1].Text;
                    var unitprice = gvr.Cells[2].Text;
                    var quantity = gvr.Cells[3].Text;
                    var total = gvr.Cells[4].Text;

                    dr = dt.NewRow();
                        
                    dr["ProductName"] = productname;
                    dr["DateCreated"] = datecreated;
                    dr["UnitPrice"] = unitprice;
                    dr["ProductQty"] = quantity;
                    dr["ItemTotal"] = total;
                    dt.Rows.Add(dr);
                    
                    
                
                }

                // Add DataTable back to grid
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string productName = GridView1.SelectedRow.Cells[0].Text;
            //string username = GridView1.SelectedRow.Cells[1].Text;
            //string dateCreated = GridView1.SelectedRow.Cells[2].Text;
            //string total = GridView1.SelectedRow.Cells[3].Text;
            //string quantity = GridView1.SelectedRow.Cells[4].Text;

            //var invoiceID = 0;
            //decimal ttl = Convert.ToDecimal(total);
            //int qty = int.Parse(quantity);

            ////txtDate.Text = dateCreated;
            //txtQuantity.Text = quantity;
            //txtUsername.Text = username;
            //productList.SelectedItem.Text = productName;

            //var dt = DateTime.Parse(dateCreated);
            //txtDate.Text = dt.ToString();

            //using (var context = new InvoiceProjectDBEntities())
            //{
            //    var productID = context.Products.Where(y => y.ProductName == productName).FirstOrDefault().Oid;
            //    var userID = context.Members.Where(x => x.Username == txtUsername.Text).FirstOrDefault().Oid;
            //    invoiceID = context.Invoices.Where(x => x.DateCreated == dt &&
            //                    x.ProductID == productID &&
            //                    x.Total == ttl &&
            //                    x.UserID == userID &&
            //                    x.ProductQty == qty).FirstOrDefault().Oid;


            //}

            //txtoid.Text = invoiceID.ToString();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            //    e.Row.Attributes["style"] = "cursor:pointer";
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //int oid = int.Parse(txtoid.Text);
                //using (var context = new InvoiceProjectDBEntities())
                //{
                //    var invoice = context.Invoices.Where(x => x.Oid == oid).FirstOrDefault();
                //    if (invoice != null)
                //    {
                //        var price = double.Parse(txtPrice.Text);
                //        var quantity = int.Parse(txtQuantity.Text);
                //        var total = price * quantity;
                //        var productID = context.Products.Where(x => x.ProductName == productList.SelectedItem.Text).FirstOrDefault().Oid;
                //        var userID = context.Members.Where(x => x.Username == txtUsername.Text).FirstOrDefault().Oid;

                //        invoice.ProductID = productID;
                //        invoice.ProductQty = quantity;
                //        invoice.Total = Convert.ToDecimal(total);
                //        invoice.UserID = userID;
                //        invoice.DateCreated = DateTime.Parse(txtDate.Text);

                //        context.SaveChanges();
                //    }
                //}
                //GridView1.DataBind();
                //Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {

            }
        }
    }
}