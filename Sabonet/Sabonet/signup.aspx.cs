using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void limparCampos()
        {
            TxtMail.Text = "";
            TxtSenha.Text = "";
            TxtUsu.Text = "";
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            LblAlerta.Text = "";
            ClsConexao conexao = new ClsConexao();
            if (TxtMail.Text != "" && TxtSenha.Text != "" && TxtUsu.Text != "")
            {
                conexao.Email = TxtMail.Text;
                conexao.Senha = TxtSenha.Text;
                conexao.Nome = TxtUsu.Text;
                LblAlerta.Text = conexao.ConferirEmail();
                if (LblAlerta.Text.Equals(""))
                {
                    conexao.Gravar();
                }
            }
            else
            {
                LblAlerta.Text = "Preencha os campos corretamente.";
            }
            limparCampos();
            
        }
    }
}