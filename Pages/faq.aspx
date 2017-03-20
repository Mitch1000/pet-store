<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="PetStore.Pages.faq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <div class="col-sm-8 col-sm-offset-2">

     <div class="center_content_pages">
        
              <div class="financial-application-form">
             <h2>Contact Us</h2>
             
             <p>
Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

             </p>
             
                <div class="form">
                    <div class="form_row">                       
                    <label>First Name:</label>
                   
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="main_input" />
                    </div>
                      <div class="form_row">
                    <label>Last Name:</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="main_input" />
                    </div> 
                    
                    <div class="form_row">
                    <label>Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="main_input" />
                    </div> 
                    
                    <div class="form_row">
                    <label>Phone:</label>
                    <input type="text" name="" class="main_input" />
                    </div> 
                    
                    <div class="form_row">
                    <label>Address</label>
                    <input type="text" name="" class="main_input" />
                    </div>  
                      
                    <div class="form_row">
                    <label>Your adress:</label>
                    <textarea class="main_textarea"></textarea>
                    </div> 
                    
                        
                    <div class="form_row">
                     <input type="submit" name="" class="submit" value="Sign up" />
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
</div>
</asp:Content>
