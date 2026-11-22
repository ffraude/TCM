using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class editar_nome : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt16(Session["idUsuario"]);
            }
            catch
            {
                id = 0;
            }
            
            if (id == 0)
            {
                Response.Redirect("introducao.aspx");
            }

            ClsConexao conexao = new ClsConexao();
            Session["acesso"] = conexao.ConsultarAcesso(id);
            if (Session["acesso"] != null && Convert.ToBoolean(Session["acesso"]) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mostrarAdmin", "document.getElementById('linkAdmin').style.display = 'inline';", true);
            }

            try
            {
                LblConta.Text = Session["Nome"].ToString();
            }
            catch
            {
                LblConta.Text = "bomboclaat";
            }

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            if(TxtSenha.Text.Equals("") || TxtUsu.Text.Equals(""))
            {
                LblAlerta.Text = "Por favor, preencha todos os campos.";
                return;
            }

            ClsConexao conexao = new ClsConexao();
            bool sucesso = conexao.AlterarNome(id, TxtSenha.Text, TxtUsu.Text);
            if (sucesso)
            {
                Session["Nome"] = TxtUsu.Text;
                Response.Redirect("perfil.aspx");
            }
            else
            {
                LblAlerta.Text = "Senha incorreta. Tente novamente.";
            }
        }
    }
}