<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PetStore.Pages.home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


              <!-- Landing Page -->

<style>
@keyframes slidy {
0% { left: 0%; }
20% { left: 0%; }
25% { left: -100%; }
45% { left: -100%; }
50% { left: -200%; }
70% { left: -200%; }
75% { left: -300%; }
95% { left: -300%; }
100% { left: -400%; }
}

body { margin: 0; } 
div#slider { overflow: hidden; }
div#slider figure img { width: 20%; float: left; }
div#slider figure { 
  position: relative;
  width: 500%;
  margin: 0;
  left: 0;
  text-align: left;
  font-size: 0;
  animation: 30s slidy infinite; 
}
</style>


    
<div id="slider">
<figure>
<img src="../Images/img3.jpg" alt="">
<img src="../Images/img4.jpg" alt="">
<img src="../Images/img6.jpg" alt="">
<img src="../Images/img4.jpg" alt="">
<img src="../Images/img6.jpg" alt="">
</figure>
</div>


  <%--  <!-- footer-widget-wrapper -->
    <div class="footer-widget-wrapper">
        <div class="container">
            <div class="row">

                <!-- footer-widget -->
                <div class="col-md-3 col-sm-6">
                    <div class="footer-widget text-widget">
                    <a href="products.aspx">
                            <h1><span>Pet</span> Products</h1>
                        </a>
                        <p>We provide all about your pet from pet products to vetenarian information. Please browse the site and register today. You can record all information for your pet(s) and be the best pet owner.</p>

                    </div>
                </div>
                <!-- footer-widget -->

                <!-- footer-widget -->
                <div class="col-md-3 col-sm-6">
                    <div class="footer-widget contact-widget">
                        <a href="products.aspx">
                            <h1><span>Pet</span> Calendar</h1>
                        </a>
                        <p>
                         The OSPS Calendar lets you track your dog's health with ease. You can keep track of vet appointments, medications, allergies and food preferences for each of your pets.
read more    
                        </p>  
                            </div>
                </div>
                <!-- footer-widget -->

                <!-- footer-widget -->
                <div class="col-md-3 col-sm-6">
                    <div class="footer-widget twitter-widget">
                        <a href="checklist.aspx">
                            <h1><span>Vet</span> Locator</h1>
                        </a>
                    <p>You can organize all of the dog parks in your city, find nearby pet stores and vets when you need them and see if any friends with dogs are in your area. </p>
                    </div>
                </div>
                <!-- footer-widget -->

                <!-- footer-widget -->
                <div class="col-md-3 col-sm-6">
                    <div class="footer-widget instagram-widget">
                        <a href="vet.aspx">
                            <h1><span>Pet</span> Calendar</h1>
                        </a>
                        <p>Your pets information, over time can be accessed as soon as you have built a weeks history. The purpose of this type of analysis it to provide you an assessment of your pets health.</p>

                        <p>
                            Here are the vetenarian hospital information in map. you can find the closest vetenarian from your place. 
                        </p>
                    </div>
                </div>
                <!-- footer-widget -->
            </div>
        </div>
    </div>
    <!-- footer-widget-wrapper -->--%>
    <!-- Start Our Services -->
    <div id="our-services">
        <div class="container padding-top padding-bottom">
            <div class="row section-title text-center">
                <div class="col-sm-8 col-sm-offset-2">
                    <h1>
                        ONE STOP PET SHOP<span> All you Pets Needs </span></h1>
                    <p>
                        One Stop Pet Shop (OSPS) understands that your pet deserves the best! We are committed to providing your pet with a Pawsitive Ecperience.OSPS carries the most extensive line of pets and pet food in the area. We have all types of pets, including kittens from the Humane Society, birds, pets, reptiles, parrots, and small animals. We also have exotic marine and tropical fish. Whether you’re already caring for a furry family member or you’re gaining a new one, our pet store has all the supplies they need, including food, treats, food and water bowls, collars, toys, flea protection products, cages, and much more.
 </p>
                </div>
            </div>
            <div class="row text-center">
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-desktop"></i>
                        <h2>
                            Responsive Layout</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.</p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-bell"></i>
                        <h2>
                            Clean Design</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.</p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-coffee"></i>
                        <h2>
                            Great Support</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.</p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-bug"></i>
                        <h2>
                            Good Features</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.
                        </p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-copyright"></i>
                        <h2>
                            Copywriting</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.
                        </p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-power-off"></i>
                        <h2>
                            Web design</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.
                        </p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-adjust"></i>
                        <h2>
                            Programming</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.
                        </p>
                    </div>
                </div>
                <div class="col-sm-6 col-md-3 service">
                    <div class="service-content">
                        <i class="fa fa-briefcase"></i>
                        <h2>
                            Marketing &amp; PR</h2>
                        <p>
                            The most remarkable feature of time is its preciousness. Its value is unfathomable
                            and its power is inestimable.
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="height">
        </div>
    </div>

    <!-- Slider -->
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="../images/333.jpg" />
            </div>
            <div class="item">
                <img src="../images/444.jpg" />
            </div>
            <div class="item">
                <img src="../images/555.jpg" />
                
            </div>
        </div>
        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                    data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                    </span><span class="sr-only">Next</span> </a>
    </div>
    <div class="container padding-bottom">
        <div class="row section-title text-center">
            <div class="col-sm-8 col-sm-offset-2">
                <h1>
                    <span>Product  </span> Brand </h1>
                <p>
                    We wish to build on our reputation as a company that really knows and cares about pets and to continue 
                    to grow as a company that is profitable, respected and positioned as one of the market leaders within pet 
                    retailing. </p>
            </div>
        </div>
        <div class="text-center our-clients">
            <ul>
                <li><a href="#">
                    <img class="img-responsive" src="../images/client1.png" alt="" /></a></li>
                <li><a href="#">
                    <img class="img-responsive" src="../images/client2.png" alt="" /></a></li>
                <li><a href="#">
                    <img class="img-responsive" src="../images/client3.png" alt="" /></a></li>
                <li><a href="#">
                    <img class="img-responsive" src="../images/client4.png" alt="" /></a></li>
                <li><a href="#">
                    <img class="img-responsive" src="../images/client5.png" alt="" /></a></li>
            </ul>
        </div>
        <!--/our-clients -->
    </div>









</asp:Content>
