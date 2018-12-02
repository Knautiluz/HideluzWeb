<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="Planos.aspx.cs" Inherits="Views_Home_Planos" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="carousel-index" class="container-fluid">
        <div class="row">
            <div class="col-md-4 col-lg-4 offset-md-4 offset-lg-4">
                <h6 class="text-center mt-5">Planos para empresas pequenas, e empresas médias!</h6>
                <div id="carouselIndex" class="carousel slide mt-4" data-ride="carousel">
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img id="carouselPictureOne" class="d-block w-100" src="<%= CarouselOneUrl() %>" alt="First slide">
                            <div class="carousel-caption d-none d-md-block bg-menu-trans-dark border-radius-medium">
                                <h5><%= CarouselOneTitle() %></h5>
                                <p><%= CarouselOneDesc() %></p>
                            </div>
                        </div>
                        <div class="carousel-item">
                            <img id="carouselPictureTwo" class="d-block w-100" src="<%= CarouselTwoUrl() %>" alt="Second slide">
                            <div class="carousel-caption d-none d-md-block bg-menu-trans-dark border-radius-medium">
                                <h5><%= CarouselTwoTitle() %></h5>
                                <p><%= CarouselTwoDesc() %> </p>
                            </div>
                        </div>
                        <div class="carousel-item">
                            <img id="carouselPictureThree" class="d-block w-100" src="<%= CarouselThreeUrl() %>" alt="Third slide">
                            <div class="carousel-caption d-none d-md-block bg-menu-trans-dark border-radius-medium">
                                <h5><%= CarouselThreeTitle() %> </h5>
                                <p><%= CarouselThreeDesc() %> </p>
                            </div>
                        </div>
                    </div>
                    <a class="carousel-control-prev" href="#carouselIndex" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselIndex" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

