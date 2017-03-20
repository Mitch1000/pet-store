using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Control
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PetStore.DB.Data oDB;
            oDB = new PetStore.DB.Data();

            string mainCategory = "";
            string categoryName = "";
            mainCategory = Request.QueryString["MainCat"];
            categoryName = Request.QueryString["Cat"];
            if (mainCategory == null) mainCategory = "DOG";
            if (categoryName == null)
            {
                categoryName = oDB.GetFirstCategoryForMainCategory(mainCategory);
            }

            ////if (mainCategory == "DOG") { ldog.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/dogbanner.jpg"; }
            ////else if (mainCategory == "CAT") { lcat.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/catbanner.jpg"; }
            ////else if (mainCategory == "FISH") { lfish.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/fishbanner.jpg"; }
            ////else if (mainCategory == "BIRD") { lbird.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/birdbanner.jpg"; }


            if (mainCategory == "DOG") { imgCategory.ImageUrl = "../Images/newdog.jpg"; }
            else if (mainCategory == "CAT") {  imgCategory.ImageUrl = "../Images/newcat.png"; }
            else if (mainCategory == "FISH") { imgCategory.ImageUrl = "../Images/newfish.jpg"; }
            else if (mainCategory == "BIRD") {  imgCategory.ImageUrl = "../Images/newbird.jpg"; }


        }
    }
}