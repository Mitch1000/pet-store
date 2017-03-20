using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PetStore.Pages
{

    public partial class calendar : System.Web.UI.Page
    {
        PetStore.DB.Data oDB;
        PetStore.Class.User oUser;
        string PetName;
        PetStore.Class.Calendar oCalendar;
        DataTable dtPets = new DataTable();
        System.DateTime Today = DateTime.Now;
        string info;
        DateTime Date;
        bool dateadded = false;
        bool datedeleted = false;
        public string Pet;


        protected void Page_Load(object sender, EventArgs e)
        {

            Session["Calendar"] = oCalendar;
            oCalendar = new Class.Calendar();
            oDB = new DB.Data();
            PetName = "";
            PetName = Request.QueryString["Name"];
            notRegisteredError.Style.Add("display", "none");
            DataTable dtDates = new DataTable();
            DataTable dtPet = new DataTable();

            DeleteSelection.Style.Add("display", "none");
            DeleteCompleted.Style.Add("display", "none");
            ShowDateInput.Style.Add("display", "none");
            DateMade.Style.Add("display", "none");
            notRegisteredError.Style.Add("display", "none");
            Error.Style.Add("display", "none");

            if (btnAddDate.Text == "1")
            {
                btnAddDate.Text = "ADD DATE";
            }

            if (btnDateDelete.Text == "1")
            {
                btnDateDelete.Text = "DELETE DATE";
            }


            if (Session["User"] == null)
            {
                notRegisteredError.Style.Add("display", "");
                notRegisteredError.Text = "Only registered users can use this feature";
                pagecontent.Style.Add("display", "none");
            }

         // OpenNewWindow("test.aspx");

            else if (PetName == null)
            {

                oUser = (PetStore.Class.User)Session["User"];
                PetName = oDB.GetFirstPetName(oUser.ID);

                if (PetName == "")
                {
                    oUser = (PetStore.Class.User)Session["User"];
                    btnDateDelete.Style.Add("display", "none");
                    btnAddDate.Style.Add("display", "none");
                    
                }
                else
                {

                    oUser = (PetStore.Class.User)Session["User"];
                    dtDates = oDB.GetDates(oUser.ID);
                    dtPets = oDB.GetPets(oUser.ID);
                    System.DateTime Today = DateTime.Now;
                    System.DateTime DateLastDogFoodWasPurchase = Today.AddDays(-7);
                    System.DateTime DateLastCatFoodWasPurchase = Today.AddDays(-7);
                    int NumberofDogFoodCans = 20;
                    int NumberofCatFoodCans = 20;
                    double DogFoodCaloriesPerOrder = 424 * NumberofDogFoodCans;
                    double CatFoodCaloriesPerOrder = 424 * NumberofCatFoodCans;
                    int i = 0;
                    foreach (DataRow row in dtPets.Rows)
                    {

                        if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Dog"))
                        {
                            Date = oCalendar.DogFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastDogFoodWasPurchase, DogFoodCaloriesPerOrder);
                            info = dtPets.Rows[i]["Name"].ToString() + " Needs Food on: " + oCalendar.DogFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastDogFoodWasPurchase, DogFoodCaloriesPerOrder).ToString("MMMM dd, yyyy") + "                ";

                        }

                        if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Cat"))
                        {
                            Date = oCalendar.CatFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastCatFoodWasPurchase, CatFoodCaloriesPerOrder);
                            info = dtPets.Rows[i]["Name"].ToString() + " Needs Food on: " + oCalendar.CatFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastCatFoodWasPurchase, CatFoodCaloriesPerOrder).ToString("MMMM dd, yyyy") + "                ";

                        }


                        if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Fish"))
                        {
                            Date = DateTime.Now.AddDays(7);
                            info = dtPets.Rows[i]["Name"].ToString() + " Needs Their Bowl Cleaned On: " + Date.ToString("MMMM dd, yyyy") + "                ";

                        }


                        if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Bird"))
                        {
                            Date = DateTime.Now.AddDays(9);
                            info = dtPets.Rows[i]["Name"].ToString() + " Needs Their Cage Cleaned On: " + Date.ToString("MMMM dd, yyyy") + "                ";
                        }

                        oDB.DeleteDate(oUser.ID, info);
                        oDB.AddDate(oUser.ID, dtPets.Rows[i]["Name"].ToString(), Date, info, "");

                        i++;
                    }


                    dtPet = oDB.GetPet(oUser.ID, PetName);
                    Pet = dtPet.Rows[0]["Name"].ToString();


                    /*
                     int n = 0;
                     int z = 0;
                     foreach (DataRow row in dtDates.Rows)
                     {
                         if (dtDates.Rows[z]["Pet"].ToString() == dtPet.Rows[0]["Name"].ToString())
                         {

                             switch (n)
                             {
                                 case 0: Day0.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 1: Day1.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 2: Day2.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 3: Day3.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 4: Day4.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 5: Day5.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 6: Day6.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 7: Day7.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 8: Day8.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 9: Day9.Text = dtDates.Rows[z]["Info"].ToString(); break;
                                 case 10: Day10.Text = dtDates.Rows[z]["Info"].ToString(); break;
                             }
                             n++;
                         }
                         z++;
                     }
                     */
                }//end else
            }

            else
            {
                oUser = (PetStore.Class.User)Session["User"];
                dtDates = oDB.GetDates(oUser.ID);
                dtPets = oDB.GetPets(oUser.ID);
                System.DateTime Today = DateTime.Now;
                System.DateTime DateLastDogFoodWasPurchase = Today.AddDays(-7);
                System.DateTime DateLastCatFoodWasPurchase = Today.AddDays(-7);
                int NumberofDogFoodCans = 20;
                int NumberofCatFoodCans = 20;
                double DogFoodCaloriesPerOrder = 424 * NumberofDogFoodCans;
                double CatFoodCaloriesPerOrder = 424 * NumberofCatFoodCans;
                int i = 0;

                foreach (DataRow row in dtPets.Rows)
                {


                    if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Dog"))
                    {
                        Date = oCalendar.DogFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastDogFoodWasPurchase, DogFoodCaloriesPerOrder);
                        info = dtPets.Rows[i]["Name"].ToString() + " Needs Food on: " + oCalendar.DogFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastDogFoodWasPurchase, DogFoodCaloriesPerOrder).ToString("MMMM dd, yyyy") + "                ";

                    }

                    if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Cat"))
                    {
                        Date = oCalendar.CatFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastCatFoodWasPurchase, CatFoodCaloriesPerOrder);
                        info = dtPets.Rows[i]["Name"].ToString() + " Needs Food on: " + oCalendar.CatFoodNeeded(Convert.ToDouble(dtPets.Rows[i]["Weight"]), DateLastCatFoodWasPurchase, CatFoodCaloriesPerOrder).ToString("MMMM dd, yyyy") + "                ";

                    }


                    if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Fish"))
                    {
                        Date = DateTime.Now.AddDays(7);
                        info = dtPets.Rows[i]["Name"].ToString() + " Needs Their Bowl Cleaned On: " + Date.ToString("MMMM dd, yyyy") + "                ";

                    }


                    if ((Convert.ToString(dtPets.Rows[i]["Type"]) == "Bird"))
                    {
                        Date = DateTime.Now.AddDays(9);
                        info = dtPets.Rows[i]["Name"].ToString() + " Needs Their Cage Cleaned On: " + Date.ToString("MMMM dd, yyyy") + "                ";
                    }

                    oDB.DeleteDate(oUser.ID, info);
                    oDB.AddDate(oUser.ID, dtPets.Rows[i]["Name"].ToString(), Date, info, "");

                    i++;

                }
                dtPet = oDB.GetPet(oUser.ID, PetName);
                Pet = dtPet.Rows[0]["Name"].ToString();


            }//end else


            if (!this.IsPostBack)
            {
                ddlDateSelection.Items.Insert(0, new ListItem("", ""));

                int q = 0;

                foreach (DataRow row in dtDates.Rows)
                {
                    if (dtDates.Rows[q]["Pet"].ToString() == dtPet.Rows[0]["Name"].ToString())
                    {
                        ddlDateSelection.Items.Add(new ListItem(dtDates.Rows[q]["Info"].ToString(), dtDates.Rows[q]["Info"].ToString()));

                    }
                    q++;
                }
            }

        }// End page load



        protected void btnAddDate_Click(object sender, EventArgs e)
        {
            
            ShowDateInput.Style.Add("display", "table");

            if (btnAddDate.Text == "CLICK TO ADD DATE")
            {
                DateTime Date;
                if (Regex.IsMatch(Day.Text, @"^\d+$"))
                {
                    if (Month.SelectedValue != null && Year.SelectedValue != null && Convert.ToInt32(Day.Text) > 0 && Convert.ToInt32(Day.Text) < System.DateTime.DaysInMonth(Convert.ToInt32(Year.SelectedValue), DateTime.ParseExact(Month.SelectedValue, "MMMM", CultureInfo.CurrentCulture).Month))
                    {
                        Date = Convert.ToDateTime(Month.SelectedValue + "/" + Day.Text + "/" + Year.SelectedValue);
                        oDB.AddDate(oUser.ID, Pet, Date, (Details.Text + " on " + Date.ToString("MMMM dd, yyyy")), " ");
                        ShowDateInput.Style.Add("display", "none");
                        dateadded = true;
                        Response.Redirect("calendar.aspx");

                    }
                
                    else{
                  Error.Style.Add("display", "table");

                    }
                }

                else
                {
                    Error.Style.Add("display", "table");
                    
                }

             
            }
            btnDateDelete.Style.Add("display", "none");
            btnAddDate.Text = "CLICK TO ADD DATE";
            if (dateadded)
            {
                btnAddDate.Text = "ADD DATE";
                dateadded = false;
            }


        }

        protected void btnDeleteDate_Click(object sender, EventArgs e)
        {

            DeleteSelection.Style.Add("display", "table");

            if (btnDateDelete.Text == "CLICK TO DELETE DATE")
            {
                oDB.DeleteDate(oUser.ID, ddlDateSelection.SelectedValue.ToString());
                DeleteSelection.Style.Add("display", "none");
                datedeleted = true;
                Response.Redirect("calendar.aspx");
                
            }
            btnAddDate.Style.Add("display", "none");
            btnDateDelete.Text = "CLICK TO DELETE DATE";
            if (datedeleted)
            {
                btnDateDelete.Text = "DELETE DATE";
                datedeleted = false;
            }

        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DayRender(object sender, DayRenderEventArgs e)
        {

            Session["Calendar"] = oCalendar;
            oCalendar = new Class.Calendar();
            oDB = new DB.Data();
            PetName = "";
            PetName = Request.QueryString["Name"];

            DataTable dtDates = new DataTable();
            DataTable dtPet = new DataTable();

            Debug.WriteLine(PetName);
            if (Session["User"] == null)
            {
            }

            //else if (PetName == null)
            //{
            //    oUser = (PetStore.Class.User)Session["User"];
            //    PetName = oDB.GetFirstPetName(oUser.ID);

            //    if (PetName == "")
            //    {

            //        oUser = (PetStore.Class.User)Session["User"];

            //    }

            else
            {
                oUser = (PetStore.Class.User)Session["User"];
                dtDates = oDB.GetDates(oUser.ID);
                dtPets = oDB.GetPets(oUser.ID);
                int i = 0;
                DateTime day;
                e.Day.IsSelectable = false;
                dtPet = oDB.GetPet(oUser.ID, PetName);

                foreach (DataRow row in dtDates.Rows)
                {


                    if (dtDates.Rows[i]["Pet"].ToString() == Pet)
                    {

                        day = Convert.ToDateTime(dtDates.Rows[i]["Date"]);
                        day = day.Date;


                        if (e.Day.Date == day)
                        {
                            e.Cell.BackColor = Color.LightBlue;
                            e.Day.IsSelectable = true;

                        }

                    }
                    i++;
                }


                if (e.Day.IsToday)
                {
                    e.Cell.BackColor = Color.Tomato;
                }
                else if (e.Day.IsSelected)
                {
                    e.Cell.BackColor = Color.Orange;
                }

                //    } // end else
                //}//end if PetName==Null
            }
            SqlConnection.ClearAllPools();
        }//end dayrender void


        protected void cal_SelectionChanged(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {

            }
            else
            {

                DateTime day;
                DataTable dtDates = new DataTable();
                oUser = (PetStore.Class.User)Session["User"];
                dtDates = oDB.GetDates(oUser.ID);
                int i = 0;


                foreach (DataRow row in dtDates.Rows)
                {

                    if (dtDates.Rows[i]["Pet"].ToString() == Pet)
                    {

                        day = Convert.ToDateTime(dtDates.Rows[i]["Date"]);
                        day = day.Date;

                        if (cal.SelectedDate == day)
                        {

                            DateInfo.Text = dtDates.Rows[i]["Info"].ToString();

                        }

                    }
                    i++;
                }



            } // end else
        } // end void
    }
}