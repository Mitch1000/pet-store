using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore
{
    public partial class Login : System.Web.UI.Page
    {
        PetStore.DB.Data oDB;

        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            //Submit.Click += new EventHandler(this.Submit_Click);
           // btnLogin.ServerClick += new EventHandler(this.btnLogin_ServerClick);
            error.Text = "";
        }

        protected void Submit_Click(Object sender, EventArgs e)
        {
            bool login = oDB.login(email.Text, password.Text);
           if (login)
           {
               Response.Redirect("Pages/welcome.aspx");
           }
           else
           {
               error.Text ="Please check your username and password";
           }

        }


        // <a href="/Pages/welcome.aspx" id="btnLogin" runat="server" ><img src="/Images/login.jpg" /></a>
        // <asp:LinkButton ID="linkLogin" runat="server" OnClick="btnLogin1_ServerClick" Text="LOGIN" />
        protected void btnLogin_ServerClick(Object sender, EventArgs e) 
            {
                bool login = oDB.login(email.Text, password.Text);
                if (login)
                {
                    Response.Redirect("Pages/welcome.aspx");
                }
                else
                {
                    error.Text = "Please check your username and password";
                }
            }


        

             protected void btnLogin1_ServerClick(Object sender, EventArgs e) 
            {
                bool login = oDB.login(email.Text, password.Text);
                if (login)
                {
                    Response.Redirect("Pages/welcome.aspx");
                }
                else
                {
                    error.Text = "Please check your username and password";
                }
            }


             protected void RetrivePassword_Click(Object sender, EventArgs e)
             {
                 
                     Response.Redirect("Pages/welcome.aspx");
                 
             }


    }
}