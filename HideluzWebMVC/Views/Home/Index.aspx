<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Views_Home_Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div id="carousel-index" class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-lg-8 offset-md-2 offset-lg-2">
                <h6 class="text-center mt-5">Nosso sistema foi desenvolvido pensando em transformar seu sistema em um sistema digital!</h6>
                <div id="carouselIndex" class="carousel slide mt-4" data-ride="carousel">
                    <div class="carousel-inner">
                        <%= BannerGenerator() %>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

