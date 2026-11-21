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
            if (Convert.ToInt16(Session["idUsuario"]) != null || Convert.ToInt16(Session["idUsuario"]) != 0)
            {
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