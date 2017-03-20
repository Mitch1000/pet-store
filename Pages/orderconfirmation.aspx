<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="orderconfirmation.aspx.cs" Inherits="PetStore.Pages.orderconfirmation" %>
<%@ Register src="../Control/headerCheckout.ascx" tagname="headerCheckout" tagprefix="HeaderCheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <div class="row">
     <div class="col-sm-8 col-sm-offset-2">
      <HeaderCheckout:headerCheckout ID="TopHeader" runat="server"></HeaderCheckout:headerCheckout>
    <h1  style="margin-left:30px;margin-top:30px; ">ORDER CONFIRMATION</h1>

    <h3  style="margin-left:30px;margin-top:30px; " > Thanks for using our store. Your order number is <asp:Label ID="lblOrderNumber" runat="server" />. We will send the order confirmation email shortly.

    </h3>
    <table style="margin-left:50px; margin-top:30px; border:1px solid #397cae; font-size:20px;text-align:right; ">
        <asp:Repeater ID="rptShoppingCart" runat="server">
            <HeaderTemplate>
                 <tr style="background-color:#E4E9EF;text-align:center;">
                    <td style="width:550px;">Item</td><td style="width:100px;" >Qty</td><td style="width:100px;">Price</td><td style="width:100px;">Total</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                 <tr>
                     <td  style="text-align:left;"><%# DataBinder.Eval(Container.DataItem, "Item") %></td>
                     <td><%# DataBinder.Eval(Container.DataItem, "Qty") %></td>
                     <td><%# DataBinder.Eval(Container.DataItem, "Price") %></td>
                     <td><%# String.Format("{0:F2}",Convert.ToDecimal( DataBinder.Eval(Container.DataItem, "Qty")) * Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Price"))) %></td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>
             <tr  style="background-color:#E4E9EF" >
                    <td style="width:450px;text-align:center;">Tax</td><td style="width:100px;" ></td><td style="width:100px;"></td><td style="width:100px;"><asp:Label ID="lblTax" runat="server" /></td>
                </tr>
                  <tr style="background-color:#E4E9EF">
                    <td style="width:450px;text-align:center;">Total</td><td style="width:100px;" ></td><td style="width:100px;"></td><td style="width:100px;"><asp:Label ID="lblTotal" runat="server" /></td>
                </tr>
     </table>
         </div>
           </div>
    </asp:Content>