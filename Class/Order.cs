using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Class
{
    public class Order
    {
        private int iOrderNumber;
        private User oUser;
        private ShoppingCartCollection oShoppingCart;

        public int OrderNumber
        {
            get { return iOrderNumber; }
            set { iOrderNumber = value; }
        }
        public User User
        {
            get { return oUser; }
            set { oUser = value; }
        }
        public ShoppingCartCollection ShoppingCart
        {
            get { return oShoppingCart; }
            set { oShoppingCart = value; }
        }
    }
}