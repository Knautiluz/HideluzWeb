<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="ExcluirPlano.aspx.cs" Inherits="Views_Home_Administracao_DeletarBanner" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
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
                <h3 class="text-center mt-5">Escolha o Banner de Plano que deseja deletar!</h3>
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
                                    <input readonly id="input-alter" placeholder="Clique no Banner que deseja excluir." name="BannerUrl" required type="text" value="" class="form-control" />
                                </div>
                                <small id="bannerIdHelp" class="form-text text-muted">Esse banner será deletado.</small>
                            </div>
                        </div>
                    </div>
                    <div class="row d-inline">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3 mb-5">
                            <button class="btn btn-block btn-hideluz" type="submit">Excluir Plano</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

