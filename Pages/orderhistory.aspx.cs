using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class orderhistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            notRegisteredError.Style.Add("display", "none");
            if (Session["User"] == null)
            {
                notRegisteredError.Style.Add("display", "");
                notRegisteredError.Text = "Only registered users can use this feature";
            }
            else
            {

                PetStore.Class.User oUser = (PetStore.Class.User) Session["User"];
                DataTable dtCity = new DataTable();
                PetStore.DB.Data oDB = new PetStore.DB.Data();


                rptOrder.DataSource = oDB.GetOrders(oUser.ID); ;
                rptOrder.DataBind();

            }
        }
    }
}