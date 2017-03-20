using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace PetStore.Pages
{
    public partial class pet : System.Web.UI.Page
    {
        PetStore.DB.Data oDB;
        PetStore.Class.User oUser;
        string PetName;
        string sFirstName;
        string sOldName;
        string sWeight;
        string sOldWeight;
        string sAge;
        string sOldAge;
        string sType;
        string sOldType;

        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            PetName = "";
            PetName = Request.QueryString["Name"];
            notRegisteredError.Style.Add("display", "none");


            if (Session["User"] == null)
            {
                notRegisteredError.Style.Add("display", "");
                notRegisteredError.Text = "Only registered users can use this feature";
                pageContent.Style.Add("display", "none");
                btnUpdate.Text = "ADD";
                btnDelete.Style.Add("style", "none");
            }


            else if (PetName == null)
            {
                oUser = (PetStore.Class.User)Session["User"];
                PetName = oDB.GetFirstPetName(oUser.ID);

                if (PetName == "")
                {
                    oUser = (PetStore.Class.User)Session["User"];

                    Div1.Style.Add("display", "none");

                }
                else
                {
                    btnUpdate.Text = "UPDATE";
                    NewButton.Style.Add("display", "none");
                    DataTable dtPets = new DataTable();
                    dtPets = oDB.GetPet(oUser.ID, PetName); //, categoryName);
                    sFirstName = txtFirstname.Text;
                    sOldName = dtPets.Rows[0]["Name"].ToString();
                    txtFirstname.Text = sOldName;
                    sWeight = Weight.Text;
                    sOldWeight = dtPets.Rows[0]["Weight"].ToString();
                    Weight.Text = sOldWeight;
                    sAge = Age.Text;
                    sOldAge = dtPets.Rows[0]["DOB"].ToString();
                    Age.Text = sOldAge;
                    sType = ddlType.SelectedValue;
                    sOldType = dtPets.Rows[0]["Type"].ToString();
                    ddlType.ClearSelection();
                    ddlType.Items.FindByValue(sOldType).Selected = true;
                }

            }
            else
            {
                oUser = (PetStore.Class.User)Session["User"];
                btnUpdate.Text = "UPDATE";
                NewButton.Style.Add("display", "none");
                DataTable dtPets = new DataTable();
                dtPets = oDB.GetPet(oUser.ID, PetName);
                sFirstName = txtFirstname.Text;
                sOldName = dtPets.Rows[0]["Name"].ToString();
                txtFirstname.Text = sOldName;
                sWeight = Weight.Text;
                sOldWeight = dtPets.Rows[0]["Weight"].ToString();
                Weight.Text = sOldWeight;
                sAge = Age.Text;
                sOldAge = dtPets.Rows[0]["DOB"].ToString();
                Age.Text = sOldAge;
                sType = ddlType.SelectedValue;
                sOldType = dtPets.Rows[0]["Type"].ToString(); ;
                ddlType.ClearSelection();
                ddlType.Items.FindByValue(sOldType).Selected = true;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            
            oDB = new DB.Data();
            DateTime temp;
            if (DateTime.TryParse(sAge, out temp))
            {
                
                Debug.WriteLine(sAge);
                oDB.UpdatePet(sFirstName, sOldName, oUser.ID, sAge, sWeight, sType);
                Response.Redirect("pet.aspx");
            }
            else
            {
                Age.Text = "Invalid Date Input";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            oDB = new DB.Data();
            oDB.DeletePet(txtFirstname.Text, oUser.ID);
            Response.Redirect("pet.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("addpet.aspx");
            //txtFirstname.Text = "";
            //Calendar1.SelectedDate = DateTime.Now;
            //btnUpdate.Text = "ADD";
            //btnDelete.Style.Add("style", "none");
        }


    }
}