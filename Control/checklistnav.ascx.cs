﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Control
{
    public partial class checklistnav : System.Web.UI.UserControl
    {
        string UserID;
        string PetName;
        PetStore.DB.Data oDB;
        PetStore.Class.User oUser;


        protected void Page_Load(object sender, EventArgs e)
        {

            PetName = "";
            PetName = Request.QueryString["Name"];

            if (Session["User"] != null)
            {
                
                    DataTable dtPets = new DataTable();
                    dtPets = oDB.GetPetTypes();

                    rptLeftNav.DataSource = dtPets;
                    rptLeftNav.DataBind();

               


            }



        }

        protected void rptLeftNav_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            // This event is raised for the header, the footer, separators, and items.

            // Execute the following logic for Items and Alternating Items.
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField oName = (HiddenField)e.Item.FindControl("PetName");
                if (oName.Value == PetName)
                {

                    (e.Item.FindControl("pTag") as System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "NavCurrent");
                }


            }
        }
    }
}