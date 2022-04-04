using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using(var context = new InvoiceProjectDBEntities())
                {
                    // get total number of products in stock
                    var bananas = context.Products.Where(x => x.ProductName == "Banana").FirstOrDefault().QtyInStock;
                    var apples = context.Products.Where(x => x.ProductName == "Apple").FirstOrDefault().QtyInStock;
                    var pears = context.Products.Where(x => x.ProductName == "Pear").FirstOrDefault().QtyInStock;
                    var peaches = context.Products.Where(x => x.ProductName == "Peach").FirstOrDefault().QtyInStock;
                    var oranges = context.Products.Where(x => x.ProductName == "Orange").FirstOrDefault().QtyInStock;
                    var pinaples = context.Products.Where(x => x.ProductName == "Pinaple").FirstOrDefault().QtyInStock;

                    var total = bananas + apples + pears + peaches + oranges + pinaples;

                    lblTotalProducts.Text = total.ToString();

                    // get total number of products sold
                    bananas = context.Products.Where(x => x.ProductName == "Banana").FirstOrDefault().Sold;
                    apples = context.Products.Where(x => x.ProductName == "Apple").FirstOrDefault().Sold;
                    pears = context.Products.Where(x => x.ProductName == "Pear").FirstOrDefault().Sold;
                    peaches = context.Products.Where(x => x.ProductName == "Peach").FirstOrDefault().Sold;
                    oranges = context.Products.Where(x => x.ProductName == "Orange").FirstOrDefault().Sold;
                    pinaples = context.Products.Where(x => x.ProductName == "Pinaple").FirstOrDefault().Sold;

                    var totalSold = bananas + apples + pears + peaches + oranges + pinaples;

                    lblproductssold.Text = totalSold.ToString();

                    // get total number of products in stock
                    bananas = context.Products.Where(x => x.ProductName == "Banana").FirstOrDefault().QtyInStock;
                    apples = context.Products.Where(x => x.ProductName == "Apple").FirstOrDefault().QtyInStock;
                    pears = context.Products.Where(x => x.ProductName == "Pear").FirstOrDefault().QtyInStock;
                    peaches = context.Products.Where(x => x.ProductName == "Peach").FirstOrDefault().QtyInStock;
                    oranges = context.Products.Where(x => x.ProductName == "Orange").FirstOrDefault().QtyInStock;
                    pinaples = context.Products.Where(x => x.ProductName == "Pinaple").FirstOrDefault().QtyInStock;

                    total = bananas + apples + pears + peaches + oranges + pinaples;

                    lblproductsinstock.Text = total.ToString();

                    lblinstock.Text = total.ToString();
                    lblsold.Text = totalSold.ToString();

                    string item = "";
                    if(bananas > 5)
                    {
                        item = item + "Bananas, ";
                    }
                    if (apples > 5)
                    {
                        item = item + "Apple, ";
                    }
                    if (pears > 5)
                    {
                        item = item + "Pear, ";
                    }
                    if (peaches > 5)
                    {
                        item = item + "Peach, ";
                    }
                    if (oranges > 5)
                    {
                        item = item + "Orange, ";
                    }
                    if (pinaples > 5)
                    {
                        item = item + "Pinaple ";
                    }

                    if(item != "")
                    {
                        ErrorMessage(this, "Warning", "The Folowing items need to be restocked: " + item);
                        //Response.Write("<script>alert('The Folowing items neet to be restocked: \n" + item + "');</script>");
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void ErrorMessage(Control Control, string Message, string Title = "Alert", string callback = "")
        {
            try
            {
                ScriptManager.RegisterStartupScript(Control.Page, Control.GetType(), "Script", "swal('" + Title + "','" + Message + "','warning');", true);
            }
            catch (Exception ex)
            {
            }
        }
    }
}