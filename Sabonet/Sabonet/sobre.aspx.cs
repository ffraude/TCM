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
            if (Convert.ToInt16(Session["idUsuario"]) == null || Convert.ToInt16(Session["idUsuario"]) == 0)
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
    }
}