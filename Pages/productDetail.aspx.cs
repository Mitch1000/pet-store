using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetStore.Class;

namespace PetStore.Pages
{
    public partial class productDetail : System.Web.UI.Page
    {
        
     PetStore.DB.Data oDB;
     ShoppingCartCollection oShoppingCartCollection;
     Product oProduct;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtError.Text = "";
            oProduct = new Product();
             oDB = new PetStore.DB.Data();
            string pid = "";
            string CAT = "";
            pid = Request.QueryString["pid"];
            CAT = Request.QueryString["CAT"];
            oProduct = oDB.GetProduct(Convert.ToInt32(pid));
            itemTitle.Text = oProduct.Item;
            itemDescription.Text = oProduct.Description;
            itemPrice.Text = oProduct.Price.ToString();
            itemImage.ImageUrl = oProduct.Image;

            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                txtError.Text = "Please add order qty. ";
            }
            else
            {

                if (Session["ShoppingCart"] != null)
                {
                    oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
                }
                else
                {
                    oShoppingCartCollection = new ShoppingCartCollection();
                }
                    ShoppingCart oSC = new ShoppingCart();
                    oSC.PID = oProduct.PID;
                    oSC.Item = oProduct.Item;
                    oSC.Price = oProduct.Price;
                    oSC.Qty = Convert.ToInt16(txtQty.Text);
                    oShoppingCartCollection.Add(oSC);

                    Session["ShoppingCart"] = oShoppingCartCollection;
                    Response.Redirect("checkout.aspx");
            }
           
        }
    }
}