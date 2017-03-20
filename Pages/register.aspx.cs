using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PetStore.Pages
{
    public partial class register : System.Web.UI.Page
    {
        PetStore.DB.Data oDB;
        PetStore.Class.User oUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            error.Style.Add("display", "none");
            result.Style.Add("display", "none");

          

            if (!IsPostBack)
            {
                
                //if (Session["User"] != null)
                //{
                //    PageTitle.Text = "Update my account";

                //    oUser = (PetStore.Class.User)Session["User"];
                //    txtFirstname.Text = oUser.Address;
                //    oUser.City = txtLastName.Text = oUser.City;
                //    txtEmail.Text = oUser.Email;
                //    txtFirstname.Text = oUser.FirstName;
                //    txtLastName.Text = oUser.LastName;
                //    txtPassword.Text = oUser.Password;
                //    txtAddress.Text = oUser.Address;
                //    txtCity.Text = oUser.City;

                //    //oUser.PetType = ddlPettype.SelectedItem.Value;
                //    txtPhone.Text = oUser.Phone;
                //    txtPostal.Text = oUser.PostalCode;
                //    txtProv.Text = oUser.Province;
                //}
                //else
                //{
                //    //result.Style.Add("display", "");
                //    //result.Text = "The profile has been created.";
                //}
                
            }
           
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                oUser = new Class.User();
                oUser.ID = -1;


                if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text))
                {
                    error.Style.Add("display", "");
                    error.Text = "Email and Password are required fields.";
                }
                else
                {
                    
                    oUser.Email = txtEmail.Text;
                    oUser.FirstName = txtFirstname.Text;
                    oUser.LastName = txtLastName.Text;
                    oUser.Password = txtPassword.Text;
                    oUser.Address = txtAddress.Text;
                    oUser.City = txtCity.Text;
                    //oUser.PetType = ddlPettype.SelectedItem.Value;
                    oUser.Phone = txtPhone.Text;
                    oUser.PostalCode = txtPostal.Text;
                    oUser.Province = txtProv.Text;


                    if (!oDB.IsUserExist(oUser))
                    {
                        if (oDB.UpdateUser(oUser))
                        {
                            result.Style.Add("display", "");
                            result.Text = "The profile has been created.";
                            Session["User"] = oUser;
                           // Response.Redirect("register.aspx?reg=1");
                            Response.Redirect("home.aspx");
                        }
                        else
                        {
                            error.Style.Add("display", "");
                            error.Text = "Unexpected Error occurs. Please try it again later.";
                        }
                    }
                    else
                    {
                        error.Style.Add("display", "");
                        error.Text = "The Email address already exists";
                    }

                }
            }
           
        }
    }
}