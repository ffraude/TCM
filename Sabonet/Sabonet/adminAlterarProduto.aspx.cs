using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Sabonet
{
    public partial class adminAlterarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            ClsConexao conexao = new ClsConexao();

            int idUsuario = Convert.ToInt32(Session["idUsuario"]);

            if (!conexao.ConsultarAcesso(idUsuario))
            {
                Response.Redirect("louja.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CarregarCategorias();
                CarregarProduto();
            }
        }

        private void CarregarCategorias()
        {
            ClsConexao conexao = new ClsConexao();

            ddlCategoria.DataSource = conexao.ConsultarCategorias();
            ddlCategoria.DataTextField = "nome_cat";
            ddlCategoria.DataValueField = "id_cat";
            ddlCategoria.DataBind();
        }

        private void CarregarProduto()
        {
            int idProduto;

            if (!int.TryParse(Request.QueryString["id"], out idProduto))
            {
                lblMensagem.Text = "Produto não encontrado.";
                btnSalvar.Enabled = false;
                return;
            }

            ClsConexao conexao = new ClsConexao();

            conexao.Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT nome_prod, preco, estoque, descricao_prod,
                             id_cat, ativo_prod
                      FROM Produto
                      WHERE id_prod = @id_prod",
                    conexao.GetConexao()))
                {
                    cmd.Parameters.Add("@id_prod", SqlDbType.Int).Value = idProduto;

                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            txtNome.Text = leitor["nome_prod"].ToString();
                            txtPreco.Text = Convert.ToDecimal(leitor["preco"]).ToString("N2");
                            txtEstoque.Text = leitor["estoque"].ToString();
                            txtDescricao.Text = leitor["descricao_prod"].ToString();

                            ddlCategoria.SelectedValue = leitor["id_cat"].ToString();

                            chkAtivo.Checked = Convert.ToBoolean(leitor["ativo_prod"]);
                        }
                        else
                        {
                            lblMensagem.Text = "Produto não encontrado.";
                            btnSalvar.Enabled = false;
                        }
                    }
                }
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int idProduto;
            decimal preco;
            int estoque;

            if (!int.TryParse(Request.QueryString["id"], out idProduto))
            {
                lblMensagem.Text = "Produto não encontrado.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                !decimal.TryParse(txtPreco.Text, NumberStyles.Number,
                    new CultureInfo("pt-BR"), out preco) ||
                !int.TryParse(txtEstoque.Text, out estoque))
            {
                lblMensagem.Text = "Preencha corretamente todos os campos.";
                return;
            }

            if (preco < 0 || estoque < 0 || txtNome.Text.Length > 100 ||
                txtDescricao.Text.Length > 100)
            {
                lblMensagem.Text = "Verifique os valores e o tamanho dos campos.";
                return;
            }

            ClsConexao conexao = new ClsConexao();

            conexao.Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Produto
              SET nome_prod = @nome,
                  preco = @preco,
                  estoque = @estoque,
                  descricao_prod = @descricao,
                  id_cat = @categoria,
                  ativo_prod = @ativo
              WHERE id_prod = @id",
                    conexao.GetConexao()))
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar, 100).Value = txtNome.Text.Trim();

                    SqlParameter parametroPreco = cmd.Parameters.Add("@preco", SqlDbType.Decimal);
                    parametroPreco.Precision = 10;
                    parametroPreco.Scale = 2;
                    parametroPreco.Value = preco;

                    cmd.Parameters.Add("@estoque", SqlDbType.Int).Value = estoque;
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar, 100).Value = txtDescricao.Text.Trim();
                    cmd.Parameters.Add("@categoria", SqlDbType.Int).Value = Convert.ToInt32(ddlCategoria.SelectedValue);
                    cmd.Parameters.Add("@ativo", SqlDbType.Bit).Value = chkAtivo.Checked;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idProduto;

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        Response.Redirect("adminProdutos.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                        return;
                    }

                    lblMensagem.Text = "Não foi possível localizar o produto.";
                }
            }
            catch (Exception)
            {
                lblMensagem.Text = "Ocorreu um erro ao salvar as alterações.";
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}