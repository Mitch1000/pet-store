<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="petNav.ascx.cs" Inherits="PetStore.Control.petNav" %>


<asp:Repeater ID="rptLeftNav" runat="server" OnItemDataBound="rptLeftNav_ItemDataBound">

    <ItemTemplate>
       
        <asp:HiddenField ID="PetName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
        <a style="text-decoration:none" href='pet.aspx?Name=<%# DataBinder.Eval(Container.DataItem, "Name")%>' >
            <p id="pTag" runat="server" class="NavRegCurrent" >
            <%# DataBinder.Eval(Container.DataItem, "Name") %></p></a>
     
    </ItemTemplate>
    

    
</asp:Repeater>

<br /> 

 <asp:label runat="server" id="noPet" ForeColor="Red" Font-Size="Large" />  
