<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PetStore.Pages.Products" %>

<%@ Register src="../Control/leftnav.ascx" tagname="LeftNav" tagprefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  
  
    <div class="container">
				<div class="row">
			<div class="col-md-1 col-sm-1">
                          
					</div>

					<div class="col-md-3 col-sm-6">
                           <custom:LeftNav ID="oLeftNav" runat="server" ></custom:LeftNav>
					</div>

                    <div class="col-md-7 col-sm-6">
						  <br /><br />
						 <div id="divProduct" runat="server" class="productContainer">
        <asp:Label ID="categoryTitle" runat="server"></asp:Label><br /><br /><br />
                
        <div style="margin-left:50px;">
         <asp:LinkButton CssClass="linkButton" ID="btnAddAll" runat="server" Text="ADD ALL TO CART" OnClick="btnAddAll_Click" />
            <asp:Label ID="txtError" ForeColor="Red" runat="server" /> 
           <br />
             </div>
                <div style="margin-left: 60px;">
                    <asp:Repeater ID="rptProduct" runat="server" OnItemCommand="rptProduct_ItemsCommand">
                        <ItemTemplate>
                            <div>
                                <div class="productBox" runat="server">
                                    <asp:HiddenField ID="hiddenFieldPID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "pid") %>' />
                                      <a href='productDetail.aspx?MainCat=<%# DataBinder.Eval(Container.DataItem, "MainCategory") %>&amp;Cat=<%# DataBinder.Eval(Container.DataItem, "Category") %>&amp;pid=<%# DataBinder.Eval(Container.DataItem, "pid") %>'>
                                        <img style="max-height: 180px; max-width: 150px" src='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' /></a>
                                    <p class="productTitle" runat="server"><a  href='productDetail.aspx?MainCat=<%# DataBinder.Eval(Container.DataItem, "MainCategory") %>&amp;Cat=<%# DataBinder.Eval(Container.DataItem, "Category") %>&amp;pid=<%# DataBinder.Eval(Container.DataItem, "pid") %>'><%# DataBinder.Eval(Container.DataItem, "Title") %></a></p>
                                    <p class="productPrice" runat="server">$<%# DataBinder.Eval(Container.DataItem, "Price") %></p>
                                    Qty : <asp:TextBox ID="txtQty" runat="server" Width="25" />
                                  <%--  <asp:LinkButton CssClass="linkButton" ID="btnAdd" runat="server" Text="Add to Cart" CommandName="Add" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "pid") %>' />--%>
                                   
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>
                </div>
            </div>
                       
					</div>
			
				</div>
			</div>



</asp:Content>
