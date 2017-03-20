<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="orderhistory.aspx.cs" Inherits="PetStore.Pages.orderhistory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    
    
         <div class="row">
              <div class="col-sm-8 col-sm-offset-2">


                  <asp:Label id="PageTitle" runat="server" Font-Size="20px" ForeColor="#B52025" Text ="Order History"></asp:Label>
    <asp:label runat="server" id="notRegisteredError" ForeColor="Red" Font-Size="Large" />  

              <div style="float:left;margin-top:50px; margin-left: 20px">
           <table>
            <asp:Repeater ID="rptOrder" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td  class="Level" style="width:70px;" >Order Number</td>
                        <td class="Level" style="width:300px;">Item Code</td>
                        <td  class="Level" style="width:40px;">Qty</td>
                        <td  class="Level" style="width:80px;">Price</td>
                        <td  class="Level" style="width:100px;">SubTotal</td>
                        <td  class="Level" style="width:80px;">Tax</td>
                        <td  class="Level" style="width:100px;">Total</td>
                         <td  class="Level" style="width:100px;">Order Date</td>
                    </tr>

                </HeaderTemplate>
               <ItemTemplate>
              
                    <tr>

                        <td   class="eachLevel" style="text-align:center" >
                             <%# DataBinder.Eval(Container.DataItem, "OrderNumber") %>                      
                        </td><td  class="eachLevel" style="text-align:left">
                             <%# DataBinder.Eval(Container.DataItem, "Item") %>                   
                        </td><td  class="eachLevel" style="text-align:center">
                             <%# DataBinder.Eval(Container.DataItem, "Qty") %>                     
                        </td><td  class="eachLevel" style="text-align:right">
                             <%# DataBinder.Eval(Container.DataItem, "Price") %>                      
                        </td><td  class="eachLevel" style="text-align:right">
                             <%# DataBinder.Eval(Container.DataItem, "SubTotal") %>                   
                        </td> <td  class="eachLevel" style="text-align:right">
                             <%# DataBinder.Eval(Container.DataItem, "Tax") %>                   
                        </td> 
                        <td  class="eachLevel" style="text-align:right">
                             <%# DataBinder.Eval(Container.DataItem, "Total") %>                   
                        </td>  
                        <td  class="eachLevel" style="text-align:left">
                             <%# DataBinder.Eval(Container.DataItem, "OrderDate") %>                   
                        </td>                                       

                    </tr>
                    
                       
                               
                   
               </ItemTemplate>

            </asp:Repeater>

        </table>
        </div>

       </div></div>

 </asp:Content>