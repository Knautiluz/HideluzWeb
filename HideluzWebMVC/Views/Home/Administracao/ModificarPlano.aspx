<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="ModificarPlano.aspx.cs" Inherits="Views_Home_Administracao_AlterarBanner" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>
        $(document).ready(function () {
            $("img").click(function (event) {
                var url = event.target.src.lastIndexOf('/');
                $('#input-alter').val(event.target.src.substring(url + 1));
            });
        });
    </script>
    <div id="carousel-index" class="container-fluid">
        <div class="row">
            <div class="col-md-4 col-lg-4 offset-md-4 offset-lg-4">
                <h3 class="text-center mt-5">Escolha o Banner de plano que deseja modificar!</h3>
                <div id="carouselIndex" class="carousel slide mt-4" data-ride="carousel" data-interval="false">
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
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                <form accept-charset="uft-8" method="post" enctype="multipart/form-data" target="_self">
                    <div class="row">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3 mt-3">
                            <div class="form-group">
                                <label for="input-alter">Dados do Banner que deseja alterar</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><span class="fas fa-link"></span></span>
                                    </div>
                                    <input readonly id="input-alter" placeholder="Clique no plano que deseja alterar." name="BannerUrl" required type="text" value="" class="form-control" />
                                </div>
                                <small id="bannerIdHelp" class="form-text text-muted">Esse banner será alterado com as informações a seguir.</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                            <div class="form-group">
                                <label for="bannerTitle">Titulo do Banner de Planos</label>
                                <input required type="text" class="form-control" id="BannerTitle" name="BannerTitle" placeholder="Escreva o Titulo do Banner">
                                <small id="bannerTitleHelp" class="form-text text-muted">Ex: Plano Básico, Premium, Ultimate</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                            <div class="form-group">
                                <label for="BannerDesc">Descrição do Plano</label>
                                <input required type="text" class="form-control" id="BannerDesc" name="BannerDesc" placeholder="Escreva a descrição do Plano">
                                <small id="bannerDescHelp" class="form-text text-muted">Ex: Permite até 5 milhões de estacionamentos</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                            <div class="form-group">
                                <label for="BannerImg">Imagem do Banner de Plano</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><span class="fas fa-image"></span></span>
                                    </div>
                                    <input required type="file" accept="image/png, image/jpeg" class="form-control" id="BannerImg" name="BannerImg">
                                </div>
                                <small id="emailHelp" class="form-text text-muted">Insira a imagem do banner.</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                            <span class="text-center" id="response-value"></span>
                        </div>
                    </div>
                    <div class="row d-inline">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3 mb-5">
                            <button class="btn btn-block btn-hideluz" type="submit">Modificar Plano</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
