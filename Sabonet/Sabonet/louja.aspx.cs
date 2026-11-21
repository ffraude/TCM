using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class louja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsConexao conexao = new ClsConexao();
            if (Session["idUsuario"] != null || Convert.ToInt16(Session["idUsuario"]) != 0)
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

        protected void AdicionarCarrinho_Command(object sender, CommandEventArgs e)
        {
            int idProduto = Convert.ToInt32(e.CommandArgument);

            Label lblQuantidade = (Label)LocalizarControle(form1, "lblQuantidade" + idProduto);

            int quantidade = Convert.ToInt32(lblQuantidade.Text);

            ClsConexao conexao = new ClsConexao();

            ClsItemCarrinho item = conexao.ConsultarProduto(idProduto);

            if (item == null)
            {
                return;
            }

            item.Quantidade = quantidade;

            ClsCarrinho carrinho = new ClsCarrinho();

            ClsItemCarrinho existente = carrinho.Itens.Find(
                x => x.IdProduto == idProduto
            );

            int quantidadeTotal = quantidade;

            if (existente != null)
            {
                quantidadeTotal += existente.Quantidade;
            }

            if (quantidadeTotal > item.Estoque)
            {
                return;
            }

            carrinho.Adicionar(item);
        }

        private Control LocalizarControle(Control controle, string id)
        {
            if (controle.ID == id)
            {
                return controle;
            }

            foreach (Control filho in controle.Controls)
            {
                Control encontrado = LocalizarControle(filho, id);

                if (encontrado != null)
                {
                    return encontrado;
                }
            }

            return null;
        }

        protected void AlterarQuantidade_Command(object sender, CommandEventArgs e)
        {
            int idProduto = Convert.ToInt32(e.CommandArgument);

            Label lblQuantidade = (Label)LocalizarControle(form1, "lblQuantidade" + idProduto);

            int quantidade = Convert.ToInt32(lblQuantidade.Text);

            if (e.CommandName == "Mais")
            {
                quantidade++;
            }
            else if (e.CommandName == "Menos")
            {
                if (quantidade > 1)
                {
                    quantidade--;
                }
            }

            lblQuantidade.Text = quantidade.ToString();
        }

        protected void btnMais2_Click(object sender, EventArgs e)
        {

        }
    }
}