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
            if(Session["idUsuario"] != null)
            {
                LblDescartavel.Text = Session["idUsuario"].ToString();
            } 
        }
    }
}