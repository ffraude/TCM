using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class pagina_inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsConexao conexao = new ClsConexao();
            int id = Convert.ToInt16(Session["idUsuario"]);
            string resultadoQuery = conexao.getNomeUsuario(id);
            
            Session["Nome"] = resultadoQuery;
            if (Session["idUsuario"] != null && Convert.ToInt16(Session["idUsuario"]) != 0 && Session["Nome"] != null && !Session["Nome"].ToString().Equals(""))
            {
                LblBoasVindas.Text = "Bem-vindo(a) à Sabo.net, " + resultadoQuery + "!";
                LblConta.Text = resultadoQuery;
                linkConta.HRef = "perfil.aspx";
                Session["acesso"] = conexao.ConsultarAcesso(id);
                if (Session["acesso"] != null && Convert.ToBoolean(Session["acesso"]) == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mostrarAdmin", "document.getElementById('linkAdmin').style.display = 'inline';", true);
                }
            } else
            {
                LblBoasVindas.Text = "Bem-vindo(a) à Sabo.net!";
                LblConta.Text = "Entrar";
                linkConta.HRef = "introducao.aspx";
            }
        }
    }
}