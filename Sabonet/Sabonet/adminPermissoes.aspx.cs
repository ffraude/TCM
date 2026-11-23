using System;
using System.Data;
using System.Data.SqlClient;

namespace Sabonet
{
    public partial class adminPermissoes : System.Web.UI.Page
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
                CarregarUsuarios();
            }
        }

        private void CarregarUsuarios()
        {
            ClsConexao conexao = new ClsConexao();

            try
            {
                conexao.Conectar();

                string sql = @"
                    SELECT id_usu, nome_usu, email_usu, acesso_usu
                    FROM Usuario
                    ORDER BY nome_usu";

                using (SqlCommand comando = new SqlCommand(sql, conexao.GetConexao()))
                {
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
                lblMensagem.Text = "Não foi possível carregar os usuários.";
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AlterarPermissao")
            {
                int idAlvo = Convert.ToInt32(e.CommandArgument);
                int idAtual = Convert.ToInt32(Session["idUsuario"]);

                if (idAlvo == idAtual)
                {
                    lblMensagem.Text = "Você não pode alterar sua própria permissão.";
                    return;
                }

                ClsConexao conexao = new ClsConexao();

                try
                {
                    conexao.Conectar();

                    string sql = @"
                        UPDATE Usuario
                        SET acesso_usu =
                            CASE
                                WHEN acesso_usu = 1 THEN 0
                                ELSE 1
                            END
                        WHERE id_usu = @idUsuario";

                    using (SqlCommand comando = new SqlCommand(sql, conexao.GetConexao()))
                    {
                        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idAlvo;

                        int resultado = comando.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            lblMensagem.Text = "Permissão alterada com sucesso!";
                        }
                        else
                        {
                            lblMensagem.Text = "Usuário não encontrado.";
                        }
                    }
                }
                catch (Exception)
                {
                    lblMensagem.Text = "Não foi possível alterar a permissão.";
                }
                finally
                {
                    conexao.Desconectar();
                }

                CarregarUsuarios();
            }
        }
    }
}