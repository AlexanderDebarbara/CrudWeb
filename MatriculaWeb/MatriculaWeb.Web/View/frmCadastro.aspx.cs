using MatriculaWeb.Modelo.VO;
using MatriculaWeb.Negocio.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MatriculaWeb.Web.View
{
    public partial class frmCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            AlunoBE be = null;
            try
            {
                be = new AlunoBE();
                var aluno = new AlunoVO();
                ValidarCampos();
                PopularCampos(aluno);
                be.Inserir(aluno);

                Response.Redirect(@"http://localhost:9365/View/frmlogin.aspx");
            }
            catch (Exception ex)
            {
                lblMensagem.Enabled = true;
                lblMensagem.Text = ex.Message;
            }
            finally
            {
                if (be != null) be.FecharConexao();

                be = null;

            }
        }

        private void PopularCampos(AlunoVO aluno)
        {
            try
            {
                aluno.Nome = txtNome.Value;
                aluno.Cpf = txtCpf.Value;
                aluno.Email = txtEmail.Value;
                aluno.Senha = txtSenha.Value;
                aluno.Rg = txtRg.Value;
                aluno.Uf = txtUF.Value;
                aluno.OrgaoEmissor = txtOrgaoEmissor.Value;
                aluno.Telefone = txtTelefone.Value;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"http://localhost:9365/View/frmlogin.aspx");
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Value))
                throw new Exception("Nome é Obrigatório!");

            if (string.IsNullOrEmpty(txtCpf.Value))
                throw new Exception("CPF é Obrigatório!");

            if (string.IsNullOrEmpty(txtRg.Value))
                throw new Exception("RG é Obrigatório!");

            if (string.IsNullOrEmpty(txtUF.Value))
                throw new Exception("UF é Obrigatório!");

            if (string.IsNullOrEmpty(txtOrgaoEmissor.Value))
                throw new Exception("Órgão Emissor é Obrigatório!");

            if (string.IsNullOrEmpty(txtTelefone.Value))
                throw new Exception("Telefone é Obrigatório!");

            if (string.IsNullOrEmpty(txtEmail.Value))
                throw new Exception("E-mail é Obrigatório!");

            if (string.IsNullOrEmpty(txtSenha.Value))
                throw new Exception("Senha é Obrigatório!");

            if (string.IsNullOrEmpty(txtConfirmarSenha.Value))
                throw new Exception("Confirmação de Senha é Obrigatório!");

            

            if (txtConfirmarSenha.Value != txtSenha.Value)
                throw new Exception("As senhas não são iguais");
        }
    }
}
