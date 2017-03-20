using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PetStore.Pages
{


    public partial class vet : System.Web.UI.Page
    {
        protected string[] vetaddress = new string[10];
        protected string[] VetTitle = new string[10];
        protected string[] province = new string[10];
        protected string[] description = new string[10];
        protected string[] Address = new string[10];
        protected string[] City = new string[10];
        protected string[] url = new string[10];
        protected string[] logo = new string[10];
        protected string[] postalcode = new string[10];
        protected PetStore.Class.User oUser;
        protected PetStore.DB.Data oDB = new PetStore.DB.Data();
        protected DataTable dtVet = new DataTable();
        bool appointmentbooked = false;
        protected int q = 0;
        string PetName;

        protected void Page_Load(object sender, EventArgs e)
        {

            oDB = new DB.Data();
            PetName = "";
            notRegisteredError.Style.Add("display", "none");
            DataTable dtDates = new DataTable();
            DataTable dtPet = new DataTable();
            oUser = (PetStore.Class.User)Session["User"];


            if (btnBookApnt.Text == "1")
            {
                btnBookApnt.Text = "BOOK APPOINTMENT";

            }

            ApntBooked.Style.Add("display", "none");
            ShowDateInput.Style.Add("display", "none");
            notRegisteredError.Style.Add("display", "none");




            if (Session["User"] == null)
            {
                notRegisteredError.Style.Add("display", "");
                notRegisteredError.Text = "Only registered users can use this feature";
                vetpagecontent.Style.Add("display", "none");

            }


            else
            {

                PetName = oDB.GetFirstPetName(oUser.ID);
                oUser = (PetStore.Class.User)Session["User"];
                dtVet = oDB.GetVets();
                int i = 0;
                q = 0;
                string myTable = "";
                foreach (DataRow row in dtVet.Rows)
                {
                    if (dtVet.Rows[i]["City"].ToString() == oUser.City)
                    {
                        description[q] = dtVet.Rows[i]["description"].ToString();
                        VetTitle[q] = dtVet.Rows[i]["Title"].ToString();
                        Address[q] = dtVet.Rows[i]["Address"].ToString();
                        City[q] = dtVet.Rows[i]["City"].ToString();
                        province[q] = dtVet.Rows[i]["province"].ToString();
                        postalcode[q] = dtVet.Rows[i]["Postal"].ToString();
                        url[q] = dtVet.Rows[i]["url"].ToString();
                        logo[q] = dtVet.Rows[i]["logo"].ToString();
                        vetaddress[q] = dtVet.Rows[i]["Address"].ToString() + ", " + dtVet.Rows[i]["City"].ToString() + ", " + dtVet.Rows[i]["province"].ToString() + ", " + dtVet.Rows[i]["Postal"].ToString();

                        myTable += "<table>";
                        myTable += "<tr>";
                        myTable += "<td> <a href=" + url[q] + "> <img style='max-height: 180px; max-width: 180px' src=" + logo[q] + " /></a></td>";
                        myTable += "</tr>";
                        myTable += "<tr>";
                        myTable += "<td><b> <a href=" + url[q] + ">" + VetTitle[q] + "</a></b></td>";
                        myTable += "</tr>";
                        myTable += "<tr>";
                        myTable += "<td>" + vetaddress[q] + " </td>";
                        myTable += "</tr>";
                        myTable += "<br>";

                        if (!this.IsPostBack)
                        {
                            ddlVet.Items.Add(new ListItem(VetTitle[q], VetTitle[q]));
                        }

                        q++;
                    }
                    i++;
                }


                myTable += "</table>";
                tablePrint.InnerHtml = myTable;

                if (!this.IsPostBack)
                {

                    ddlPet.Items.Insert(0, new ListItem("", ""));
                    int n = 0;
                    DataTable dtPets = new DataTable();
                    dtPets = oDB.GetPets(oUser.ID);

                    foreach (DataRow row in dtPets.Rows)
                    {
                        ddlPet.Items.Add(new ListItem(dtPets.Rows[n]["Name"].ToString(), dtPets.Rows[n]["Name"].ToString()));
                        n++;
                    }
                }
                // rptVet.DataSource = oDB.GetVets(); ;
                //   rptVet.DataBind();

                if (PetName == "")
                {
                    btnBookApnt.Style.Add("display", "none");
                }



            }// end else 
        }// end page load


        protected void btnBookApnt_Click(object sender, EventArgs e)
        {

            ShowDateInput.Style.Add("display", "table");

            if (btnBookApnt.Text == "CLICK TO BOOK APPOINTMENT")
            {
                DateTime Date;

                if (Regex.IsMatch(Day.Text, @"^\d+$"))
                {
                    if (Month.SelectedValue != null && Year.SelectedValue != null && Convert.ToInt32(Day.Text) > 0 && Convert.ToInt32(Day.Text) < System.DateTime.DaysInMonth(Convert.ToInt32(Year.SelectedValue), DateTime.ParseExact(Month.SelectedValue, "MMMM", CultureInfo.CurrentCulture).Month))
                    {

                        Date = Convert.ToDateTime(Month.SelectedValue + "/" + Day.Text + "/" + Year.SelectedValue);
                        oDB.AddDate(oUser.ID, ddlPet.SelectedValue, Date, (ddlPet.SelectedValue + " Has Appointment at " + ddlVet.SelectedValue + " " + Details.Text + " on: " + Date.ToString("MMMM dd, yyyy")), ddlVet.SelectedValue);
                        ShowDateInput.Style.Add("display", "none");
                        ApntBooked.Style.Add("display", "table");
                        ApntBook.Text = "Your Appointment Has Been Successfully Booked";
                        appointmentbooked = true;

                    }
                    else
                    {
                        ApntBooked.Style.Add("display", "table");
                        ApntBook.Text = "Error with date input";

                    }

                }

                else
                {
                    ApntBooked.Style.Add("display", "table");
                    ApntBook.Text = "Error with date input";

                }



            }
            btnBookApnt.Text = "CLICK TO BOOK APPOINTMENT";
            if (appointmentbooked)
            {
                btnBookApnt.Text = "BOOK APPOINTMENT";
                appointmentbooked = false;
            }


        }

    }

}
