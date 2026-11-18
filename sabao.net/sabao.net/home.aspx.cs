using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ClsConexao;

namespace sabao.net
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LblTitulo.Text = "Sistema de Cadastro";
                LblDescricao.Text = "Consulte as informações cadastradas.";

                LblInfo1.Text = "[Nenhum dado encontrado]";
                LblInfo2.Text = "[Nenhum dado encontrado]";
                LblInfo3.Text = "[Nenhum dado encontrado]";
            }
        }
    }
}