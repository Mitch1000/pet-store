<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="PetStore.Control.header" %>
<%@ Register src="../Control/leftnav.ascx" tagname="LeftNav" tagprefix="custom" %>

            

       <%-- <ul>
            <li><a id="ldog" runat="server" href="..\Pages\Products.aspx?MainCat=DOG" class="headNav"><span>DOG</span></a></li>
            <li><a id="lcat" runat="server" href="..\Pages\Products.aspx?MainCat=CAT" class="headNav"><span>CAT</span></a></li>
            <li><a id="lfish" runat="server" href="..\Pages\Products.aspx?MainCat=FISH" class="headNav"><span>FISH</span></a></li>
            <li><a id="lbird" runat="server" href="..\Pages\Products.aspx?MainCat=BIRD" class="headNav"><span>BIRD</span></a></li>
        </ul>--%>

 <div class="container">
            <div class="row">
                <div class="intro-message col-sm-6">
        <asp:Image ID="imgCategory" runat="server" style="max-width:300px; max-height:300px; margin-left:20px;"/>
             
                    
            </div>
           
        </div>
  </div>

