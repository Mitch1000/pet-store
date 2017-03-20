<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profileheader.ascx.cs" Inherits="PetStore.Control.profileheader" %>

<div class="container" style="margin-top: 20px; margin-left: 20px;">

        
            <a id="lprofile" runat="server" href="..\Pages\profile.aspx"  style="text-decoration:none"  ><p class="NavRegCurrent">PROFILE</p></a>
            <a id="lpet" runat="server" href="..\Pages\pet.aspx"  style="text-decoration:none"  ><p class="NavRegCurrent" >PET</p></a>
            <a id="lcalendar" runat="server" href="..\Pages\calendar.aspx"  style="text-decoration:none"  ><p class="NavRegCurrent">CALENDAR</p></a>
             <a id="lorderhistory" runat="server" href="..\Pages\orderhistory.aspx"   style="text-decoration:none" ><p class="NavRegCurrent" >ORDER HISTORY</p></a>
           
      

      <%--  <div>
            <asp:Image ID="imgCategory" runat="server" style="max-width:900px; max-height:135px; margin:5px 5px 5px 5px;" />
            <div style="float: left;">
                <br />
                <br />
            </div>
           
        </div>--%>

    </div>
