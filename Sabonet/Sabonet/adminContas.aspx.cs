using System;
using System.Data;
using System.Data.SqlClient;

namespace Sabonet
{
    public partial class adminContas : System.Web.UI.Page
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
                Response.Redirect("pagina-inicial.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CarregarUsuarios("");
            }
        }

        private void CarregarUsuarios(string pesquisa)
        {
            ClsConexao conexao = new ClsConexao();

            try
            {
                conexao.Conectar();

                string sql = @"
                    SELECT id_usu, nome_usu, email_usu, acesso_usu
                    FROM Usuario
                    WHERE nome_usu LIKE @pesquisa
                    OR email_usu LIKE @pesquisa
                    ORDER BY nome_usu";

                using (SqlCommand comando = new SqlCommand(sql, conexao.GetConexao()))
                {
                    comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value =
                        "%" + pesquisa + "%";

                    DataTable tabela = new DataTable();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabela);
                    }

                    gvUsuarios.DataSource = tabela;
                    gvUsuarios.DataBind();
                }
            }
            catch (Exception)
            {
                lblMensagem.Text = "Não foi possível carregar as contas.";
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = "";
            CarregarUsuarios(txtPesquisa.Text.Trim());
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            lblMensagem.Text = "";
            CarregarUsuarios("");
        }
    }
}