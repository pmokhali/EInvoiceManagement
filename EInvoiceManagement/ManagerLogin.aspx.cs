using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class ManagerLogin : System.Web.UI.Page
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
                                     user.Password == txtPassword.Text && user.UserType == "manager"
                                     select user;

                        if (member.Count() > 0)
                        {
                            memberName = member.FirstOrDefault().FirstName.ToString();
                            Session["username"] = txtUsername.Text;
                            Session["role"] = "manager";
                            result = true;

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
                    Response.Redirect("~/InvoiceIssuing.aspx");

                }
                else
                {
                    Response.Redirect(Request.RawUrl);
                    Response.Write("<script>alert('Incorrect Username or Password');</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Incorrect Username or Password');</script>");
            }
        }
    }
}