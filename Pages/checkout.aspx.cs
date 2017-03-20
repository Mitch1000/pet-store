using PetStore.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class checkout : System.Web.UI.Page
    {
        protected ShoppingCartCollection oShoppingCartCollection; 
        protected decimal tax ;
        protected decimal subTotal;
        protected User oUser;
        protected Order oOrder;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
           

            oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
            if (Session["User"] !=null){
                oUser = (User)Session["User"];
            }
             tax = 0;
             subTotal = 0;

             if (oShoppingCartCollection !=null && oShoppingCartCollection.Count > 0)
             {
                 foreach (ShoppingCart eachItem in oShoppingCartCollection)
                 {
                     subTotal = subTotal + (eachItem.Qty * eachItem.Price);
                 }

                 oShoppingCartCollection.Tax = subTotal * (Decimal)0.13;
                 oShoppingCartCollection.Subtotal = subTotal;
                 oShoppingCartCollection.Total = oShoppingCartCollection.Tax + oShoppingCartCollection.Subtotal;

                 lblTax.Text = String.Format("{0:F2}", oShoppingCartCollection.Tax);
                 lblTotal.Text = String.Format("{0:F2}", oShoppingCartCollection.Total);

                 rptShoppingCart.DataSource = oShoppingCartCollection;
                 rptShoppingCart.DataBind();
                

                 Session["ShoppingCart"] = oShoppingCartCollection;
             }
             else
             {
                 divrpt.Style.Add("display", "none");
                 error.Text = "There is no item in the shopping cart.";
             }

             if (Session["User"] == null)
             {
                 paypalbtn.Style.Add("display", "none");
                 btnLogin.Style.Add("display", "");
             }
             else
             {
                 paypalbtn.Style.Add("display", "");
                 btnLogin.Style.Add("display", "none");
             }

            } 
            
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else {
                paypalbtn.Visible = true;
            }
           
        }

        protected void paypalbtn_Click(object sender, ImageClickEventArgs e)
        {
            oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
            oUser = (User)Session["User"];
            PetStore.DB.Data oDB = new DB.Data();
            oOrder = new Order();
            oOrder.OrderNumber = oDB.GetNextOrderNumber();
            oOrder.ShoppingCart = oShoppingCartCollection;
            oOrder.User = oUser;

            oDB.AddOrder(oOrder);
            SendEmail();

            Session["Order"] = oOrder;

            Response.Redirect("paypal.aspx");

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "RedirectPayPal();");

           
        }

        private void SendEmail()
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage oMessage = new MailMessage();
            oMessage.Subject = "Order Confirmation";
            oMessage.Body = "Hi, your order has been placed successfully. Your order number is " + oOrder.OrderNumber + " <br />";

            oMessage.Body = oMessage.Body + "<table><tr><td style='width:500px;'>ITem</td><td  style='width:50px;'>Qty</td><td  style='width:150px;'>Price</td><td  style='width:150px;'>SubTotal</td></tr>";
                
            foreach(ShoppingCart eachItem in oShoppingCartCollection){            
                oMessage.Body = oMessage.Body +  "<tr><td>"+eachItem.Item+"</td><td>"+eachItem.Qty+"</td><td>"+eachItem.Price+"</td><td>"+ String.Format("{0:F2}", eachItem.Qty * eachItem.Price )+"</td></tr>";
            }

            oMessage.Body = oMessage.Body + "<tr><td style='width:500px;'>Tax</td><td  style='width:50px;'></td><td  style='width:150px;'></td><td  style='width:150px;'>"+ String.Format("{0:F2}",oShoppingCartCollection.Tax)+"</td></tr>";
            oMessage.Body = oMessage.Body + "<tr><td style='width:500px;'>Total</td><td  style='width:50px;'></td><td  style='width:150px;'></td><td  style='width:150px;'>" +  String.Format("{0:F2}",oShoppingCartCollection.Total) + "</td></tr>";
          

            oMessage.Body = oMessage.Body + "</table>";
                                
            oMessage.IsBodyHtml = true;

            oMessage.To.Add(new MailAddress(oUser.Email));
            oMessage.From = new MailAddress("test@hotmail.com"); 
            smtpClient.Send(oMessage);

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx?page=checkout");
        }

        protected void rptShoppingCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
                PetStore.DB.Data oDB = new PetStore.DB.Data();
                HiddenField RemoveItem = (HiddenField)e.Item.FindControl("hidItem");
                switch (e.CommandName.ToUpper())
                {

                    case "REMOVE":

                        foreach (ShoppingCart eachItem in oShoppingCartCollection)
                        {
                            if (eachItem.Item == RemoveItem.Value)
                            {
                                oShoppingCartCollection.Delete(eachItem);
                                break;
                            }

                        }


                        Session["ShoppingCart"] = oShoppingCartCollection;
                        Response.Redirect("checkout.aspx");
                        break;
                }

            }
            catch
            {
            }
        }


    }
}