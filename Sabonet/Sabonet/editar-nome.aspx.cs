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

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            
        }
    }
}