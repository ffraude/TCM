using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ClsConexao;

namespace sabao.net
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["isAdmin"] = false;
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            LblAviso.Text = "";
            if (TxtMail.Text.Equals("") || TxtSenha.Text.Equals(""))
            { 
                LblAviso.Text = "Preencha todos os campos.";
            }
            else
            {
                Conexao banco = new Conexao();

                try
                {
                    banco.Conectar();

                    // Query aqui

                }
                catch (Exception ex)
                {
                    // Erro 0 resenha
                }
                finally
                {
                    banco.Desconectar();
                }
            }

            TxtMail.Text = "";
            TxtSenha.Text = "";
        }
    }
}