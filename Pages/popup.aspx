<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="PetStore.Pages.popup" %>

  <style>

       .popup { color: #333; 
                transition: .5s; 
                -moz-transition: .5s; 
                -webkit-transition: .5s; 
                -o-transition: .5s; 
                font-family: 'Muli', sans-serif; 
                white-space: pre-line;
       }

    </style>

<table>
<tr>

    <td>  <asp:label  class="popup" runat="server" id="popuptext"  Font-Size="Medium"  /> </td>

</tr>

</table>
  