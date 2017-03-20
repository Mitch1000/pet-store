<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PetStore.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center_content_pages">
        
              <div class="financial-application-form">
             <h2>Log in</h2>
             
             <p>
Please Enter your Email address and password
             </p>
             
                <div class="form">
                    
                    <div class="form_row">
                    <label>Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="main_input" />
                    </div> 
                    
                    <div class="form_row">
                    <label>Password :</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="main_input" TextMode="Password" />
                    </div> 
                    
                    <div class="form_row">
                     <asp:button runat="server" ID="btnSubmit" CssClass ="submit" Text="Login" OnClick="btnSubmit_Click" />
                    </div>
                <div class="form_row"> 
                    <asp:label runat="server" id="error" ForeColor="Red" />   
              </div>

             <div class="form_row"> 
                       <asp:HyperLink ID="HyperLink1" runat="Server" Text="Forgot password?" NavigateUrl="forgotpassword.aspx" />
              </div>
                     
                </div>
             </div>
            
             <div class="testimonials">
                    <h2>Stories and Testimonials </h2>
                    <p>
Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                    
                    <div class="testbox">
                    <h4>Stories:  </h4>
                    <p>
                    Sed do eiusmod tempor incididunt
                    </p>
                    </div>
                    
                    <div class="testbox">
                    <h4>It eiusmod tempor incididunt</h4>
                    <p>
Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                    </div>             
                    <div class="testbox">
                    <h4>It consectetur adipisicing elit</h4>
                    <p>
Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </p>
                    </div>               
                    
             </div>
        
        
        
   
        
        <div class="clear"></div>
        </div>
</asp:Content>
