using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

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

                HtmlTableRow row = new HtmlTableRow();

                HtmlTableCell product = new HtmlTableCell();
                var lblproduct = new Label();
                lblproduct.Text = productList.SelectedItem.Text;
                product.Controls.Add(lblproduct);
                //add cell to row
                row.Cells.Add(product);

                HtmlTableCell qty = new HtmlTableCell();
                var lblqty = new Label();
                lblqty.Text = txtQuantity.Text;
                qty.Controls.Add(lblqty);
                //add cell to row
                row.Cells.Add(qty);

                HtmlTableCell price = new HtmlTableCell();
                var lblprice = new Label();
                lblprice.Text = txtPrice.Text;
                price.Controls.Add(lblprice);
                //add cell to row
                row.Cells.Add(price);

                HtmlTableCell total = new HtmlTableCell();
                var lbltotal = new Label();
                var pprice = double.Parse(txtPrice.Text);
                var quantity = int.Parse(txtQuantity.Text);
                var totalPrice = pprice * quantity;
                lbltotal.Text = totalPrice.ToString();
                total.Controls.Add(lbltotal);
                //add cell to row
                row.Cells.Add(total);
                
                //add row to dt
                var count = tblInvoice.Rows.Count;
                tblInvoice.Rows.Add(row);
                //ViewState["CurrentTable"] = tblInvoice;
                tblInvoice.DataBind();
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