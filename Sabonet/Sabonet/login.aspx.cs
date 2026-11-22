using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acesso"] != null && Convert.ToBoolean(Session["acesso"]) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mostrarAdmin", "document.getElementById('linkAdmin').style.display = 'inline';", true);
            }

        }

        void limparCampos()
        {
            TxtMail.Text = "";
            TxtSenha.Text = "";
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            LblAlerta.Text = "";
            ClsConexao conexao = new ClsConexao();
            if (TxtMail.Text != "" && TxtSenha.Text != "")
            {
                conexao.Email = TxtMail.Text;
                conexao.Senha = TxtSenha.Text;
                Session["idUsuario"] = conexao.Entrar();
                if (Session["idUsuario"] != null && Convert.ToInt32(Session["idUsuario"]) != 0)
                {
                    Response.Redirect("pagina-inicial.aspx");
                }
                else
                {
                    LblAlerta.Text = "Email ou senha incorretos.";
                }
            }
            else
            {
                LblAlerta.Text = "Preencha os campos corretamente.";
            }
            limparCampos();
        }
    }
}