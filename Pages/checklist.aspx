<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="checklist.aspx.cs" Inherits="PetStore.Pages.checklist" %>
<%@ Register src="../Control/headerChecklist.ascx" tagname="header" tagprefix="commonHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <commonHeader:header ID="TopHeader" runat="server"></commonHeader:header>

                       
            <div class="row">
              <div class="col-sm-8 col-sm-offset-2">


  <asp:label runat="server" id="notRegisteredError" ForeColor="Red" Font-Size="Large" />  

 
           <table >
            <asp:Repeater ID="rptVet" runat="server">
               
               <ItemTemplate>
                    <tr >
                        <td class="ChecKListLevel" style="width:150px; background-color:#fdeaeb; ">
                             <%# DataBinder.Eval(Container.DataItem, "Item") %><br /><br />
                        </td>
                        <td style="width:650px; font-size:15px; background-color:#fdeaeb; padding:10px; margin:10px">
                              <%# DataBinder.Eval(Container.DataItem, "Description") %> <br /><br />
                        </td>
                    </tr>
               </ItemTemplate>

            </asp:Repeater>

        </table>
        </div>


</div>

     

</asp:Content>
