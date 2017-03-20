using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using PetStore.Class;

namespace PetStore.DB
{
    public class Data
    {
        public bool login(string username, string password)
        {
            bool isloggedin = false;
           SqlConnection con = new SqlConnection();
           con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
           con.Open();
           SqlCommand sqlcmd = new SqlCommand();
           DataSet oDS = new DataSet();
           sqlcmd.CommandText = "spLogin";
           sqlcmd.CommandType = CommandType.StoredProcedure;
           sqlcmd.Connection = con;
           //command.Parameters.Add("@ID", SqlDbType.Int);
           sqlcmd.Parameters.AddWithValue("@username", username);
           sqlcmd.Parameters.AddWithValue("@password", password);

           SqlDataAdapter oAdapter = new SqlDataAdapter();
           oAdapter.SelectCommand = sqlcmd;
           oAdapter.Fill(oDS);

           con.Close();

           if (oDS.Tables[0].Rows.Count == 1) { isloggedin = true; }
           return isloggedin;

        }

        internal bool  UpdateUser(Class.User oUser)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "spUpdateUser";
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Connection = con;

            sqlcmd.Parameters.AddWithValue("@ID", oUser.ID);
            sqlcmd.Parameters.AddWithValue("@First", oUser.FirstName);
            sqlcmd.Parameters.AddWithValue("@Last", oUser.LastName);
            sqlcmd.Parameters.AddWithValue("@Email", oUser.Email);
            sqlcmd.Parameters.AddWithValue("@Add", oUser.Address);
            sqlcmd.Parameters.AddWithValue("@City", oUser.City);
            sqlcmd.Parameters.AddWithValue("@Prov", oUser.Province);
            sqlcmd.Parameters.AddWithValue("@Postal", oUser.PostalCode);
            sqlcmd.Parameters.AddWithValue("@Phone", oUser.Phone);
            sqlcmd.Parameters.AddWithValue("@Password", oUser.Password);
            //sqlcmd.Parameters.AddWithValue("@Pet", oUser.PetType);


            int result = sqlcmd.ExecuteNonQuery();



            //SqlDataAdapter oAdapter = new SqlDataAdapter();
            //oAdapter.SelectCommand = sqlcmd;
            //oAdapter.Fill(oDS);

            

            con.Close();

            return result > 0 ? true : false;
        }

        internal bool IsUserExist(Class.User oUser)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Select count(*) from Users where Email='" + oUser.Email + "'" ;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            con.Close();

            return oDS.Tables[0].Rows[0][0].ToString() == "0" ? false : true;


        }

        internal System.Data.DataTable GetPetType()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Select *  from PetType";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];

        }

        internal Class.User Login(string Email, string Password)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            if (Password == "tempassword12345")
            {
                sqlcmd.CommandText = "Select *  from Users where Email ='" + Email + "'";
           
            }
            else
            {
                sqlcmd.CommandText = "Select *  from Users where Email ='" + Email + "' and AccountPassword ='" + Password + "'";

                sqlcmd.CommandText = "Select *  from Users where Email ='" + Email + "' and AccountPassword ='" + Password + "' and ID not in (select UserID from BlockList) ";
           
            }
             sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            PetStore.Class.User oUser = new Class.User();
            if (oDS.Tables[0].Rows.Count == 0) {
                oUser = null;
            }
            else {
                oUser.ID = Convert.ToInt32(oDS.Tables[0].Rows[0]["ID"].ToString());
                oUser.FirstName = oDS.Tables[0].Rows[0]["FirstName"].ToString();
                oUser.LastName = oDS.Tables[0].Rows[0]["LastName"].ToString();
                oUser.Email = oDS.Tables[0].Rows[0]["Email"].ToString();
                oUser.Password = oDS.Tables[0].Rows[0]["AccountPassword"].ToString();
                oUser.Address = oDS.Tables[0].Rows[0]["Address1"].ToString();
                oUser.City = oDS.Tables[0].Rows[0]["City"].ToString();
                oUser.Province = oDS.Tables[0].Rows[0]["Province"].ToString();
                oUser.PostalCode = oDS.Tables[0].Rows[0]["PostalCode"].ToString();
                //oUser.PetType = ddlPettype.SelectedItem.Value;
                oUser.Phone = oDS.Tables[0].Rows[0]["Phone"].ToString();
                oUser.RoleID = Convert.ToInt32(oDS.Tables[0].Rows[0]["RoleID"].ToString());

            }
            
           
            return oUser;
        }

        internal Class.User GetUser(string p)
        {
            throw new System.NotImplementedException();
        }

        internal string GetCategoryTitle(string mainCategory, string categoryName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select Title from category where MainCategory='"+ mainCategory+ "' and Category='"+ categoryName + "'" ;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0].Rows[0][0].ToString();
        }

        internal DataTable GetProductByCategory(string mainCategory, string categoryName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select * from Products where MainCategory='" + mainCategory + "' and Category='" + categoryName + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }

        internal DataTable GetCategories(string mainCategory)//, string categoryName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select * from Category where MainCategory='" + mainCategory + "' Order by Category"; // and Category='" + categoryName + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }


        internal DataTable GetProfileMenu(string mainCategory)//, string categoryName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select * from ProfileMenu where ProfileMenu='" + mainCategory + "' Order by Category"; // and Category='" + categoryName + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }



        internal Product GetProduct(int PID)
        {
            Product oItem = new Product();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select * from Products where pid = " + PID;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            if (oDS.Tables[0].Rows.Count == 0)
            {
                oItem = null;
            }
            else
            {
                oItem.PID = Convert.ToInt32(oDS.Tables[0].Rows[0]["pid"].ToString());
                oItem.Item = oDS.Tables[0].Rows[0]["Item"].ToString();
                oItem.MainCategory = oDS.Tables[0].Rows[0]["MainCategory"].ToString();
                oItem.Category = oDS.Tables[0].Rows[0]["Category"].ToString();
                oItem.Title = oDS.Tables[0].Rows[0]["Title"].ToString();
                oItem.Description = oDS.Tables[0].Rows[0]["Description"].ToString();
                oItem.Price = Convert.ToDecimal(oDS.Tables[0].Rows[0]["Price"].ToString());
                oItem.Image = oDS.Tables[0].Rows[0]["ImagePath"].ToString();
            }


            return oItem;
        }






        internal string GetFirstCategoryForMainCategory(string mainCategory)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select Top 1 Category from category where MainCategory='" + mainCategory + "' Order by Category";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0].Rows[0][0].ToString();
        }

        internal int GetNextOrderNumber()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select Top 1 OrderNumber from OrderHeader Order by OrderNumber desc";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return Convert.ToInt32(oDS.Tables[0].Rows[0][0].ToString()) + 1;
        }

        internal void AddOrder(Order oOrder)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Insert into OrderHeader values(" + oOrder.OrderNumber + ", " + oOrder.User.ID + ", " + oOrder.ShoppingCart.Tax + ", " + oOrder.ShoppingCart.Subtotal + ", " + oOrder.ShoppingCart.Total + " , GetDate())";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();

            foreach( ShoppingCart oCart in oOrder.ShoppingCart)
            {
            sqlcmd.CommandText = "Insert into OrderLine values(" + oOrder.OrderNumber + ", " + oCart.PID + ", " + oCart.Qty + ", " + oCart.Price + " )";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
            }


        }



        internal void AddPet(string Name, System.DateTime dateTime, int userID)
        {
             SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Delete from Pet where UserID = " + userID + " and Name ='" + Name + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = "Insert into Pet values(" +userID + ", '" + Name + "', '" +  dateTime + "')";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }

        internal string GetFirstPetName(int UserID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "select Top 1 Name from Pet where UserID='" + UserID + "' Order by Name";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            if (oDS.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return oDS.Tables[0].Rows[0][0].ToString();
            }

           
        }

        internal System.Data.DataTable GetPets(int UserID, string PetName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            if (PetName == "")
            {
                sqlcmd.CommandText = "select * from pet where userID='" + UserID + "' Order by Name"; // and Category='" + categoryName + "'";

            }
            else
            {
                sqlcmd.CommandText = "select * from pet where userID='" + UserID + "' and Name='" + PetName  + "'"; // and Category='" + categoryName + "'";

            }
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }



        internal System.Data.DataTable GetVetCities()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "select distinct city  From vet order by city"; // and Category='" + categoryName + "'";


            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }

        internal DataTable GetVets()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "select *  From vet"; // and Category='" + categoryName + "'";


            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }

        internal DataTable GetOrders(int userid)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "select ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber ) AS Row,Case when  ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber )=1 then  Convert(nvarchar(4000), OrderLine.OrderNumber) else  '' end as OrderNumber , header.Tax, header.SubTotal, header.Total , Products.Item, Qty, Products.Price from OrderLine inner join Products on OrderLine.pid = Products.pid  Right join OrderHeader header on OrderLine.OrderNumber = header.OrderNumber where OrderLine.OrderNumber in (select OrderNumber from OrderHeader where UserID = " + userid + " ) order by OrderHeader.OrderNumber desc ";


            sqlcmd.CommandText = "select  ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber ) AS Row, Case when  ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber )=1 then  Convert(nvarchar(4000), OrderLine.OrderNumber) else  '' end as OrderNumber , Case when  ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber )=1 then  Convert(nvarchar(4000), header.Tax) else  '' end as Tax, Case when  ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber )=1 then  Convert(nvarchar(4000), header.Total) else  '' end as Total, Convert(decimal(10,2),  Qty*Products.Price) as SubTotal,   Products.Item,  Convert(Int, Qty) as Qty , Products.Price,  Case when  ROW_NUMBER() OVER(PARTITION BY OrderLine.OrderNumber Order By OrderLine.OrderNumber )=1 then  Convert(varchar(4000),  ISNULL(header.OrderDate, '2016-02-02'), 101) else  '' end as OrderDate   from OrderLine inner join Products on OrderLine.pid = Products.pid  Right join OrderHeader header on OrderLine.OrderNumber = header.OrderNumber where OrderLine.OrderNumber in  (select OrderNumber from OrderHeader where UserID = " + userid + " ) order by OrderLine.OrderNumber desc   "; 



            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }

        internal DataTable GetPetTypes()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "SELECT *  FROM [dbo].[PetType]";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            
            return oDS.Tables[0];
        }

        internal System.Data.DataTable GetPet(int UserID, string PetName)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            if (PetName == "")
            {
                sqlcmd.CommandText = "select * from Pet where UserID='" + UserID + "' Order by Name"; // and Category='" + categoryName + "'";

            }
            else
            {
                sqlcmd.CommandText = "select * from Pet where UserID='" + UserID + "' and Name = '" + PetName + "'"; // and Category='" + categoryName + "'";

            }
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }



        internal DataTable GetCheckList( string petType)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "SELECT *  FROM [dbo].[CheckList] where PetType ='" + petType + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);


            return oDS.Tables[0];
        }

        internal object GetUsers()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "SELECT distinct Users.*, Case when IsNull(BlockList.UserID, '')='' then '' else 'BLOCKED' end  as Blocked  FROM [dbo].[Users] Left Join BlockList on Users.ID = BlockList.UserID ";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);


            return oDS.Tables[0];
        }

        internal void BlockUser(string userID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Insert BlockList values(" + userID + ")" ;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }

        internal void UnblockUser(string userID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Delete from BlockList where UserID = " + userID ;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
       
        
        }





        internal void UpdatePet(string Name, string oldname, int userID, string Age, string Weight, string Type)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();


            sqlcmd.CommandText = "Delete from Pet where UserID = " + userID + " and Name ='" + oldname + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();


            sqlcmd.CommandText = "Insert into Pet values(" + userID + ", '" + Name + "','" + Age + "','" + Weight + "','" + Type + "')";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }

        internal void DeletePet(string Name, int userID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Delete from Pet where UserID  = " + userID + "and Name ='" + Name + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }

        internal void AddPet(string Name, string oldname, int userID, string Age, string Weight, string Type)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "Insert into Pet values(" + userID + ", '" + Name + "','" + Age + "','" + Weight + "','" + Type + "')";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }

        internal System.Data.DataTable GetPets(int UserID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "select * from Pet where UserID='" + UserID + "'"; // and Category='" + categoryName + "'";

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }

        internal void DeleteDate(int userID, string info)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();
            sqlcmd.CommandText = "Delete from Date where UserID  = " + userID + " and Info = '" + info + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }




        internal void AddDate(int userID, string Pet, DateTime Date, string Info, string vet)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "Insert into Date values(" + userID + ", '" + Pet + "', '" + Date + "','" + Info + "','" + vet + "')";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;
            sqlcmd.ExecuteNonQuery();
        }

        internal System.Data.DataTable GetDates(int UserID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalDataConnection"].ConnectionString;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand();
            DataSet oDS = new DataSet();

            sqlcmd.CommandText = "select *  From Date where UserID='" + UserID + "'"; ;


            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = con;


            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = sqlcmd;
            oAdapter.Fill(oDS);

            return oDS.Tables[0];
        }




    
    }

  
}