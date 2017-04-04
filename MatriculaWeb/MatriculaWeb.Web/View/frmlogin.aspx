<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmlogin.aspx.cs" Inherits="MatriculaWeb.Web.View.frmlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-7 col-lg-8">
            <h1>Matricula Web</h1>
            <img src="http://www.seduc.mt.gov.br/documents/img/NovoBrasao.png" class="img-responsive" />

            <h3>ATENÇÃO</h3>
            <P>Matrícula web é destinada aos alunos que não constam no quadro das escolas da Rede Estadual, isto é, novos na 
            unidade escolar, alunos com cadastro na situação de desistente ou abandono e alunos que solicitaram transferência 
            de uma unidade escolar da Rede Estadual para outra, a próxima etapa será de 20/02/2017 a 24/02/2017.</P>
        </div>


        <div class="col-xs-12 col-sm-12 col-md-5 col-lg-4">
            <div style="padding-top: 10px;">
                <div class="panel panel-primary" runat="server">
                    <div class="panel-heading">Login</div>
                    <div class="panel-body">
                        <div>
                            <asp:Label ID="lblLogin" runat="server" Text="Usuário de acesso(CPF cadastrado): " Width="500" Height="30"></asp:Label>
                        </div>
                        <div style="padding-bottom: 10px;">
                            <input id="txtLogin" runat="server" class="form-control" type="text" height="30" size="200" autocomplete="off" />
                        </div>
                        <div>
                            <div>
                                <asp:Label ID="lblSenha" runat="server" Text="Senha: " Width="100" Height="30"></asp:Label>
                            </div>
                            <div style="padding-bottom: 10px;">
                                <input id="txtSenha" class="form-control" type="password" runat="server" height="30" size="200" autocomplete="off" />
                            </div>
                        </div>
                        <div style="padding-bottom: 10px;">
                            <asp:Label ID="lblMensagem" runat="server" Enabled="false" ForeColor="Red"></asp:Label>
                        </div>
                        <div>
                            <asp:Button ID="btnEntrar" class="btn btn-default" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                            <asp:Button ID="btnCadastrar" class="btn btn-default" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />

                        </div>
                    </div>
                </div>
            </div>

        </div>


    </div>

</asp:Content>
