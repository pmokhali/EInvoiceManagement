using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class InvoiceLayout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.ToLongDateString();
            lblUser.Text = Session["username"].ToString();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                DataRow dr;

                // Add Columns to datatablse
                dt.Columns.Add(new DataColumn("ProductName")); //'ColumnName1' represents name of datafield in grid
                dt.Columns.Add(new DataColumn("UnitPrice"));
                dt.Columns.Add(new DataColumn("ProductQty"));
                dt.Columns.Add(new DataColumn("ItemTotal"));

                var price = double.Parse(txtPrice.Text);
                var qty = int.Parse(txtQuantity.Text);
                var itemTotal = price * qty;
                var totalprice = 0.0;
                // Add empty row first to DataTable to show as first row in gridview
                dr = dt.NewRow();
                dr["ProductName"] = productList.SelectedItem.Text;
                dr["UnitPrice"] = txtPrice.Text;
                dr["ProductQty"] = txtQuantity.Text;
                dr["ItemTotal"] = itemTotal.ToString();
                dt.Rows.Add(dr);
                totalprice = itemTotal;

                // Get each row from gridview and add it to DataTable
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    var productname = gvr.Cells[0].Text;
                    var unitprice = gvr.Cells[1].Text;
                    var quantity = gvr.Cells[2].Text;
                    var total = gvr.Cells[3].Text;

                    dr = dt.NewRow();
                        
                    dr["ProductName"] = productname;
                    dr["UnitPrice"] = unitprice;
                    dr["ProductQty"] = quantity;
                    dr["ItemTotal"] = total;
                    dt.Rows.Add(dr);

                    totalprice = totalprice + double.Parse(total);
                
                }

                // Add DataTable back to grid
                GridView1.DataSource = dt;
                GridView1.DataBind();

                lblTotal.Text = totalprice.ToString();

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

        
        protected void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new InvoiceProjectDBEntities())
                {
                    var idtemplate = "";
                    var invoiceCount = context.Invoice_Table.Count();


                    if (invoiceCount <= 0)
                    {
                        idtemplate = "inv_1";

                        // Populate Invoice table
                        foreach (GridViewRow gvr in GridView1.Rows)
                        {
                            var productname = gvr.Cells[0].Text;
                            var unitprice = gvr.Cells[1].Text;
                            var quantity = gvr.Cells[2].Text;
                            var total = gvr.Cells[3].Text;
                            var user = lblUser.Text;
                            var invTotal = lblTotal.Text;
                            var invDate = DateTime.Today.ToShortDateString();

                            var invoice = new Invoice_Table()
                            {
                                InvoiceID = idtemplate,
                                DateCreated = invDate,
                                InvoiceTotalPrice = invTotal,
                                ItemQuantity = int.Parse(quantity),
                                ItemTotalPrice = total,
                                ProductName = productname,
                                UnitPrice = unitprice
                            };

                            context.Invoice_Table.Add(invoice);

                            if(productname == "Apple")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                            }
                            //context.SaveChanges();

                        }

                    }
                    else
                    {
                        // Create string ID
                        idtemplate = context.Invoice_Table.OrderByDescending(x => x.Oid).FirstOrDefault().InvoiceID;
                        var idstringIdentifier = idtemplate.Split('_').Last();
                        var idNum = int.Parse(idstringIdentifier);
                        idNum++;
                        idtemplate = "inv_" + idNum;

                        // Populate Invoice table
                        foreach (GridViewRow gvr in GridView1.Rows)
                        {
                            var productname = gvr.Cells[0].Text;
                            var unitprice = gvr.Cells[1].Text;
                            var quantity = gvr.Cells[2].Text;
                            var total = gvr.Cells[3].Text;
                            var user = lblUser.Text;
                            var invTotal = lblTotal.Text;
                            var invDate = DateTime.Today.ToShortDateString();

                            var invoice = new Invoice_Table()
                            {
                                InvoiceID = idtemplate,
                                DateCreated = invDate,
                                InvoiceTotalPrice = invTotal,
                                ItemQuantity = int.Parse(quantity),
                                ItemTotalPrice = total,
                                ProductName = productname,
                                UnitPrice = unitprice
                            };

                            context.Invoice_Table.Add(invoice);

                            if (productname == "Apple")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                                var sold = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold;
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold = sold + int.Parse(quantity);
                            }
                            else if(productname == "Banana")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                                var sold = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold;
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold = sold + int.Parse(quantity);
                            }
                            else if (productname == "Pear")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                                var sold = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold;
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold = sold + int.Parse(quantity);
                            }
                            else if (productname == "Peach")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                                var sold = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold;
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold = sold + int.Parse(quantity);
                            }
                            else if (productname == "Orange")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                                var sold = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold;
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold = sold + int.Parse(quantity);
                            }
                            else if (productname == "Pinaple")
                            {
                                var itemsInStock = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock;
                                var itemsRemaining = itemsInStock - int.Parse(quantity);
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().QtyInStock = itemsRemaining;
                                var sold = context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold;
                                context.Products.Where(x => x.ProductName == productname).FirstOrDefault().Sold = sold + int.Parse(quantity);
                            }
                        }
                    }

                    context.SaveChanges();
                }

                Alert(this, "Success", "Invoice Saved!");
            }
            catch (Exception ex)
            {

            }
            
        }

        protected void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(productList.SelectedValue == "pear")
            {
                txtPrice.Text = "4.50";
            }
            else if (productList.SelectedValue == "peach")
            {
                txtPrice.Text = "1.50";
            }
            else if (productList.SelectedValue == "banana")
            {
                txtPrice.Text = "3.00";
            }
            else if (productList.SelectedValue == "apple")
            {
                txtPrice.Text = "3.50";
            }
            else if (productList.SelectedValue == "orange")
            {
                txtPrice.Text = "4.00";
            }
            else if (productList.SelectedValue == "pinaple")
            {
                txtPrice.Text = "10.00";
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