using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class addpet : System.Web.UI.Page
    {
        PetStore.DB.Data oDB;
        PetStore.Class.User oUser;
        string PetName;
        string selectedValue;


        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            oUser = (PetStore.Class.User)Session["User"];
            btnUpdate.Text = "ADD";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            DateTime temp;
            if (DateTime.TryParse(Age.Text, out temp))
            {
                oDB.UpdatePet(txtFirstname.Text, "", oUser.ID, Age.Text, Weight.Text, ddlType.SelectedValue);
                result.Style.Add("display", "");
                result.Text = "The profile has been updated. Please add your pet(s).";
                Response.Redirect("pet.aspx?Name=" + txtFirstname.Text);
            }
            else
            {
                Age.Text = "Invalid Date Input";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("pet.aspx");
        }
    }
}