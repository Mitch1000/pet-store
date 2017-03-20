<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" EnableEventValidation="true"  CodeBehind="checkout.aspx.cs" Inherits="PetStore.Pages.checkout" %>
<%@ Register src="../Control/headerCheckout.ascx" tagname="headerCheckout" tagprefix="HeaderCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
          <div class="row">
     <div class="col-sm-8 col-sm-offset-2">
      <HeaderCheckout:headerCheckout ID="TopHeader" runat="server"></HeaderCheckout:headerCheckout>
    <h1  style="margin-left:30px;margin-top:30px; ">SHOPPING CART</h1>
    <div style="margin-left:50px;">
    <asp:Label ID="error" runat="server"  ForeColor="Red" Font-Size="20px"/>
        </div>
    <div id="divrpt" runat="server" >
    <table style="margin-left:50px; margin-top:30px; border:1px solid #397cae; font-size:20px;">
        <asp:Repeater ID="rptShoppingCart" runat="server" OnItemCommand="rptShoppingCart_ItemCommand">
            <HeaderTemplate>
                 <tr style="background-color:#E4E9EF">
                    <td style="width:550px;">Item</td><td style="width:100px;" >Qty</td><td style="width:100px;">Price</td><td style="width:100px;">Total</td><td></td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                 <asp:HiddenField ID="hidItem" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Item") %>' />
                 <tr>
                     <td><%# DataBinder.Eval(Container.DataItem, "Item") %></td>
                     <td><%# DataBinder.Eval(Container.DataItem, "Qty") %></td>
                     <td><%# DataBinder.Eval(Container.DataItem, "Price") %></td>
                     <td><%# Convert.ToDecimal( DataBinder.Eval(Container.DataItem, "Qty")) * Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Price")) %></td>
                     <td>  <asp:Button ID="btnRemove" runat="server" Text="REMOVE" CommandName="Remove" Width="100"   /></td>
                </tr>

            </ItemTemplate>
            <FooterTemplate>
              
            </FooterTemplate>
        </asp:Repeater>
          <tr  style="border-top:1px solid #397cae;" >
                    <td style="width:450px;"></td><td style="width:100px;" ></td><td style="width:100px;">Tax</td><td style="width:100px;"><asp:Label ID="lblTax" runat="server" /></td><td></td>
                </tr>
                  <tr style="background-color:#E4E9EF">
                    <td style="width:450px;"></td><td style="width:100px;" ></td><td style="width:100px;">Total</td><td style="width:100px;"><asp:Label ID="lblTotal" runat="server" /></td><td></td>
                </tr>
     </table>
    <div style="margin-left:700px; margin-top:30px;">
        <asp:ImageButton ID="paypalbtn" runat="server" ImageUrl="../Images/paypal.gif" OnClick="paypalbtn_Click"  />
      <asp:LinkButton CssClass="linkButton" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
     </div>

        </div>

         </div>
              </div>
</asp:Content>



