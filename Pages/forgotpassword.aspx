<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="PetStore.Pages.forgotpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <div class="row">
              <div class="col-sm-8 col-sm-offset-2">
             <h2>Forgot password?</h2>
             
            
           <table>
              
                <tr ><td  padding:20px 20px 20px 20px">Please enter your email address. <br /></td></tr>
                        <tr><td > </td></tr>
               <tr><td style="padding:20px 20px 20px 20px"  > <asp:TextBox ID="txtEmail" runat="server" CssClass="reg_input" /></td></tr>
          
               <tr><td  style="padding:20px 20px 20px 20px" > <asp:button runat="server" ID="btnSubmit" float="right" CssClass ="submit" Text="Retrieve Password" OnClick="btnSubmit_Click" />
            </td></tr>
               <tr><td  style="padding:20px 20px 20px 20px" >  <asp:label runat="server" id="error" ForeColor="Red" Text="The Email address doesn't exist." />   <asp:label runat="server" id="result" ForeColor="Green"  Text="The new password has been sent."  />    </td></tr>
               
           </table>
         </div>  
          
          </div>        
</asp:Content>
