﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="Sessao.aspx.cs" Inherits="Views_Home_Administracao_Sessao" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 col-lg-12 text-center">
                <h1>Bem-vindo <%= GetUsername() %>!</h1>
            </div>
            <div class="col-md-12 col-lg-12 text-center">
                <div class="btn-group btn-group-lg" role="group" aria-label="Botões do Banner">
                    <a href="/Views/Home/Administracao/AdicionarBanner.aspx" class="btn btn-secondary">Cadastrar Banner</a>
                    <a href="#" class="btn btn-secondary">Consultar Banners</a>
                    <a href="#" class="btn btn-secondary">Excluir Banner</a>
                    <a href="#" class="btn btn-secondary">Modificar Banner</a>
                </div>
            </div>
            <div class="col-md-8 col-lg-8 offset-md-2 offset-lg-2 mt-2 mb-2 bg-menu-trans-dark border-ease"></div>
            <div class="col-md-12 col-lg-12 text-center">
                <div class="btn-group btn-group-lg" role="group" aria-label="Botões do Banner">
                    <a href="/Views/Home/Administracao/AdicionarPlanos.aspx" class="btn btn-secondary">Cadastrar Planos</a>
                    <a class="btn btn-secondary">Consultar Planos</a>
                    <a class="btn btn-secondary">Excluir Planos</a>
                    <a class="btn btn-secondary">Modificar Planos</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
