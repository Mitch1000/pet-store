<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="leftnav.ascx.cs" Inherits="PetStore.Control.leftnav" %>



<asp:Repeater ID="rptLeftNav" runat="server" OnItemDataBound="rptLeftNav_ItemDataBound">

    <ItemTemplate>
       
        <asp:HiddenField ID="CategoryName" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Category") %>' />
        <a  style="text-decoration:none" href='Products.aspx?MainCat=<%# DataBinder.Eval(Container.DataItem, "MainCategory")%>&amp;Cat=<%# DataBinder.Eval(Container.DataItem, "Category")%>' >
            <p id="pTag" runat="server" class="NavRegCurrent">
            <%# DataBinder.Eval(Container.DataItem, "Category") %></p></a>
     
    </ItemTemplate>

</asp:Repeater>

