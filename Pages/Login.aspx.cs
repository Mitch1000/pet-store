using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        PetStore.DB.Data oDB;
        PetStore.Class.User oUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            error.Style.Add("display", "none");

            string needlogout = "";
            needlogout = Request.QueryString["logout"];
            if (needlogout == "Y")
            {
                Session["User"] = null;
                Session["ShoppingCart"] = null;
                Response.Redirect("home.aspx");
            }

            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            oUser = new Class.User();

            if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                error.Style.Add("display", "");
                error.Text = "Please enter Email and Password.";
            }
            else
            {

                oUser = oDB.Login(txtEmail.Text, txtPassword.Text);
                if (oUser != null)
                {
                    Session["User"] = oUser;
                    Response.Redirect("home.aspx?login=Y");
                }
                else
                {
                    error.Style.Add("display", "");
                    error.Text = "Please check your email and password.";
                }

            }



        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");

        }
        
    }
}