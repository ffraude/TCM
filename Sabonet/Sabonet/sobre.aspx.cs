using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class sobre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsConexao conexao = new ClsConexao();
            int id;
            if (Session["idUsuario"] != null && int.TryParse(Session["idUsuario"].ToString(), out id) && id != 0)
            {
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
                linkConta.HRef = "perfil.aspx";
            }
            else
            {
                LblConta.Text = "Entrar";
                linkConta.HRef = "introducao.aspx";
            }

        }
    }
}