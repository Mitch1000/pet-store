using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Class
{
    public class User
    {
        private int iUserID;
        private string sFirstName;
        private string sLastName;
        private string sEmail;
        private string sPassword;
        private string sAddress;
        private string sCity;
        private string sPro;
        private string sPostal;
        private string sPhone;

        private int iRoleID;
        
       
         public int ID{

             get { return iUserID; }
             set { iUserID = value; }
        }

        public string FirstName{
            get {return sFirstName; }
            set{sFirstName=value;}
        }

        public string LastName
        {
            get { return sLastName; }
            set { sLastName = value; }
        }

        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }

        public string Password
        {
            get { return sPassword; }
            set { sPassword = value; }
        }

        public string Address
        {
            get { return sAddress; }
            set { sAddress = value; }
        }

        public string City
        {
            get { return sCity; }
            set { sCity = value; }
        }

        public string Province
        {
            get { return sPro; }
            set { sPro = value; }
        }

        public string PostalCode
        {
            get { return sPostal; }
            set { sPostal = value; }
        }

        public string Phone
        {
            get { return sPhone; }
            set { sPhone = value; }
        }

        public int RoleID
        {
            get { return iRoleID; }
            set { iRoleID = value; }
        }
       
    }
}