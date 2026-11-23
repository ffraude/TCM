using System;

namespace Sabonet
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            int idUsuario = Convert.ToInt32(Session["idUsuario"]);

            ClsConexao conexao = new ClsConexao();

            if (!conexao.ConsultarAcesso(idUsuario))
            {
                Response.Redirect("louja.aspx");
                return;
            }
        }
    }
}