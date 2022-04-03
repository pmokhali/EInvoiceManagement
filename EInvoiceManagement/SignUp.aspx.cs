using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EInvoiceManagement
{
    public partial class SignUp : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new InvoiceProjectDBEntities())
                {
                    var member = new Member()
                    {
                        FirstName = txtFirstname.Text,
                        LastName = txtLastName.Text,
                        Contact = txtContact.Text,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        Username = txtUserName.Text,
                        UserType = ddlUserType.SelectedValue
                    };
                    context.Members.Add(member);

                    context.SaveChanges();

                    Response.Redirect(Request.RawUrl);
                    
                }
                Response.Write("<script>alert('Saved successfully!');</script>");

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void ClearPage()
        {
            txtFirstname.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            //ddlUserType.SelectedValue = ddlUserType.SelectedVal
        }
    }
}