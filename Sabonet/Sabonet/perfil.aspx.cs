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
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
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
    }
}