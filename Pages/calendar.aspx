<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="calendar.aspx.cs" Inherits="PetStore.Pages.calendar" %>
<%@ Register src="../Control/calNav.ascx" tagname="LeftNav" tagprefix="custom" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
              <div class="row" id="page">
              <div class="col-md-a col-sm-1">

                  </div>
<div class="col-md-3 col-sm-6">

<custom:LeftNav ID="oLeftNav" runat="server"></custom:LeftNav>
    </div>

<div class="col-md-7 col-sm-6">
    <br />    <br />


<asp:label runat="server" id="notRegisteredError" ForeColor="Red" Font-Size="Large" />
  
<div  id="pagecontent" runat="server">      
       

 <div style="float:left;">    
           <style>

.info {
        display:inline-block;
        width: 200px;
        height: auto;
        margin: 2px;
        vertical-align:top;
        
}       
.cal {
        display:inline-block;
        width: auto;
        height: auto;
        margin: 5px;      
        }

.filldate{
float:left;
color:#b52025;
text-align:left;
font-weight:bold;
}

               </style>       


<div class="cal" id="Calendar">
<asp:Calendar class="cal" id="cal" runat="server" ondayrender="DayRender"  OnSelectionChanged="cal_SelectionChanged" >
<DayStyle BackColor="#f2f2f2" 
Font-Size="Large"
BorderWidth="1"
BorderStyle="Solid">
</DayStyle>
<TitleStyle Font-Size ="x-large" Font-Bold="true" />
<DayHeaderStyle Font-Size ="large" />  
</asp:Calendar>
</div>

<div class="info" >
<table>
<tr>
<td> <asp:Label runat="server" ID="DateInfo"/></td>
</tr> 
</table> 
</div>

<div class="info" id="Error" runat="server">
<table>
<tr>
<td class="filldate"> <asp:label runat="server" id="ErrorLabel" Font-Size="Medium" Text="There is an error with the input date" /></td>
</tr> 
</table> 
</div>


<div  id="info">
<table>
   <asp:HiddenField runat="server" ID="datestore"  />
     <tr>
     <td> <asp:button runat="server" ID="btnAddDate" CssClass ="submit_margin"   OnClick ="btnAddDate_Click" Text="1"  /></td>
          </tr>
        <tr>
         <td> <asp:button runat="server" ID="btnDateDelete" CssClass ="submit_margin"   OnClick ="btnDeleteDate_Click" Text="1"  /></td>
         </tr> 
         </table> 
     
    <div class="info" id="DeleteSelection" runat="server">
     <table>
         <tr>   
          <td class="filldate">Date: </td><td>                                                                    
                                <asp:DropDownList ID="ddlDateSelection" runat="server" style="max-width:300px;">
                                </asp:DropDownList> </td>
         </tr>  

         </table>
         </div>
        
    <div class="info" id="DeleteCompleted" runat="server">
     <table>
         <tr>   
  <td class="filldate"> <asp:label runat="server" id="DeleteDone" Font-Size="Medium" Text="Your Date Has Been Deleted" /></td>
        </tr>
              </table>       
        </div>



    <div class="info" id="ShowDateInput" runat="server">
     <table>
  
     <tr>
    <td class="filldate">Year:</td><td>                                                
                                 
                                <asp:DropDownList ID="Year" runat="server" >
                                <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem value="2016">2016</asp:ListItem>
                                <asp:ListItem value="2017">2017</asp:ListItem>
                                <asp:ListItem value="2018">2018</asp:ListItem>
                                <asp:ListItem value="2019">2019</asp:ListItem>
                                </asp:DropDownList> </td>
          </tr>
         <tr>                                                                       
     <td class="filldate">Month:</td><td>                                               
                             
                                <asp:DropDownList ID="Month" runat="server" >
                                <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem value="January">January</asp:ListItem>
                                <asp:ListItem value="February">February</asp:ListItem>
                                <asp:ListItem value="March">March</asp:ListItem>
                                <asp:ListItem value="April">April</asp:ListItem>
                                <asp:ListItem value="May">May</asp:ListItem>
                                <asp:ListItem value="June">June</asp:ListItem>
                                <asp:ListItem value="July">July</asp:ListItem>
                                <asp:ListItem value="August">August</asp:ListItem>
                                <asp:ListItem value="September">August</asp:ListItem>
                                <asp:ListItem value="October">August</asp:ListItem>
                                <asp:ListItem value="November">November</asp:ListItem>
                                <asp:ListItem value="December">December</asp:ListItem>
                                </asp:DropDownList> </td>
                                   
    <td class="filldate"> Day:</td><td>  <asp:TextBox ID="Day" runat="server" style="width: 20px"/></td>
         </tr> 
      
     <tr><td></td></tr>
   <tr>
<td class="filldate"> Details:</td><td>  <asp:TextBox ID="Details" runat="server" TextMode="multiline" Columns="50" Rows="5" style="width: 250px; height:100px"  /></td>
   </tr>
  
  </table>
  </div>
      <div class="info" id="DateMade" runat="server">
      <table>
        <tr>
        <td class="filldate"> <asp:label runat="server" id="DateCreated" Font-Size="Medium" Text="Your Date Has Been Added" /></td>
        </tr>    
      </table>
  </div>

 

</div>
</div> 

</div> 
                   
</div>
</div>
        </div>
     <div class="center_pet_pages">
         </div>
</asp:Content>
