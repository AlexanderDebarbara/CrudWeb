<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCadastro.aspx.cs" Inherits="MatriculaWeb.Web.View.frmCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastrar Aluno</h1>
    <div style="padding-top: 10px;">
        <div class="panel panel-primary" runat="server">
            <div class="panel-heading">Dados do Aluno</div>
            <div class="panel-body">
                <div>
                    <div class="row">
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="lblNome" runat="server" Text="Nome: " Width="150" Height="30"></asp:Label>
                            <input id="txtNome" class="form-control" runat="server" type="text" placeholder="Nome" autocomplete="off" maxlength="100" />
                        </div>
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="lblCpf" runat="server" Text="CPF: " Width="150" Height="30"></asp:Label>
                            <input id="txtCpf" class="form-control" type="text" runat="server" placeholder="CPF" autocomplete="off" />
                        </div>

                    </div>

                    <div class="row">
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="Label1" runat="server" Text="RG: " Width="150" Height="30"></asp:Label>
                            <input id="txtRg" class="form-control" type="text" runat="server" height="30" size="200" placeholder="RG" autocomplete="off" maxlength="30"/>
                        </div>
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="Label2" runat="server" Text="UF: " Width="150" Height="30"></asp:Label>
                            <input id="txtUF" class="form-control" type="text" runat="server" height="30" size="200" placeholder="(Sigla)" autocomplete="off" maxlength="10"/>
                        </div>
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="Label3" runat="server" Text="Orgão Emissor: " Width="150" Height="30"></asp:Label>
                            <input id="txtOrgaoEmissor" class="form-control" type="text" runat="server" height="30" size="200" placeholder="Orgão Emissor:" autocomplete="off" maxlength="10" />
                        </div>
                    </div>

                    <div class="row">
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="Label4" runat="server" Text="Telefone: " Width="150" Height="30"></asp:Label>
                            <input id="txtTelefone" class="form-control" type="text" runat="server" height="30" size="200" placeholder="Telefone" autocomplete="off" maxlength="15" />
                        </div>
                        <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                            <asp:Label ID="lblEmail" runat="server" Text="E-mail: " Width="150" Height="30"></asp:Label>
                            <input id="txtEmail" class="form-control" type="text" runat="server" height="30" size="200" placeholder="E-mail" autocomplete="off" maxlength="100" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="padding-top: 10px;">
        <div class="panel panel-primary" runat="server">
            <div class="panel-heading">Dados de Acesso</div>
            <div class="panel-body">
                <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                    <asp:Label ID="lblSenha" runat="server" Text="Senha: " Width="150" Height="30"></asp:Label>
                    <input id="txtSenha" class="form-control" type="password" runat="server" height="30" size="200" placeholder="Senha" autocomplete="off" maxlength="100"/>
                </div>
                <div style="padding-bottom: 10px;" class="col-lg-4 col-md-4 col-sm-4">
                    <asp:Label ID="lblConfirmarSenha" runat="server" Text="Confirmar Senha: " Width="150" Height="30"></asp:Label>
                    <input id="txtConfirmarSenha" class="form-control" type="password" runat="server" height="30" size="200" placeholder="Confirmar Senha" autocomplete="off" maxlength="100" />
                </div>
            </div>
        </div>
    </div>
    <div>
        <div style="padding-bottom: 10px;">
            <asp:Label ID="lblMensagem" runat="server" Enabled="false" ForeColor="Red"></asp:Label>
        </div>
        <div style="padding-bottom: 10px;">
            <asp:Button ID="btnGravar" class="btn btn-default" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
            <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>
