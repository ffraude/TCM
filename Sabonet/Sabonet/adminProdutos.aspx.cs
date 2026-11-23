using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Sabonet
{
    public partial class adminProdutos : System.Web.UI.Page
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
                CarregarProdutos();
            }
        }

        private void CarregarProdutos()
        {
            ClsConexao conexao = new ClsConexao();

            gvProdutos.DataSource = conexao.ConsultarProdutos();
            gvProdutos.DataBind();
        }

        protected void gvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProduto = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Alterar")
            {
                Response.Redirect("adminAlterarProduto.aspx?id=" + idProduto, false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (e.CommandName == "Excluir")
            {
                ClsConexao conexao = new ClsConexao();

                conexao.Conectar();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Produto SET ativo_prod = 0 WHERE id_prod = @id_prod",
                        conexao.GetConexao()))
                    {
                        cmd.Parameters.Add("@id_prod", SqlDbType.Int).Value = idProduto;
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    conexao.Desconectar();
                }

                CarregarProdutos();
            }
        }
    }
}