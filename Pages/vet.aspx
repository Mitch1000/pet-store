<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="vet.aspx.cs" Inherits="PetStore.Pages.vet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   

<div class="container">          
<%--Not logged in Error--%>
<asp:label runat="server" id="notRegisteredError" ForeColor="Red" Font-Size="Large" />  

<%--Run at Server--%>       
<div  id="vetpagecontent" runat="server">
   
    
<script>
    

var infowindow = null;
var map;
var address;
var vetaddress = [10];
var locations = [0];
var VetTitle = [0];
var province = [0];
var description = [0];
var Address = [0];
var City = [0];
var Url = [0];
var Logo = [0];
var n;


<% var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); %>
vetaddress = <%= serializer.Serialize(vetaddress) %>
VetTitle = <%= serializer.Serialize(VetTitle) %>
province = <%= serializer.Serialize(province) %>
description = <%= serializer.Serialize(description) %>
Address = <%= serializer.Serialize(Address) %>
City = <%= serializer.Serialize(City) %>
Url = <%= serializer.Serialize(url) %>
Logo = <%= serializer.Serialize(logo) %>




function initMap() {

    var map = new google.maps.Map(document.getElementById('map'), {
        center: new google.maps.LatLng(43.652644, -79.381769),
        zoom: 11,
        mapTypeId: google.maps.MapTypeId.ROADMAP

    });
    var geocoder = new google.maps.Geocoder();

    setMarkers(map, people);

    infowindow = new google.maps.InfoWindow({
        content: "loading..."
    });



    //document.getElementById('submit').addEventListener('click', function () {
    //geocodeAddress(geocoder, map);
    // })


}


var people = [
    { "address": vetaddress[0], "Title": VetTitle[0] + "\n", "Description": description[0] + "\n" },
    { "address": vetaddress[1], "Title": VetTitle[1] + "\n", "Description": description[1] + "\n " },
    { "address": vetaddress[2], "Title": VetTitle[2] + "\n ", "Description": description[2] + "\n " },
    { "address": vetaddress[3], "Title": VetTitle[3] + "\n ", "Description": description[3] + "\n " },
    { "address": vetaddress[4], "Title": VetTitle[4] + "\n ", "Description": description[4] + "\n " },
    { "address": vetaddress[5], "Title": VetTitle[5] + "\n ", "Description": description[5] + "\n " },
    { "address": vetaddress[6], "Title": VetTitle[6] + "\n ", "Description": description[6] + "\n " },
    { "address": vetaddress[7], "Title": VetTitle[7] + "\n ", "Description": description[7] + "\n " },
    { "address": vetaddress[8], "Title": VetTitle[8] + "\n ", "Description": description[8] + "\n " },
    { "address": vetaddress[9], "Title": VetTitle[9] + "\n ", "Description": description[9] + "\n " },
    { "address": vetaddress[10], "Title": VetTitle[10] + "\n ", "Description": description[10] + "\n " },

];


function setMarkers(map, people) {
    for (var i = 0; i < people.length; i++) {
        setMarker(map, people[i])
    }
}

function setMarker(map, people) {
    var image = {
        url: "../Images/mapsicon.png",
        // This marker is 20 pixels wide by 32 pixels high.
        size: new google.maps.Size(55, 45),
        // The origin for this image is (0, 0).
        origin: new google.maps.Point(0, 0),
        // The anchor for this image is the base of the flagpole at (0, 32).
        anchor: new google.maps.Point(12, 44)
    };

    var p = people;
    geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': p["address"] }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);

            var marker = new google.maps.Marker({
                position: results[0].geometry.location,
                map: map,
                html: "<b>" + p["Title"] + "</b> <br>" + p["Description"] + "<br>" + p["address"],
                tite:"Vet Office",
                icon: image
            });

            var contentString = "Some content";

            google.maps.event.addListener(marker, "click", function () {
                infowindow.setContent(this.html);
                infowindow.open(map, this);
            });
        }
        else {
            //alert("Geocode was not successful for the following reason: " + status);
        }
    });
}

function googlegeocode(address, geocoder, resultsMap, callback) {

    // alert(vetlocations[n][3]);) {
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {

            callback(results);
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }

    });
}


</script>      

<div style="float:left;" class="mapcontainer">    

<div class="map" id="map"></div>

<script async="async" defer="defer" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAXEz6outqIh814vQZ-9BCzPgL5qDKRNvg&callback=initMap">
</script>
    
</div> <%--End div class="mapcontainer" --%>



<div class="info"id="info"style="vertical-align:top">
<div class="info" id="tablePrint" runat="server" style="vertical-align:top;"></div>
<div class="bookappointmentblock">
<table>
<tr>
<td> <asp:button runat='server' ID='btnBookApnt' CssClass ='submit_margin' Style="width:225px;"   OnClick ='btnBookApnt_Click' Text='1'  /></td>
</tr>  
</table> 

     <div class="info" id="ShowDateInput" runat="server">
     <table>
     <tr>
   
      <td class="filldate">Pet: </td><td>                                                                    
                                <asp:DropDownList ID="ddlPet" runat="server">
                                </asp:DropDownList> </td>
                                   
     </tr>

             <tr>
   
      <td class="filldate">Vet: </td><td>                                                                    
                                <asp:DropDownList ID="ddlVet" runat="server">
                                </asp:DropDownList> </td>
                                   
     </tr>

 
     <tr>
    <td class="filldate">Year:</td><td>                                                
                                 
                                <asp:DropDownList ID="Year" runat="server" >
                                <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem value="2016">2016</asp:ListItem>
                                <asp:ListItem value="2017">2017</asp:ListItem>
                                <asp:ListItem value="2018">2018</asp:ListItem>
                                <asp:ListItem value="2019">2019</asp:ListItem>
                                </asp:DropDownList> </td>
          </tr>
         <tr>                                                                       
     <td class="filldate">Month:</td><td>                                               
                             
                                <asp:DropDownList ID="Month" runat="server" >
                                <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem value="January">January</asp:ListItem>
                                <asp:ListItem value="February">February</asp:ListItem>
                                <asp:ListItem value="March">March</asp:ListItem>
                                <asp:ListItem value="April">April</asp:ListItem>
                                <asp:ListItem value="May">May</asp:ListItem>
                                <asp:ListItem value="June">June</asp:ListItem>
                                <asp:ListItem value="July">July</asp:ListItem>
                                <asp:ListItem value="August">August</asp:ListItem>
                                <asp:ListItem value="September">August</asp:ListItem>
                                <asp:ListItem value="October">August</asp:ListItem>
                                <asp:ListItem value="November">November</asp:ListItem>
                                <asp:ListItem value="December">December</asp:ListItem>
                                </asp:DropDownList> </td>
                                   
    <td class="filldate"> Day:</td><td>  <asp:TextBox ID="Day" runat="server" style="width: 20px"/></td>
         </tr> 
      
  
   <tr>
<td class="filldate"> Details:</td><td>  <asp:TextBox ID="Details" runat="server"    /></td>
   </tr>
  
  </table>
  </div>
 
  <div class="info" id="ApntBooked" runat="server">
      <table>
        <tr>
        <td class="filldate"> <asp:label runat="server" id="ApntBook" Font-Size="Medium" Text="Your Appointment Has Been Successfully Booked" /></td>
        </tr>    
      </table>
  </div>

</div>
</div> 
</div> <%--end of vets and book appointment class="info"--%>
                    
</div> <%--end of vet page container--%>

           
          
</asp:Content>
