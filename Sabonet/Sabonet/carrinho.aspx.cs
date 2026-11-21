using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class carrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AtualizarCarrinho();
            }
        }

        private void AtualizarCarrinho()
        {
            ClsCarrinho carrinho = new ClsCarrinho();

            gvCarrinho.DataSource = carrinho.Itens;
            gvCarrinho.DataBind();

            decimal total = carrinho.Itens.Sum(item => item.Subtotal);

            lblTotal.Text = total.ToString("C2");
        }

        protected void gvCarrinho_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProduto = Convert.ToInt32(e.CommandArgument);

            ClsCarrinho carrinho = new ClsCarrinho();

            ClsItemCarrinho item = carrinho.Itens.Find(
                x => x.IdProduto == idProduto
            );

            if (item == null)
            {
                return;
            }

            if (e.CommandName == "Aumentar")
            {
                if (item.Quantidade < item.Estoque)
                {
                    item.Quantidade++;
                }
            }
            else if (e.CommandName == "Diminuir")
            {
                if (item.Quantidade > 1)
                {
                    item.Quantidade--;
                }
            }
            else if (e.CommandName == "Remover")
            {
                carrinho.Itens.Remove(item);
            }

            AtualizarCarrinho();
        }
    }
}