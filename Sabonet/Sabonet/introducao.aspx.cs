using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class introducao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acesso"] != null && Convert.ToBoolean(Session["acesso"]) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mostrarAdmin", "document.getElementById('linkAdmin').style.display = 'inline';", true);
            }

        }

        protected void butao_semseropais_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void butao_maseopais_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }
    }
}