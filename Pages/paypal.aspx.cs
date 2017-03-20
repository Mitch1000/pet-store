using PetStore.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class paypal : System.Web.UI.Page
    {
        protected ShoppingCartCollection oShoppingCartCollection;
        protected decimal tax;
        protected decimal subTotal;
        protected User oUser;
        protected Order oOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            oUser = (User)Session["User"];
            oShoppingCartCollection =(ShoppingCartCollection) Session["ShoppingCart"];
            oOrder = (Order)Session["Order"];
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "DatePickerScript", "RedirectPayPal();", true);

            
              




        }
    }
}