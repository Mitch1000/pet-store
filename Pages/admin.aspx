<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="PetStore.Pages.admin" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
          <div class="row">
     <div class="col-sm-8 col-sm-offset-2">
     <div class="center_content_pages">

  <asp:label runat="server" id="notRegisteredError" ForeColor="Red" Font-Size="Large" />  

 
    <div style="float:left;margin-top:50px;">
           <table>
            <asp:Repeater ID="rptVet" runat="server" OnItemCommand="rptVet_ItemsCommand" OnItemDataBound="rptVet_ItemDataBound">
                <HeaderTemplate><tr class="ChecKListLevel"><td>FirstName</td>
                <td>LastName</td>
                <td>Email/UserName</td>
                <td>Blocked</td>
                <td>Block Button</td></tr></HeaderTemplate>
               <ItemTemplate>
                   <asp:HiddenField ID="userID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                   <asp:HiddenField ID="IsBlocked" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Blocked") %>' />
                    <tr>

                        <td style="width:150px; background-color:#fdeaeb; font-size:12px;padding-left:20px; ">
                              <%# DataBinder.Eval(Container.DataItem, "FirstName") %> 
                              </td>
                        <td style="width:150px; background-color:#fdeaeb; font-size:12px;padding-left:20px;">
                                <%# DataBinder.Eval(Container.DataItem, "LastName") %>
                        </td>
                         <td style="width:300px; background-color:#fdeaeb; font-size:12px;padding-left:20px;">
                                <%# DataBinder.Eval(Container.DataItem, "Email") %>
                        </td>
                         <td style="width:80px; background-color:#fdeaeb;">
                                <%# DataBinder.Eval(Container.DataItem, "Blocked") %>
                        </td>
                         <td style="width:100px;">
                               <asp:Button ID="btnBlockUser" runat="server" Text="BLOCK" CommandName="BLOCK" Width="100" CssClass ="submit"  />
                               <asp:Button ID="btnUnblockUser" runat="server" Text="UNBLOCK" CommandName="UNBLOCK"  Width="100"  CssClass ="submit"  />
                        </td>
                       
                    </tr>    
                   
               </ItemTemplate>

            </asp:Repeater>

        </table>
        </div>
</div>
</div>
              </div>
</asp:Content>
