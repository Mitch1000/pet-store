<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="checklistnav.ascx.cs" Inherits="PetStore.Control.checklistnav" %>
<asp:Repeater ID="rptLeftNav" runat="server" OnItemDataBound="rptLeftNav_ItemDataBound">

    <ItemTemplate>
       
        <asp:HiddenField ID="PetName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PetType") %>' />
        <a style="text-decoration:none" href='checklist.aspx?Name=<%# DataBinder.Eval(Container.DataItem, "PetType")%>' >
            <p id="pTag" runat="server" class="p_left_menu">
            <%# DataBinder.Eval(Container.DataItem, "PetType") %></p></a>
    </ItemTemplate>
    

    
</asp:Repeater>

<br /> 

 <asp:label runat="server" id="noPet" ForeColor="Red" Font-Size="Large" /> 