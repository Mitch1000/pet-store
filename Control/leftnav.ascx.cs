using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PetStore.Control
{
    public partial class leftnav : System.Web.UI.UserControl
    {
        protected string LeftStyleType;
        string mainCategory;
        string categoryName;

        protected void Page_Load(object sender, EventArgs e)
        {
            PetStore.DB.Data oDB = new PetStore.DB.Data();
             mainCategory = "";
             categoryName = "";
            mainCategory = Request.QueryString["MainCat"];
            categoryName = Request.QueryString["Cat"];
            if (mainCategory == null) mainCategory = "DOG";
            if (categoryName == null)
            {
                categoryName = oDB.GetFirstCategoryForMainCategory(mainCategory);
            }

            DataTable dtCategories = new DataTable();
            dtCategories = oDB.GetCategories(mainCategory); //, categoryName);

            rptLeftNav.DataSource = dtCategories;
            rptLeftNav.DataBind();
             
            
           
            //string url = HttpContext.Current.Request.Url.AbsoluteUri;  // http://localhost:1302/TESTERS/Default6.aspx
            ////home product calendar checjlist vet login, faq
            //if (url.Contains("dog")) { LeftStyleType = "DOG";  }
            //else if (url.Contains("cat")) { LeftStyleType = "CAT"; }
            //else if (url.Contains("fish")) { LeftStyleType = "FISH";  }
            //else if (url.Contains("bird")) { LeftStyleType = "BIRD";   }

        }

        protected void rptLeftNav_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            // This event is raised for the header, the footer, separators, and items.

            // Execute the following logic for Items and Alternating Items.
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField oCategory = (HiddenField)e.Item.FindControl("CategoryName");
                if (oCategory.Value == categoryName)
                {
                    //  <p class="p_left_menu NavCurrent"><a href="Products.aspx?MainCat=DOG&Cat=BED" class ="aNavSelected">BED</a></p>
                    // <p id="pTag" runat="server" class="p_left_menu"><a id="aTag" runat="server" href='Products.aspx?MainCat=<%# DataBinder.Eval(Container.DataItem, "MainCategory")%>&Cat=<%#DataBinder.Eval(Container.DataItem, "Category")%>'><%# DataBinder.Eval(Container.DataItem, "Category") %></a></p>
     
                    (e.Item.FindControl("pTag") as System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "NavCurrent");
                   // (e.Item.FindControl("aTag") as System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "aNavSelected");
                }

               
            }
        }
    }
}