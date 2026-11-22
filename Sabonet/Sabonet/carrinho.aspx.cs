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
            if (Session["idUsuario"] != null)
            {
                int id = Convert.ToInt32(Session["idUsuario"]);
                ClsConexao conexao = new ClsConexao();
                Session["acesso"] = conexao.ConsultarAcesso(id);
                if (Session["acesso"] != null && Convert.ToBoolean(Session["acesso"]) == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mostrarAdmin", "document.getElementById('linkAdmin').style.display = 'inline';", true);
                }
            }

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

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            ClsCarrinho carrinho = new ClsCarrinho();

            if (carrinho.Itens.Count == 0)
            {
                lblEnderecoAlerta.Text = "Seu carrinho está vazio.";
                return;
            }

            int numero;

            if (string.IsNullOrWhiteSpace(txtCEP.Text) ||
                string.IsNullOrWhiteSpace(txtBairro.Text) ||
                string.IsNullOrWhiteSpace(txtCidade.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text) ||
                !int.TryParse(txtNumero.Text, out numero) ||
                numero <= 0)
            {
                lblEnderecoAlerta.Text = "Preencha os dados do endereço corretamente.";
                return;
            }

            try
            {
                int idUsuario = Convert.ToInt32(Session["idUsuario"]);

                ClsConexao conexao = new ClsConexao();

                int idEndereco = conexao.GravarEndereco(
                    txtCEP.Text,
                    numero,
                    txtComplemento.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    txtEstado.Text
                );

                conexao.AssociarEnderecoUsuario(idUsuario, idEndereco);

                int idPedido = conexao.FinalizarCompra(
                    idEndereco,
                    idUsuario,
                    carrinho.Itens
                );

                Session["Carrinho"] = null;
                Session["idEnderecoCompra"] = null;

                lblEnderecoAlerta.Text = "Compra realizada com sucesso! Pedido: " + idPedido;

                AtualizarCarrinho();
            }
            catch (Exception ex)
            {
                lblEnderecoAlerta.Text = "Erro ao finalizar a compra: " + ex.Message;
            }
        }
    }
}