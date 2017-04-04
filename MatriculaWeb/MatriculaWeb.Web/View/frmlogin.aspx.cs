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
    public partial class frmlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(@"http://localhost:9365/View/frmCadastro.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            AlunoBE be = null;
            try
            {
                be = new AlunoBE();
                var aluno = new AlunoVO() { Cpf = txtLogin.Value };
                be.Consultar(aluno);

                ValidarCampos();

                if (txtLogin.Value == aluno.Cpf & txtSenha.Value == aluno.Senha)
                {
                    Response.Redirect(@"http://localhost:9365/View/PaginaInicial.aspx");
                }
                else
                {
                    throw new Exception("Senha ou login incorrretos");
                }
                

            }
            catch (Exception ex)
            {
                lblMensagem.Enabled = true;
                lblMensagem.Text = ex.Message;
            }
            finally
            {
                be = null;
            }
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtLogin.Value))
                throw new Exception("Login é Obrigatório");

            if (string.IsNullOrEmpty(txtSenha.Value))
                throw new Exception("Senha é obrigatório");
        }
    }
}