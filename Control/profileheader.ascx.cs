using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Control
{
    public partial class profileheader : System.Web.UI.UserControl
    {
        string mainCategory = "";
        string categoryName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;  // http://localhost:1302/TESTERS/Default6.aspx
            //home product calendar checjlist vet login, faq
            ////if (url.Contains("profile")) { lprofile.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/aboutme_profile_banner.png"; }
            ////else if (url.Contains("pet")) { lpet.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/aboutme_pet_banner.png"; }
            ////else if (url.Contains("calendar")) { lcalendar.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/calendar_banner.jpg"; }
            ////else if (url.Contains("orderhistory")) { lorderhistory.Attributes.Add("class", "headerNavSelected"); imgCategory.ImageUrl = "../Images/calendar_banner.jpg"; }

            if (url.Contains("profile")) { lprofile.Attributes.Add("class", "headerNavSelected"); }
            else if (url.Contains("pet")) { lpet.Attributes.Add("class", "headerNavSelected"); }
            else if (url.Contains("calendar")) { lcalendar.Attributes.Add("class", "headerNavSelected"); }
            else if (url.Contains("orderhistory")) { lorderhistory.Attributes.Add("class", "headerNavSelected");}
          
        }

       
    }
}