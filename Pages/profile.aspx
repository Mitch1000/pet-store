<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="PetStore.Pages.profile" %>
<%@ Register src="../Control/profileheader.ascx" tagname="header" tagprefix="commonHeader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    
         <div class="row">
              <div class="col-sm-8 col-sm-offset-2">

						 


             <asp:Label id="PageTitle" runat="server" Font-Size="20px" ForeColor="#B52025"></asp:Label>
             <br /><br />
             

                    <table>
                        <tr ><td  class="regLavel">First Name:</td><td> <asp:TextBox ID="txtFirstname" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Last Name:</td><td> <asp:TextBox ID="txtLastName" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Email (site user name):</td><td><asp:TextBox ID="txtEmail" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Site password:</td><td><asp:TextBox ID="txtPassword" runat="server" CssClass="reg_input" TextMode="Password" /></td></tr>
                         <tr><td class="regLavel">Address</td><td><asp:TextBox ID="txtAddress" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">City</td><td><asp:TextBox ID="txtCity" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Province</td><td><asp:TextBox ID="txtProv" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Postal Code</td><td><asp:TextBox ID="txtPostal" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Phone Number</td><td><asp:TextBox ID="txtPhone" runat="server" CssClass="reg_input" /></td></tr>
                       <%-- <tr><td class="regLavel">Pet Type</td><td><asp:dropdownlist runat="server" ID="ddlPettype" /></td></tr>
                      --%>    
                        <tr><td></td><td></td></tr>
                         <tr><td></td><td></td></tr>
                         <tr><td></td><td> <asp:button runat="server" ID="btnSubmit" CssClass ="submit" Text="Register" OnClick="btnSubmit_Click" /></td></tr>
                          <tr><td></td><td> <asp:button runat="server" ID="btnUpdate" CssClass ="submit" Text="Update" OnClick="btnSubmit_Click" /></td></tr>
                
                    </table> 
                    
                        <asp:label runat="server" id="error" ForeColor="Red" />   
                    <asp:label runat="server" id="result" ForeColor="Green" />                           
                </div>


                       
					</div>
			

    
</asp:Content>
