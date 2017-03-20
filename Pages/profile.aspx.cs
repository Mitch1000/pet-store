using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class profile : System.Web.UI.Page
    {
          PetStore.DB.Data oDB;
        PetStore.Class.User oUser;
        bool update = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            error.Style.Add("display", "none");
            result.Style.Add("display", "none");

            string CreateMsg = "";
            CreateMsg = Request.QueryString["Created"];
            if (CreateMsg == "Y")
            {
                result.Style.Add("display", "");
                result.Text = "The profile has been created.";

                PropertyInfo isreadonly =
  typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
  "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("Created");
            }


           
            if (!IsPostBack)
            {
                btnSubmit.Style.Add("display", "none");
                btnUpdate.Style.Add("display", "none");

            
                if (Session["User"] != null)
                {
                    PageTitle.Text = "Update my account";
                    btnUpdate.Style.Add("display", "");

                    oUser = (PetStore.Class.User) Session["User"];
                    update = true;
                    txtFirstname.Text = oUser.Address ;
                    oUser.City = txtLastName.Text=oUser.City ;
                     txtEmail.Text=oUser.Email;
                     txtEmail.Enabled = false;
                    txtFirstname.Text =oUser.FirstName ;
                    txtLastName.Text =oUser.LastName;
                    txtPassword.Text= oUser.Password ;
                    txtAddress.Text= oUser.Address;
                    txtCity.Text = oUser.City;
               
                    //oUser.PetType = ddlPettype.SelectedItem.Value;
                    txtPhone.Text= oUser.Phone;
                    txtPostal.Text = oUser.PostalCode;
                    txtProv.Text=oUser.Province;
                }
                else
                {

                    PageTitle.Text = "Register";
                    btnSubmit.Style.Add("display", "");

                    DataTable dtPetType = new DataTable();
                    dtPetType = oDB.GetPetType();

                    //ddlPettype.DataSource = dtPetType;
                    //ddlPettype.DataValueField = "PetType";
                    //ddlPettype.DataTextField = "Description";
                    //ddlPettype.DataBind();
                    //ddlPettype.Items.Insert(0, new ListItem("--Select your pet type--", ""));
                }
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

                            SmtpClient smtpClient = new SmtpClient();
                            MailMessage oMessage1 = new MailMessage();
                            oMessage1.Subject = "Registration confirmation";
                            oMessage1.Body = "Hi, <br/><br/><br/> Thanks for register to One Stop Pet Shop. <br /> Your User name is " + oUser.Email + "'. <br/><br/><br/><br/><br/><br/><br/><br/>One Stop Pet Shop team. ";
                            oMessage1.IsBodyHtml = true;

                            oMessage1.To.Add(new MailAddress(txtEmail.Text));
                            oMessage1.From = new MailAddress("test@hotmail.com"); // https://www.google.com/settings/security/lesssecureapps
                            smtpClient.Send(oMessage1);
                            oUser = oDB.Login(oUser.Email, oUser.Password);
                            
                                Session["User"] = oUser;
                                result.Style.Add("display", "");
                            result.Text = "The profile has been created.";
                            Session["User"] = oUser;
                            Response.Redirect("profile.aspx?Created=Y");
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
            else
            {
                 oUser = (PetStore.Class.User)Session["User"];
                 if ( txtPassword.Text == "" )
                 {
                    error.Style.Add("display", "");
                    error.Text = "Please enter your password.";
                }else{
                     oUser.Email = txtEmail.Text;
                    oUser.FirstName = txtFirstname.Text;
                    oUser.LastName = txtLastName.Text;
                    oUser.Password = txtPassword.Text;
                    oUser.Address = txtAddress.Text;
                    oUser.City = txtCity.Text;
                    oUser.Phone = txtPhone.Text;
                    oUser.PostalCode = txtPostal.Text;
                    oUser.Province = txtProv.Text;

                    oDB.UpdateUser(oUser);
                    Session["User"] = oUser;

                    result.Style.Add("display", "");
                    result.Text = "The profile has been updated.";
                }
                   
                   
            }

           

        }
    }
}