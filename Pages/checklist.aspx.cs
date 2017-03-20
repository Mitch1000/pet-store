using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetStore.Pages
{
    public partial class checklist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pettype ="";
            pettype = Request.QueryString["PetType"];

            if ( pettype ==null || pettype == "")
            {
                pettype = "DOG";
            }
            PetStore.DB.Data oDB = new PetStore.DB.Data();
            rptVet.DataSource = oDB.GetCheckList(pettype); ;
            rptVet.DataBind();

        }
    }
}