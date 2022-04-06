using System;
using System.Configuration;
using System.Web.UI;

namespace EInvoiceManagement
{
    public partial class SignUp : Page
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

                    ClearPage();

                }
                //Alert(this, "Success", "Saved successfully");
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