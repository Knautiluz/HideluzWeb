<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="Planos.aspx.cs" Inherits="Views_Home_Planos" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="carousel-index" class="container-fluid">
        <div class="row">
            <div style="<%= BannerGenerator() != null ? "display:table;" : "display:none;" %>" class="col-md-4 col-lg-4 offset-md-4 offset-lg-4">
                <h6 class="text-center mt-5">Planos para empresas pequenas, e empresas médias!</h6>
                <div id="carouselIndex" class="carousel slide mt-4" data-ride="carousel">
                    <%= BannerGenerator() %>
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
            <div style="<%= BannerGenerator() == null ? "display:table;": "display:none;" %>" class="col-md-4 col-lg-4 offset-md-4 offset-lg-4 mt-5">
                <h3 class="alert-primary text-center border-radius-hard">No momento não existem banners cadastrados, cadastre um banner!</h3>
            </div>
        </div>
    </div>
</asp:Content>

