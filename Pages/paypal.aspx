<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paypal.aspx.cs" Inherits="PetStore.Pages.paypal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript">
            //window.onload = RedirectPayPal();
            function RedirectPayPal() {
                var oForm, sFirstName, sLastName, sPayAmount, sItemNumber, sCountry, sAddress1, sCity, sProvState, sPOCode, sEmail, sPhone, sOrderNumber;
                oForm = document.getElementById('form1');
                sFirstName = document.getElementById('pay_first_name');
                sLastName = document.getElementById('pay_last_name');
                sPayAmount = document.getElementById('pay_amount');
                sItemNumber = document.getElementById('pay_item_number');
                sCountry = document.getElementById('pay_country');
                sAddress1 = document.getElementById('pay_address1');
                sCity = document.getElementById('pay_city');
                sProvState = document.getElementById('pay_state');
                sPOCode = document.getElementById('pay_zip');
                sEmail = document.getElementById('pay_email');
                sPhone = document.getElementById('pay_phone');
                sOrderNumber = document.getElementById('pay_item_number');

                sFirstName.value = '<%=oUser.FirstName%>';
                sLastName.value = '<%= oUser.LastName%>';
                sPayAmount.value = '<%=Math.Round(oShoppingCartCollection.Total, 2)%>';
                sOrderNumber.value = '<%=oOrder.OrderNumber%>';
                sAddress1.value = '123 Main';
                sCity.value = 'Hamilton';
                sProvState.value = 'ON';
                sEmail.value = 'dtechtest5@gmail.com';
                //'dtechtest5_api1.gmail.com' //username
                //'ALg.Y44Ypti5SlWwlq7GVHCb0ldpAO3SiCbxnI1j0hUvG8Oj-0iuODQz' //Signature
                //'JW5TRKTXBRTHNYBG' //password
                //Q3GHA592B2HSU merchadize id
                oForm.action = "https://www.sandbox.paypal.com/cgi-bin/webscr";

                oForm.submit();

            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <input type="hidden" name="tx" value="JW5TRKTXBRTHNYBG" />
        <input type="hidden" name="at" value="ALg.Y44Ypti5SlWwlq7GVHCb0ldpAO3SiCbxnI1j0hUvG8Oj-0iuODQz"/>
        <input type="hidden" name="cmd" value="_xclick"/>
        <input type="hidden" name="business" value="Q3GHA592B2HSU" />
        <input type="hidden" name="return"  value="http://localhost:53486/Pages/orderconfirmation.aspx"/>
        <input type="hidden" name="cancel_return" value="http://localhost:53486/Pages/checkout.aspx"/>
        <input type="hidden" name="lc" value="CA"/>

        <input type="hidden" name="item_name" value="One Shop Pet Store"/>
        <input type="hidden" name="item_number" id="pay_item_number"/>
        <input type="hidden" name="amount" id="pay_amount"/>

        <input type="hidden" name="currency_code" value="CAD"/>
        <input type="hidden" name="button_subtype" value="products"/>
        <input type="hidden" name="country" id="pay_country"/>
        <input type="hidden" name="first_name" id="pay_first_name"/>
        <input type="hidden" name="last_name" id="pay_last_name"/>        
        <!--<input type="hidden" name="payer_business_name" value="KBC Systems">-->
        <input type="hidden" name="address1" id="pay_address1"/>
        <input type="hidden" name="city" id="pay_city"/>
        <input type="hidden" name="state" id="pay_state"/>
        <input type="hidden" name="zip" id="pay_zip"/>
        <input type="hidden" name="email" id="pay_email"/>
        <input type="hidden" name="home_phone_a" id="pay_phone"/>  

    </div>
    </form>
</body>
</html>
