using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetStore.Class;

namespace PetStore.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            User tempUser = new User();
            if (Session["User"] != null)
            {
                navlogin.Style.Add("display", "none");
                navlogout.Style.Add("display", "");
                navmyaccount.Style.Add("display", "");
                //navregister.Style.Add("display", "none");
                navAdmin.Style.Add("display", "none");
                tempUser = (User)Session["User"];
            }
            else
            {
                navlogout.Style.Add("display", "none");
                navlogin.Style.Add("display", "");
                navmyaccount.Style.Add("display", "none");
                //navregister.Style.Add("display", "");
                navAdmin.Style.Add("display", "none");

            }
                if (tempUser.ID == 1){
                      navAdmin.Style.Add("display", "");
                }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;  // http://localhost:1302/TESTERS/Default6.aspx
            //home product calendar checjlist vet login, faq
            if (url.Contains("home")) { linavhome.Attributes.Add("class", "active"); }
            else if (url.Contains("login")) { linavlogin.Attributes.Add("class", "active"); }
            else if (url.Contains("Products")) { linavproduct.Attributes.Add("class", "actilve"); }
            else if (url.Contains("checklist")) { linavchecklist.Attributes.Add("class", "active"); }
            else if (url.Contains("vet")) { linavvet.Attributes.Add("class", "active"); }
            //else if (url.Contains("profile")) { linavmyaccount.Attributes.Add("class", "active"); linavregister.Attributes.Add("class", "active"); }
            else if (url.Contains("checkout") || url.Contains("orderconfirmation")) { linavcheckout.Attributes.Add("class", "active"); }
            else if (url.Contains("admin") || url.Contains("admin")) { linavAdmin.Attributes.Add("class", "active"); }

            //if (mainCategory == "DOG") { ldog.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/dogbanner.jpg"; }
            //else if (mainCategory == "CAT") { lcat.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/catbanner.jpg"; }
            //else if (mainCategory == "FISH") { lfish.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/fishbanner.jpg"; }
            //else if (mainCategory == "BIRD") { lbird.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/birdbanner.jpg"; }

            //if (url.Contains("profile")) { lprofile.Attributes.Add("class", "headerNavSelected"); }
            //else if (url.Contains("pet")) { lpet.Attributes.Add("class", "headerNavSelected"); }
            //else if (url.Contains("calendar")) { lcalendar.Attributes.Add("class", "headerNavSelected"); }
            //else if (url.Contains("orderhistory")) { lorderhistory.Attributes.Add("class", "headerNavSelected"); }
          


            string path = HttpContext.Current.Request.Url.AbsolutePath;
            // /TESTERS/Default6.aspx

            string host = HttpContext.Current.Request.Url.Host;
        }
    }
}