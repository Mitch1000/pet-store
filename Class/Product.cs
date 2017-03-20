using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Class
{
    public class Product
    {

        private int iPid;
        private string sItem;
        private string sMainCategory;
        private string sCategory;
        private decimal dPrice;
        private string sDescription;
        private string sImage;
        private string sTitle;
       
         public int PID{

             get { return iPid; }
             set { iPid = value; }
        }

        public string Item{
            get { return sItem; }
            set { sItem = value; }
        }

        public string Title
        {
            get { return sTitle; }
            set { sTitle = value; }
        }

        public string MainCategory
        {
            get { return sMainCategory; }
            set { sMainCategory = value; }
        }

        public string Category
        {
            get { return sCategory; }
            set { sCategory = value; }
        }

        public Decimal Price
        {
            get { return dPrice; }
            set { dPrice = value; }
        }

        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        public string Image
        {
            get { return sImage; }
            set { sImage = value; }
        }

       
    }
}