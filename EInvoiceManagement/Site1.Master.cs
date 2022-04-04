using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = true;

                    LinkButton3.Visible = false;
                    LinkButton7.Visible = false;
                    LinkButton4.Visible = false;
                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton4.Visible = true;
                    LinkButton6.Visible = false;
                    LinkButton5.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton4.Visible = true;
                    LinkButton6.Visible = false;
                    LinkButton5.Visible = false;
                }
                else if (Session["role"].Equals("manager"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton4.Visible = false;
                    LinkButton6.Visible = false;
                    LinkButton5.Visible = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void CreateInvoices_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvoiceLayout.aspx");
        }

        protected void AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["role"] = "";
            Session["username"] = "";
            Response.Redirect("UserLogin.aspx");
        }

        protected void ManagerLogin_Click(object sender, EventArgs e)
        {
            Session["role"] = "";
            Session["username"] = "";
            Response.Redirect("ManagerLogin.aspx");
        }
    }
}