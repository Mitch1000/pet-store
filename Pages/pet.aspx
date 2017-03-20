<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="pet.aspx.cs" Inherits="PetStore.Pages.pet" %>
<%@ Register src="../Control/profileheader.ascx" tagname="header" tagprefix="commonHeader" %>
<%@ Register src="../Control/petNav.ascx" tagname="LeftNav" tagprefix="custom" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    


      
 
<asp:label runat="server" id="notRegisteredError" ForeColor="Red" Font-Size="Large" />  
   
        <div class="container">
				<div class="row">
			<div class="col-md-1 col-sm-1">
                          
					</div>

					<div class="col-md-3 col-sm-6">

                        
   <custom:LeftNav ID="oLeftNav" runat="server"></custom:LeftNav>
					</div>

                    <div class="col-md-7 col-sm-6">
						
					

  <div id="pageContent" runat="server">   

       <div id="Div1" runat="server">
              
    
        
             <asp:Label id="PageTitle" runat="server" Font-Size="20px" ForeColor="#B52025"></asp:Label>
             <br /><br />
       
              
          
                <div class="pet_regform">
                    <table>
                        <tr ><td  class="PetregLavel">Name:</td><td> <asp:TextBox ID="txtFirstname" runat="server" CssClass="reg_input" /></td></tr>
                         <tr ><td  class="PetregLavel">Weight:   (lbs)</td><td> <asp:TextBox ID="Weight" runat="server" CssClass="reg_input" /></td></tr>
                            <tr ><td  class="PetregLavel">Date of Birth:</td><td> <asp:TextBox ID="Age" runat="server" CssClass="reg_input" text="yyyy-mm-dd" /></td></tr>                              
                                <tr><td  class="PetregLavel">Pet Type:</td><td>                                                  
                                <div>
                                <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem value="Cat">Cat</asp:ListItem>
                                <asp:ListItem value="Fish">Fish</asp:ListItem>
                                <asp:ListItem value="Dog">Dog</asp:ListItem>
                                <asp:ListItem value="Bird">Bird</asp:ListItem>
                                </asp:DropDownList>
                                </div></></td></tr>
  
                        <tr><td></td><td></td></tr>
                        <tr><td></td><td>
                             <asp:button runat="server" ID="btnDelete" CssClass ="submit" Text="DELETE" OnClick ="btnDelete_Click" />
                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                             <asp:button runat="server" ID="btnUpdate" CssClass ="submit_margin"  OnClick="btnSubmit_Click" />
                   &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                             <asp:button runat="server" ID="btnNew" CssClass ="submit" Text="NEW" OnClick="btnNew_Click" />
                                     </td></tr>
                                  
       
                    
                                </table> 
                    
                        <asp:label runat="server" id="error" ForeColor="Red" />   
                    <asp:label runat="server" id="result" ForeColor="Green" />                           
                </div>
            
             <asp:label runat="server" id="Label2" ForeColor="Red" /> 
   
      </div>
        
      
         <div class="center_pet_pages" id="NewButton" runat="server">  
            <table>
              <tr ><td> <asp:button runat="server" ID="btnNew2" CssClass ="submit_margin" Text="NEW" OnClick="btnNew_Click" /></td></tr>
              </table>
                </div>
         
</div>
               </div>         
     </div>
            </div>
     <div class="clear"></div>
</asp:Content>
