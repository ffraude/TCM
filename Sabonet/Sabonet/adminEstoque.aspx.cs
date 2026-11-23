using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class adminEstoque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            int idUsuario = Convert.ToInt32(Session["idUsuario"]);

            ClsConexao conexao = new ClsConexao();

            if (!conexao.ConsultarAcesso(idUsuario))
            {
                Response.Redirect("louja.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CarregarEstoque();
            }
        }

        private void CarregarEstoque()
        {
            ClsConexao conexao = new ClsConexao();

            DataTable tabela = new DataTable();

            conexao.Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT id_prod, nome_prod, estoque
                      FROM Produto
                      WHERE ativo_prod = 1
                      ORDER BY nome_prod",
                    conexao.GetConexao()))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabela);
                    }
                }
            }
            finally
            {
                conexao.Desconectar();
            }

            gvEstoque.DataSource = tabela;
            gvEstoque.DataBind();
        }

        protected void gvEstoque_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEstoque.EditIndex = e.NewEditIndex;
            CarregarEstoque();
        }

        protected void gvEstoque_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEstoque.EditIndex = -1;
            CarregarEstoque();
        }

        protected void gvEstoque_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idProduto = Convert.ToInt32(
                gvEstoque.DataKeys[e.RowIndex].Value);

            GridViewRow linha = gvEstoque.Rows[e.RowIndex];

            TextBox txtQuantidade = (TextBox)linha.FindControl("txtQuantidade");

            int quantidade;

            if (!int.TryParse(txtQuantidade.Text, out quantidade) || quantidade < 0)
            {
                lblMensagem.Text = "Informe uma quantidade válida.";
                return;
            }

            ClsConexao conexao = new ClsConexao();

            conexao.Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Produto
                      SET estoque = @estoque
                      WHERE id_prod = @id_prod
                      AND ativo_prod = 1",
                    conexao.GetConexao()))
                {
                    cmd.Parameters.Add("@estoque", SqlDbType.Int).Value = quantidade;
                    cmd.Parameters.Add("@id_prod", SqlDbType.Int).Value = idProduto;

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        lblMensagem.Text = "Estoque atualizado com sucesso!";
                    }
                    else
                    {
                        lblMensagem.Text = "Produto não encontrado ou inativo.";
                    }
                }
            }
            finally
            {
                conexao.Desconectar();
            }

            gvEstoque.EditIndex = -1;
            CarregarEstoque();
        }
    }
}