using PetStore.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class orderconfirmation : System.Web.UI.Page
    {
        protected ShoppingCartCollection oShoppingCartCollection;
        protected decimal tax;
        protected decimal subTotal;
        protected User oUser;
        protected Order oOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            oOrder = (Order)Session["Order"];
            oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];

            rptShoppingCart.DataSource = oShoppingCartCollection;
            rptShoppingCart.DataBind();

            lblTax.Text = String.Format("{0:F2}", oShoppingCartCollection.Tax);
            lblTotal.Text = String.Format("{0:F2}", oShoppingCartCollection.Total);


            lblOrderNumber.Text = oOrder.OrderNumber.ToString();
            Session["ShoppingCart"] = null;
            Session["Order"] = null;
        }
    }
}