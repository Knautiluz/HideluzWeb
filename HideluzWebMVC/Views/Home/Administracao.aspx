<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Default.master" AutoEventWireup="true" CodeFile="Administracao.aspx.cs" Inherits="Views_Home_Administracao" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="row">
        <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
            <form accept-charset="uft-8" method="post" enctype="multipart/form-data" target="_self">
                <div class="row">
                    <div class="col-md-6 col-lg-6 offset-md-3 offset-lg-3">
                        <div class="form-group">
                            <div class="input-group mb-3 mt-5">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="user-icon"><span class="fas fa-user"></span></span>
                                </div>
                                <input name="Username" type="text" class="form-control" placeholder="Usuário" aria-label="Usuário" aria-describedby="icon-user">
                            </div>

                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="password-icon"><span class="fas fa-key"></span></span>
                                </div>
                                <input name="Password" type="password" class="form-control" placeholder="Senha" aria-label="Senha" aria-describedby="icon-pass">
                            </div>
                            <button type="submit" class="btn-block">Fazer Login</button>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

