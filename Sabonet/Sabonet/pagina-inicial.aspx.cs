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
            int id = Convert.ToInt32(Session["idUsuario"]);
            if (Session["idUsuario"] != null)
            {
                try
                {
                    LblDescartavel.Text = "Bem-vindo(a), " + conexao.getNomeUsuario(id) + "!!!";
                }
                catch (InvalidOperationException ex)
                {
                    LblDescartavel.Text = "Bem-vindo(a)!!!";
                }
            }
        }
    }
}