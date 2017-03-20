<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="calNav.ascx.cs" Inherits="PetStore.Control.calNav" %>


<asp:Repeater ID="rptLeftNav" runat="server" OnItemDataBound="rptLeftNav_ItemDataBound" >

    <ItemTemplate>
       <div id ="LoadPetnames" runat="server">
        <asp:HiddenField ID="PetName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
        <a  onclick="window.location.reload()" style="text-decoration:none"  href='calendar.aspx?Name=<%# DataBinder.Eval(Container.DataItem, "Name")%>' >
            <p id="pTag" runat="server" class="NavRegCurrent">
            <%# DataBinder.Eval(Container.DataItem, "Name") %></p></a>
       </div>
     
    </ItemTemplate>
    

    
</asp:Repeater>

<br /> 

 <asp:label runat="server" id="noPet" ForeColor="Red" Font-Size="Large" />  
