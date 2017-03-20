using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using PetStore.Class;
using System.Web.UI.WebControls;

namespace PetStore.Class
{
    public class Calendar
    {

        private double FoodCaloriesPerDay;
        private int NumberofDaysWithFood;
        private System.DateTime DateNewFoodMustBePurchased;
       
     

       public System.DateTime DogFoodNeeded(double DogWeight, System.DateTime LastDogFoodPurchase, double DogFoodCaleriesPerCan)
    {
        FoodCaloriesPerDay = DogWeight * 16.042 + 290.91;
        NumberofDaysWithFood = Convert.ToInt32(DogFoodCaleriesPerCan/FoodCaloriesPerDay);
        DateNewFoodMustBePurchased = LastDogFoodPurchase.AddDays(NumberofDaysWithFood);
        return (DateNewFoodMustBePurchased);
    }

       public System.DateTime CatFoodNeeded(double CatWeight, System.DateTime LastDogFoodPurchase, double CatFoodCaleriesPerCan)
       {
           FoodCaloriesPerDay = CatWeight * 18.26 + 74.1;
           NumberofDaysWithFood = Convert.ToInt32(CatFoodCaleriesPerCan / FoodCaloriesPerDay);
           DateNewFoodMustBePurchased = LastDogFoodPurchase.AddDays(NumberofDaysWithFood);
           return (DateNewFoodMustBePurchased);
       }


    
    
    }
}