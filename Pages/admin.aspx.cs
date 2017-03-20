using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class admin : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PetStore.DB.Data oDB = new PetStore.DB.Data();
                rptVet.DataSource = oDB.GetUsers(); ;
                rptVet.DataBind();
            }
        
        }


        protected void rptVet_ItemsCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            try
            {
                PetStore.DB.Data oDB = new PetStore.DB.Data();
                HiddenField userID = (HiddenField)e.Item.FindControl("userID");
                switch (e.CommandName.ToUpper())
                {
                       
                    case "BLOCK":
                        oDB.BlockUser(userID.Value);
                        Response.Redirect("admin.aspx");
                        break;

                    case "UNBLOCK":
                        oDB.UnblockUser(userID.Value);
                        Response.Redirect("admin.aspx");
                        break;
                }

            }
            catch
            {
            }
        }

        protected void rptVet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PetStore.DB.Data oDB = new PetStore.DB.Data();
                HiddenField userID = (HiddenField)e.Item.FindControl("userID");
                HiddenField IsBlocked = (HiddenField)e.Item.FindControl("IsBlocked");
                if ( IsBlocked.Value == "")
                {
                    Button unblockButton = (Button)e.Item.FindControl("btnUnblockUser");
                    unblockButton.Style.Add("display", "none");
                }
                else
                {
                    Button blockButton = (Button)e.Item.FindControl("btnBlockUser");
                    blockButton.Style.Add("display", "none");
                }
           
            }

           
        }

       
    }
}