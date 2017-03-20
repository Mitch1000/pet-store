<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="productDetail.aspx.cs" Inherits="PetStore.Pages.productDetail" %>
<%@ Register src="../Control/header.ascx" tagname="header" tagprefix="commonHeader" %>
<%@ Register src="../Control/leftnav.ascx" tagname="LeftNav" tagprefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

         <div class="container">
				<div class="row">
			<div class="col-md-1 col-sm-1">
                          
					</div>

					<div class="col-md-3 col-sm-6">
                           <custom:LeftNav ID="oLeftNav" runat="server" ></custom:LeftNav>
					</div>

                    <div class="col-md-7 col-sm-6">
						  <br /><br />
    
    
    <table style="width:500px; "> 
        <tr><td rowspan="7"> <asp:Image id="itemImage" runat="server" /></td><td></td></tr>
        <tr><td></td><td>  <asp:Label ID="itemTitle" Font-Bold="true" runat="server" /></td></tr>
        <tr><td></td><td> <asp:Label ID="itemDescription" runat="server" /></td></tr>
        <tr><td></td><td>Price : <asp:Label ID="itemPrice" runat="server" /></td></tr>
        <tr><td></td><td>  Qty :  <asp:TextBox ID="txtQty" runat="server" Width="25" /></td></tr>
        <tr><td></td><td>  <asp:LinkButton CssClass="linkButton" ID="LinkButton1" runat="server" Text="Add to Cart" OnClick="btnAdd_Click" /></td></tr>

        <tr><td></td><td> <asp:Label ID="txtError" ForeColor="Red" runat="server" />          
</td></tr>

    </table>
     </div>
       </div>
    </div>
</asp:Content>
