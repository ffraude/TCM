using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class perfil : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsConexao conexao = new ClsConexao();
            try
            {
                id = Convert.ToInt16(Session["idUsuario"]);
                Session["email"] = conexao.getEmailUsuario(id);
            }
            catch
            {
                id = 0;

            }

            string resultadoQuery = Session["Nome"].ToString();
            if (Session["idUsuario"] != null && Convert.ToInt16(Session["idUsuario"]) != 0 && Session["Nome"] != null && !Session["Nome"].ToString().Equals(""))
            {
                LblConta.Text = resultadoQuery;
                linkConta.HRef = "perfil.aspx";
            }
            else
            {
                LblConta.Text = "Entrar";
                linkConta.HRef = "introducao.aspx";
            }

            if (id == 0)
            {
                Response.Redirect("introducao.aspx");
            }

            if (Session["Nome"] != null && !Session["Nome"].ToString().Equals(""))
            {
                LblNome.Text = Session["Nome"].ToString();
            }
            else
            {
                LblNome.Text = "bomboclaat";
            }

            LblEmail.Text = Session["email"].ToString();
        }

        protected void BtnSair_Click(object sender, EventArgs e)
        {
            Session["idUsuario"] = 0;
            Session["Nome"] = "";
            Response.Redirect("pagina-inicial.aspx");
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            ClsConexao conexao = new ClsConexao();
            id = Convert.ToInt16(Session["idUsuario"]);
            conexao.Excluir(id);
            Session["idUsuario"] = 0;
            Session["Nome"] = "";
            Response.Redirect("pagina-inicial.aspx");
        }
    }
}