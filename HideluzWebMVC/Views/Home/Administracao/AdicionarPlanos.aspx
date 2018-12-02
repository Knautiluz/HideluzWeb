<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="AdicionarPlanos.aspx.cs" Inherits="Views_Home_Administracao_AdicionarPlanos" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                <form accept-charset="uft-8" method="post" enctype="multipart/form-data" target="_self">
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
                                <input required type="file" accept="image/png, image/jpeg" class="form-control" id="BannerImg" name="BannerImg">
                                <small id="emailHelp" class="form-text text-muted">Insira a imagem do banner.</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                            <span class="text-center" id="response-value"></span>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                        <button class="btn-block" type="submit">Cadastrar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
