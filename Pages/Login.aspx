<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PetStore.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

  <div class="row">
              <div class="col-sm-8 col-sm-offset-2">
             <h2>Log in</h2>
             
             <p>
Please Enter your Email address and password
             </p>
             

                   <div class="regform">

                    <table>
                        <tr ><td  class="regLavel">First Name:</td><td> <asp:TextBox ID="txtEmail" runat="server" CssClass="reg_input" /></td></tr>
                         <tr><td class="regLavel">Password:</td><td> <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="reg_input" /></td></tr>
                   <tr><td></td><td> 
                 </td></tr>

                         <tr><td></td><td><asp:button runat="server" ID="btnRegister" CssClass ="submit" Text="Register" OnClick="btnRegister_Click" /> &nbsp;&nbsp;&nbsp;&nbsp; <asp:button runat="server" ID="btnSubmit" CssClass ="submit"  Text="Login" OnClick="btnSubmit_Click" />
                    </td></tr>


                        <tr><td colspan="2"> <asp:label runat="server" id="error" ForeColor="Red" />  </td></tr>

                         <tr><td colspan="2">   <asp:HyperLink ID="HyperLink1" runat="Server" Text="Forgot password?" NavigateUrl="forgotpassword.aspx" /> </td></tr>
                   </table>
                    
              </div>
                        
                     
                </div>
             </div>
            
        
        
</asp:Content>
