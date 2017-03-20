using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Control
{
    public partial class headerChecklist : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PetStore.DB.Data oDB;
            oDB = new PetStore.DB.Data();

            string mainCategory = "";
            string categoryName = "";
            mainCategory = Request.QueryString["pettype"];
            if (mainCategory == null) mainCategory = "DOG";
           
            if (mainCategory == "DOG") {  imgCategory.ImageUrl = "../Images/dogbanner.jpg"; }
            else if (mainCategory == "CAT") {  imgCategory.ImageUrl = "../Images/catbanner.jpg"; }
            else if (mainCategory == "FISH") { imgCategory.ImageUrl = "../Images/fishbanner.jpg"; }
            else if (mainCategory == "BIRD") { imgCategory.ImageUrl = "../Images/birdbanner.jpg"; }

        }
    }
}