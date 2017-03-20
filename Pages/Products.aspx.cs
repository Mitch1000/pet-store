using PetStore.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class Products : System.Web.UI.Page
    {
        protected string LeftStyleType = "";
        PetStore.DB.Data oDB;
        ShoppingCartCollection oShoppingCartCollection ; 

        protected void Page_Load(object sender, EventArgs e)
        {
            oDB = new PetStore.DB.Data();
            if (!IsPostBack)
            {
                txtError.Text = "";

                if (Session["ShoppingCart"] != null)
                {
                    oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
                }
                else
                {
                    oShoppingCartCollection = new ShoppingCartCollection();
                }

                string mainCategory = "";
                string categoryName = "";
                mainCategory = Request.QueryString["MainCat"];
                categoryName = Request.QueryString["Cat"];
                if (mainCategory == null) mainCategory = "DOG";
                if (categoryName == null)
                {
                    categoryName = oDB.GetFirstCategoryForMainCategory(mainCategory);
                }

                //if (mainCategory == "DOG") { ldog.Attributes.Add("class", "headerNavSelected");  imgCategory.ImageUrl = "../Images/dogbanner.jpg";    }
                //else if (mainCategory == "CAT") { lcat.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/catbanner.jpg"; }
                //else if (mainCategory == "FISH") { lfish.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/fishbanner.jpg"; }
                //else if (mainCategory == "BIRD") { lbird.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/birdbanner.jpg"; }

                categoryTitle.Text = oDB.GetCategoryTitle(mainCategory, categoryName);
                DataTable dtProduct = new DataTable();
                dtProduct = oDB.GetProductByCategory(mainCategory, categoryName);
                rptProduct.DataSource = dtProduct;
                rptProduct.DataBind();
            }
            

        }


        protected void rptProduct_ItemsCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            //try
            //{
            //    switch (e.CommandName.ToLower())
            //    {
            //        case "addCart":
            //            TextBox oQty = (TextBox)e.Item.FindControl("txtQty");
            //            //Label errorLable = (Label)e.Item.FindControl("txtError");
            //            //if (oQty.Text == "")
            //            //{
            //            //    errorLable.Text = "Please add order qty. ";
            //            //}
                     
            //            AddToCart(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(oQty.Text));
            //            break;
            //    }

            //}catch{
            //}
        }

       

            // This event is raised for the header, the footer, separators, and items.

            //// Execute the following logic for Items and Alternating Items.
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    HiddenField oCategory = (HiddenField)e.Item.FindControl("CategoryName");
            //    if (oCategory.Value == categoryName)
            //    {
            //        //  <p class="p_left_menu NavCurrent"><a href="Products.aspx?MainCat=DOG&Cat=BED" class ="aNavSelected">BED</a></p>
            //        // <p id="pTag" runat="server" class="p_left_menu"><a id="aTag" runat="server" href='Products.aspx?MainCat=<%# DataBinder.Eval(Container.DataItem, "MainCategory")%>&Cat=<%#DataBinder.Eval(Container.DataItem, "Category")%>'><%# DataBinder.Eval(Container.DataItem, "Category") %></a></p>
     
            //        (e.Item.FindControl("pTag") as System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "NavCurrent");
            //       // (e.Item.FindControl("aTag") as System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "aNavSelected");
            //    }

               
            //}

        private void AddToCart(int PID, int Qty)
        {
            if (Session["ShoppingCart"] != null)
            {
                oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
                ShoppingCart oSC = new ShoppingCart();
                Product oItem = new Product();
                oItem = oDB.GetProduct(PID);
                oSC.PID = oItem.PID;
                oSC.Item = oItem.Item;
                oSC.Price = oItem.Price;
                oSC.Qty = Qty;
                oShoppingCartCollection.Add(oSC);
            }
        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            bool hasQty = false;
            if (Session["ShoppingCart"] != null)
            {
                oShoppingCartCollection = (ShoppingCartCollection)Session["ShoppingCart"];
            }
            else
            {
                oShoppingCartCollection = new ShoppingCartCollection();
            }

            foreach( RepeaterItem item in rptProduct.Items)
            {
                 TextBox oQty = (TextBox)item.FindControl("txtQty") ;
                if ( oQty.Text !="")
                {
                    ShoppingCart oSC = new ShoppingCart();
                    HiddenField oPID = (HiddenField)item.FindControl("hiddenFieldPID");
                    Product oItem = new Product();
                    oItem = oDB.GetProduct(Convert.ToInt32(oPID.Value));
                    oSC.PID = oItem.PID;
                    oSC.Item = oItem.Item;
                    oSC.Price = oItem.Price;
                    oSC.Qty = Convert.ToInt32(oQty.Text);
                    oShoppingCartCollection.Add(oSC);
                    hasQty = true;
                }



            } 
            if (!hasQty)
            {
                txtError.Text = "Please add order qty. ";
            }
            else
            {
                Session["ShoppingCart"] = oShoppingCartCollection;
                Response.Redirect("checkout.aspx");
            }

           

        }
    }
}