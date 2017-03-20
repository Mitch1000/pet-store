using com.paypal.soap.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Class
{
    public class helper
    {

        public void GetVerificationObject(ref OBE_VerificationPayPal oPayPalVerifcation)
        {
            oPayPalVerifcation.Enviroment = BMW.Properties.Settings.Default.PayPal_Environment;
            oPayPalVerifcation.Signature = BMW.Properties.Settings.Default.PayPal_Signature;
            oPayPalVerifcation.User = BMW.Properties.Settings.Default.PayPal_User;
            oPayPalVerifcation.Password = BMW.Properties.Settings.Default.PayPal_Password;
            oPayPalVerifcation.Currency = BMW.Properties.Settings.Default.PayPal_Currency;

            oPayPalVerifcation.LastName = BMW.Properties.Settings.Default.PayPal_Bill_LastName;
            oPayPalVerifcation.FirstName = BMW.Properties.Settings.Default.PayPal_Bill_FirstName;
            oPayPalVerifcation.Address1 = BMW.Properties.Settings.Default.PayPal_Bill_Address1;
            oPayPalVerifcation.Address2 = BMW.Properties.Settings.Default.PayPal_Bill_Address2;
            oPayPalVerifcation.City = BMW.Properties.Settings.Default.PayPal_Bill_City;
            oPayPalVerifcation.Prov = BMW.Properties.Settings.Default.PayPal_Bill_Prov;
            oPayPalVerifcation.POCode = BMW.Properties.Settings.Default.PayPal_Bill_PCode;
            oPayPalVerifcation.Country = BMW.Properties.Settings.Default.PayPal_Bill_Country;
        }

        public OrderResponse PlacePayPalOrder(ref OBE_Order oOrder, string cardNumber, int year)
        {
            OrderResponse oValue = new OrderResponse();

            try
            {
                OBE_VerificationPayPal oVerificationPayPal = new OBE_VerificationPayPal();
                GetVerificationObject(ref oVerificationPayPal);
                DoDirectPaymentResponseType oDPayment = new DoDirectPaymentResponseType();
                GetTransactionDetailsResponseType oDTransDetails = new GetTransactionDetailsResponseType();
                PayPalAPI.PayPalAPI oPayPalAPI = new PayPalAPI.PayPalAPI(oVerificationPayPal.User, oVerificationPayPal.Password, oVerificationPayPal.Signature, oVerificationPayPal.Enviroment);


                try
                {

                    if (HttpContext.Current.Session["Language"] != null && HttpContext.Current.Session["Language"].ToString() == "FR")
                    {


                        if (HttpContext.Current.Session["WarrantyCheckout"] == null)
                        {
                            oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString().Replace(",", "."), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2, oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),
                        cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);
                        }

                            //made up address as we don't require it for warrantyCheckout process.
                        else
                        {

                            //oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString().Replace(",", "."), ".", oOrder.CreditCard.NameOnCard, "123 main st.", "123 main st.",
                            //HttpContext.Current.Session["city"].ToString(), "ON", "L8W1P1", "Canada", oOrder.CreditCard.CardType.ToString(),
                            //cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);

                            oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString().Replace(",", "."), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2,
                            oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),
                            cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);


                        }
                    }
                    else
                    {


                        if (HttpContext.Current.Session["WarrantyCheckout"] == null)
                        {
                            oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString(), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2, oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),
                            cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);
                        }

                            //made up address as we don't require it for warrantyCheckout process.
                        else
                        {

                            //oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString(), ".", oOrder.CreditCard.NameOnCard, "123 main st.", "123 main st.",
                            //HttpContext.Current.Session["city"].ToString(), "ON", "L8W1P1", "Canada", oOrder.CreditCard.CardType.ToString(),
                            //cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);


                            oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString(), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2,
                            oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),
                            cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);



                            HttpContext.Current.Session["WarrantyCheckout"] = null;
                        }

                    }
                    try
                    {
                        if ((oDPayment.TransactionID != null) && !string.IsNullOrEmpty(oDPayment.TransactionID))
                        {
                            oDTransDetails = oPayPalAPI.GetTransactionDetails(oDPayment.TransactionID);
                        }

                        //AddPayPalTransaction(oOrder, oDPayment, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal, false, oDTransDetails);

                    }
                    catch (Exception ex)
                    {
                    }

                    oValue = GetPayPalReceipt(oDPayment);

                    if (oValue.ResponseCode == 0 | oValue.ResponseCode == RETURNCODE.RET_CODE_SUCCESS)
                    {
                        oValue.ResponseCode = RETURNCODE.RET_CODE_SUCCESS;
                    }
                    else
                    {
                        if (HttpContext.Current.Session["Language"] != null && HttpContext.Current.Session["Language"].ToString() == "FR")
                        {

                            oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString().Replace(",", "."), ".", oOrder.CreditCard.NameOnCard, oVerificationPayPal.Address1, oVerificationPayPal.Address2, oVerificationPayPal.City, oVerificationPayPal.Prov, oVerificationPayPal.POCode, oVerificationPayPal.Country, oOrder.CreditCard.CardType.ToString(),
                            cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);

                        }
                        else
                        {
                            oDPayment = oPayPalAPI.DoDirectPayment(Math.Round(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost), 2).ToString(), ".", oOrder.CreditCard.NameOnCard, oVerificationPayPal.Address1, oVerificationPayPal.Address2, oVerificationPayPal.City, oVerificationPayPal.Prov, oVerificationPayPal.POCode, oVerificationPayPal.Country, oOrder.CreditCard.CardType.ToString(),
                            cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);
                        }
                        try
                        {
                            if ((oDPayment.TransactionID != null) && !string.IsNullOrEmpty(oDPayment.TransactionID))
                            {
                                oDTransDetails = oPayPalAPI.GetTransactionDetails(oDPayment.TransactionID);
                            }

                            //AddPayPalTransaction(oOrder, oDPayment, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal, true, oDTransDetails);

                        }
                        catch (Exception ex)
                        {
                        }


                        oValue = GetPayPalReceipt(oDPayment);

                        if (oValue.ResponseCode == 0 | oValue.ResponseCode == RETURNCODE.RET_CODE_SUCCESS)
                        {
                            oValue.ResponseCode = RETURNCODE.RET_CODE_SUCCESS;
                        }
                        else
                        {
                            oValue.ResponseCode = RETURNCODE.RET_CODE_UNKNOWN_ERROR;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if ((oDPayment.TransactionID != null) && !string.IsNullOrEmpty(oDPayment.TransactionID))
                    {
                        oDTransDetails = oPayPalAPI.GetTransactionDetails(oDPayment.TransactionID);
                    }

                    //AddPayPalTransaction(oOrder, oDPayment, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal, false, oDTransDetails);

                    oValue.ResponseCode = RETURNCODE.RET_CODE_UNKNOWN_ERROR;
                    oValue.Message = "Unknown Verisign Error";
                }
            }
            catch (Exception ex)
            {
                oValue.ResponseCode = RETURNCODE.RET_CODE_DB_UNKNOWN_ERROR;
                oValue.Message = "Unknown Verisign DB Error";
            }

            if (HttpContext.Current.Session["Language"] != null && HttpContext.Current.Session["Language"].ToString() == "FR")
            {
                if (oValue.Message.ToString() == "This transaction cannot be processed. Please enter a valid credit card number and type.")
                {
                    oValue.Message = "Cette transaction ne peut pas être traitée. Veuillez saisir un numéro et un type de carte de crédit valides.";
                }
            }


            return oValue;
        }

        // overloaded method for discount
        public OrderResponse PlacePayPalOrder(ref OBE_Order oOrder, string cardNumber, int year, float finalCharge)
        {
            OrderResponse oValue = new OrderResponse();

            try
            {


                OBE_VerificationPayPal oVerificationPayPal = new OBE_VerificationPayPal();
                GetVerificationObject(ref oVerificationPayPal);
                DoDirectPaymentResponseType oDPayment = new DoDirectPaymentResponseType();
                GetTransactionDetailsResponseType oDTransDetails = new GetTransactionDetailsResponseType();
                PayPalAPI.PayPalAPI oPayPalAPI = new PayPalAPI.PayPalAPI(oVerificationPayPal.User, oVerificationPayPal.Password, oVerificationPayPal.Signature, oVerificationPayPal.Enviroment);

                //if charges are 0 we will not go through paypal as it will not accept $0 amount
                //if (finalCharge == 0)
                //{

                //    oValue.ResponseCode = RETURNCODE.RET_CODE_SUCCESS;
                //    return oValue;
                //}



                try
                {
                    //oDPayment = oPayPalAPI.DoDirectPayment(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost).ToString(), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2, oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),


                    // oDPayment = oPayPalAPI.DoDirectPayment(((decimal)finalCharge).ToString(), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2, oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),
                    //cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);

                    oDPayment = oPayPalAPI.DoDirectPayment(((decimal)finalCharge).ToString().Replace(",", "."), ".", oOrder.CreditCard.NameOnCard, oOrder.BillingCustomer.Address.Address1, oOrder.BillingCustomer.Address.Address2, oOrder.BillingCustomer.Address.City, oOrder.BillingCustomer.Address.ProvState, oOrder.BillingCustomer.Address.POCode, oOrder.BillingCustomer.Address.Country, oOrder.CreditCard.CardType.ToString(),
                       cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Authorization, oVerificationPayPal.Currency);


                    try
                    {
                        if ((oDPayment.TransactionID != null) && !string.IsNullOrEmpty(oDPayment.TransactionID))
                        {
                            oDTransDetails = oPayPalAPI.GetTransactionDetails(oDPayment.TransactionID);
                        }

                        //AddPayPalTransaction(oOrder, oDPayment, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal, false, oDTransDetails);

                    }
                    catch (Exception ex)
                    {
                    }

                    oValue = GetPayPalReceipt(oDPayment);

                    if (oValue.ResponseCode == 0 | oValue.ResponseCode == RETURNCODE.RET_CODE_SUCCESS)
                    {
                        oValue.ResponseCode = RETURNCODE.RET_CODE_SUCCESS;
                    }
                    else
                    {
                        //oDPayment = oPayPalAPI.DoDirectPayment(((decimal)oOrder.Subtotal + oOrder.GST.Amount + oOrder.PST.Amount + (decimal)oOrder.ShippingCost).ToString(), ".", oOrder.CreditCard.NameOnCard, oVerificationPayPal.Address1, oVerificationPayPal.Address2, oVerificationPayPal.City, oVerificationPayPal.Prov, oVerificationPayPal.POCode, oVerificationPayPal.Country, oOrder.CreditCard.CardType.ToString(),
                        oDPayment = oPayPalAPI.DoDirectPayment(((decimal)finalCharge).ToString(), ".", oOrder.CreditCard.NameOnCard, oVerificationPayPal.Address1, oVerificationPayPal.Address2, oVerificationPayPal.City, oVerificationPayPal.Prov, oVerificationPayPal.POCode, oVerificationPayPal.Country, oOrder.CreditCard.CardType.ToString(),
                        cardNumber, oOrder.CreditCard.CVV, Int32.Parse(oOrder.CreditCard.ExpiryMonth), year, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal.Currency);

                        try
                        {
                            if ((oDPayment.TransactionID != null) && !string.IsNullOrEmpty(oDPayment.TransactionID))
                            {
                                oDTransDetails = oPayPalAPI.GetTransactionDetails(oDPayment.TransactionID);
                            }

                            //AddPayPalTransaction(oOrder, oDPayment, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal, true, oDTransDetails);

                        }
                        catch (Exception ex)
                        {
                        }


                        oValue = GetPayPalReceipt(oDPayment);

                        if (oValue.ResponseCode == 0 | oValue.ResponseCode == RETURNCODE.RET_CODE_SUCCESS)
                        {
                            oValue.ResponseCode = RETURNCODE.RET_CODE_SUCCESS;
                        }
                        else
                        {
                            oValue.ResponseCode = RETURNCODE.RET_CODE_UNKNOWN_ERROR;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if ((oDPayment.TransactionID != null) && !string.IsNullOrEmpty(oDPayment.TransactionID))
                    {
                        oDTransDetails = oPayPalAPI.GetTransactionDetails(oDPayment.TransactionID);
                    }

                    //AddPayPalTransaction(oOrder, oDPayment, com.paypal.soap.api.PaymentActionCodeType.Sale, oVerificationPayPal, false, oDTransDetails);

                    oValue.ResponseCode = RETURNCODE.RET_CODE_UNKNOWN_ERROR;
                    oValue.Message = "Unknown Verisign Error";
                }
            }
            catch (Exception ex)
            {
                oValue.ResponseCode = RETURNCODE.RET_CODE_DB_UNKNOWN_ERROR;
                oValue.Message = "Unknown Verisign DB Error";
            }
            if (HttpContext.Current.Session["Language"] != null && HttpContext.Current.Session["Language"].ToString() == "FR")
            {
                if (oValue.Message.ToString() == "This transaction cannot be processed. Please enter a valid credit card number and type.")
                {
                    oValue.Message = "Cette transaction ne peut pas être traitée. Veuillez saisir un numéro et un type de carte de crédit valides.";
                }
            }


            return oValue;
        }


        private OrderingResponse GetPayPalReceipt(DoDirectPaymentResponseType PayPalResponse)
        {
            OrderResponse oVerisignReceipt = new OrderResponse();

            try
            {
                oVerisignReceipt.AuthCode = PayPalResponse.TransactionID;
                oVerisignReceipt.ReferenceNumber = PayPalResponse.CorrelationID;


                if (PayPalResponse.Ack == AckCodeType.Success | PayPalResponse.Ack == AckCodeType.SuccessWithWarning)
                {
                    oVerisignReceipt.ResponseCode = RETURNCODE.RET_CODE_SUCCESS;
                    oVerisignReceipt.Success = true;
                    oVerisignReceipt.Message = PayPalResponse.PaymentStatus.ToString();
                }
                else
                {
                    oVerisignReceipt.ResponseCode = RETURNCODE.RET_CODE_UNKNOWN_ERROR;
                    oVerisignReceipt.Success = false;
                    oVerisignReceipt.Message = PayPalResponse.Errors[0].LongMessage;
                }

                oVerisignReceipt.BankTotals = 0;
                oVerisignReceipt.CardType = "";
                oVerisignReceipt.Complete = true;
                oVerisignReceipt.ISO = 0;
                oVerisignReceipt.ReceiptID = "";
                oVerisignReceipt.Ticket = "";
                oVerisignReceipt.TimedOut = false;
                oVerisignReceipt.TransAmount = 0;
                oVerisignReceipt.TransDate = DateTime.Now;
                oVerisignReceipt.TransID = "";
                oVerisignReceipt.TransTime = DateTime.Now;
                oVerisignReceipt.TransType = "";
            }
            catch (Exception ex)
            {
                //WriteToEventLog(EventLogEntryType.Error, "GetMonerisObjectFromVeriSignResponse", ex.ToString)
                oVerisignReceipt = new OrderResponse();
                oVerisignReceipt.Message = "Invalid VeriSignResponse";
            }

            return oVerisignReceipt;
        }
    }
}