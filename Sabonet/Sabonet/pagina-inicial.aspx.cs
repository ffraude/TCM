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
            if (Convert.ToInt16(Session["idUsuario"]) == null || Convert.ToInt16(Session["idUsuario"]) == 0)
            {
                Response.Redirect("introducao.aspx");
            }
            ClsConexao conexao = new ClsConexao();
            int id = Convert.ToInt16(Session["idUsuario"]);
            string resultadoQuery = conexao.getNomeUsuario(id);
            Session["Nome"] = resultadoQuery;
            LblBoasVindas.Text = "Bem-vindo(a) à Sabo.net, " + resultadoQuery + "!";
            LblConta.Text = resultadoQuery;
        }
    }
}