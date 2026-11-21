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
            
            try
            {
                id = Convert.ToInt16(Session["idUsuario"]);
            }
            catch
            {
                id = 0;
            }
            ClsConexao conexao = new ClsConexao();
            if (id == 0)
            {
                Response.Redirect("introducao.aspx");
            }

            try
            {
                LblConta.Text = Session["Nome"].ToString();
            }
            catch
            {
                LblConta.Text = "bomboclaat";
            }

            LblNome.Text = Session["Nome"].ToString();
            LblEmail.Text = conexao.getEmailUsuario(id);
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