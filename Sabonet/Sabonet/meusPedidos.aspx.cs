using System;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class meusPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            int id = Convert.ToInt32(Session["idUsuario"]);
            ClsConexao conexao = new ClsConexao();
            Session["acesso"] = conexao.ConsultarAcesso(id);
            if (Session["acesso"] != null && Convert.ToBoolean(Session["acesso"]) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mostrarAdmin", "document.getElementById('linkAdmin').style.display = 'inline';", true);
            }

            if (!IsPostBack)
            {
                CarregarPedidos();
            }
        }

        private void CarregarPedidos()
        {
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);

            ClsConexao conexao = new ClsConexao();

            gvPedidos.DataSource = conexao.ConsultarPedidosUsuario(idUsuario);
            gvPedidos.DataBind();
        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalhes")
            {
                int idPedido = Convert.ToInt32(e.CommandArgument);

                lblPedidoSelecionado.Text = "Produtos do pedido nº " + idPedido;

                ClsConexao conexao = new ClsConexao();

                gvItensPedido.DataSource = conexao.ConsultarItensPedido(idPedido);
                gvItensPedido.DataBind();

                System.Data.DataTable endereco = conexao.ConsultarEnderecoPedido(idPedido);

                if (endereco.Rows.Count > 0)
                {
                    lblCEP.Text = "CEP: " + endereco.Rows[0]["cep"].ToString();
                    lblNumero.Text = "Número: " + endereco.Rows[0]["numero"].ToString();
                    lblComplemento.Text = "Complemento: " + endereco.Rows[0]["complemento"].ToString();
                    lblBairro.Text = "Bairro: " + endereco.Rows[0]["bairro"].ToString();
                    lblCidade.Text = "Cidade: " + endereco.Rows[0]["cidade"].ToString();
                    lblEstado.Text = "Estado: " + endereco.Rows[0]["estado"].ToString();
                }
            }
        }
    }
}