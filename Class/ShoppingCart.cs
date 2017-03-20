using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Class
{
    public class ShoppingCart
    {

        private int iPid;
        private string sItem;
        private decimal dPrice;
        private int iQty;

        public int PID
        {

            get { return iPid; }
            set { iPid = value; }
        }

        public string Item
        {
            get { return sItem; }
            set { sItem = value; }
        }

        
        public Decimal Price
        {
            get { return dPrice; }
            set { dPrice = value; }
        }

        public int Qty
        {
            get { return iQty; }
            set { iQty = value; }
        }
    }




    public class ShoppingCartCollection : CollectionBase
    {
        private decimal dTax;
        private decimal dSubtotal;
        private decimal dTotal;

        public decimal Tax
        {
            get { return dTax; }
            set { dTax = value; }
        }
        public decimal Subtotal
        {
            get { return dSubtotal; }
            set { dSubtotal = value; }
        }
        public decimal Total
        {
            get { return dTotal; }
            set { dTotal = value; }
        }


        public new ShoppingCart this[int Index]
        {
            get { return (ShoppingCart)base.List[Index]; }

        }
        public void Add(ShoppingCart Item)
        {
            base.List.Add(Item);
        }
        public ShoppingCart GetItem(int pid)
        {
            ShoppingCart oFoundItem = null;
            foreach (ShoppingCart oProduct in this)
            {
                if (oProduct.PID == pid)
                {
                    oFoundItem = oProduct;
                    break;
                }
            }
            return oFoundItem;
        }

        public void Delete(ShoppingCart Item)
        {
            base.List.Remove(Item);
        }
    }
}