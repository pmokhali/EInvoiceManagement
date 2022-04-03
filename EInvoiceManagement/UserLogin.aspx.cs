using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var result = false;
                var memberName = "";
                if (txtPassword.Text != "" && txtUsername.Text != "")
                {
                    using (var context = new InvoiceProjectDBEntities())
                    {
                        var member = from user in context.Members
                                     where user.Username == txtUsername.Text &&
                                     user.Password == txtPassword.Text && user.UserType == "user"
                                     select user;

                        if (member.Count() > 0)
                        {
                            result = true;
                            Session["username"] = txtUsername.Text;
                            Session["role"] = "user";
                            Response.Redirect("~/InvoiceLayout.aspx");
                        }
                        else
                        {
                            Response.Redirect(Request.RawUrl);
                        }

                    }
                }
                else
                {
                    Response.Write("<script>alert('Enter Username and Password');</script>");
                    return;
                }

                if (result)
                {
                    Response.Write("<script>alert('Welcome  " + memberName + "!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Username or Password');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error  " + ex.Message + "');</script>");
            }
        }
    }
}