using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Sabonet
{
    public class ClsConexao
    {
        //String de conexão GENÉRICA, lembra de mudar quando você abrir o banco na escola!!!!
        //String de conexão do notebook do Máximo: DESKBOTTOM\SQLEXPRESS
        private string strConexao =
            @"Data Source=JJe;
              Initial Catalog=DBresenhexxxx;
              Integrated Security=True;";

        private string email;
        private string senha;
        private string nome;

        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Nome { get => nome; set => nome = value; }

        private SqlConnection conexao;
        private SqlCommand comando = new SqlCommand();

        public ClsConexao()
        {
            conexao = new SqlConnection(strConexao);

        }

        public void Conectar()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }
            else
            {
                conexao.Close();
                conexao.Open();
            }
        }

        public void Desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public SqlConnection GetConexao()
        {
            return conexao;
        }

        public string ConferirEmail()
        {
            Conectar();
            comando.Connection = conexao;
            comando.Parameters.Clear();
            comando.Parameters.Add("@varEmail", SqlDbType.VarChar).Value = Email;
            comando.CommandText = @"SELECT email_usu FROM Usuario WHERE email_usu = @varEmail";
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                return "E-mail já cadastrado.";
            }

            return "";
            Desconectar();

        }

        public void Gravar()
        {
            Conectar();
            comando.Connection = conexao;
            comando.Parameters.Clear();
            comando.Parameters.Add("@varNome", SqlDbType.VarChar).Value = Nome;
            comando.Parameters.Add("@varSenha", SqlDbType.VarChar).Value = Senha;
            comando.Parameters.Add("@varEmail", SqlDbType.VarChar).Value = Email;

            comando.CommandText = @"INSERT INTO Usuario(nome_usu, senha_usu, email_usu, acesso_usu) VALUES (@varNome, @varSenha, @varEmail, 0)";

            comando.Connection = conexao;

            comando.ExecuteNonQuery();

            Desconectar();
        }
        //Dá erro por algum motivo
        public string getNomeUsuario(int id)
        {
            string retorno = "";
            Conectar();
            comando.Connection = conexao;
            comando.Parameters.Clear();
            comando.Parameters.Add("@varId", SqlDbType.Int).Value = id;
            comando.CommandText = @"SELECT nome_usu FROM Usuario WHERE id_usu = @varId";
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                retorno = dr["nome_usu"].ToString();
            }
            Desconectar();
            return retorno;
        }

        public string getEmailUsuario(int id)
        {
            string retorno = "";
            Conectar();
            comando.Connection = conexao;
            comando.Parameters.Clear();
            comando.Parameters.Add("@varId", SqlDbType.Int).Value = id;
            comando.CommandText = @"SELECT email_usu FROM Usuario WHERE id_usu = @varId";
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                retorno = dr["email_usu"].ToString();
            }
            Desconectar();
            return retorno;
        }

        public int Entrar()
        {
            int retorno = 0;
            Conectar();
            comando.Connection = conexao;
            comando.Parameters.Clear();
            comando.Parameters.Add("@varEmail", SqlDbType.VarChar).Value = Email;
            comando.Parameters.Add("@varSenha", SqlDbType.VarChar).Value = Senha;
            comando.CommandText = @"SELECT id_usu FROM Usuario WHERE email_usu = @varEmail AND senha_usu = @varSenha";
            comando.Connection = conexao;
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                retorno = Convert.ToInt32(dr["id_usu"]);
            }
            else
            {
                retorno = 0;
            }
            Desconectar();
            return retorno;
        }

        public void Excluir(int id)
        {
            Conectar();
            comando.Connection = conexao;
            comando.Parameters.Clear();
            comando.Parameters.Add("@varId", SqlDbType.Int).Value = id;
            comando.CommandText = @"DELETE FROM Usuario WHERE id_usu = @varId";
            comando.Connection = conexao;
            comando.ExecuteNonQuery();
            Desconectar();
        }
        public ClsItemCarrinho ConsultarProduto(int idProduto)
        {
            ClsItemCarrinho item = null;

            Conectar();

            try
            {
                using (SqlCommand comandoProduto = new SqlCommand("spConsultarProduto", conexao))
                {
                    comandoProduto.CommandType = CommandType.StoredProcedure;

                    comandoProduto.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;

                    SqlDataReader dr = comandoProduto.ExecuteReader();

                    if (dr.Read())
                    {
                        item = new ClsItemCarrinho();

                        item.IdProduto = Convert.ToInt32(dr["id_prod"]);
                        item.NomeProduto = dr["nome_prod"].ToString();
                        item.Preco = Convert.ToDecimal(dr["preco"]);
                        item.Estoque = Convert.ToInt32(dr["estoque"]);
                    }

                    dr.Close();
                }
            }
            finally
            {
                Desconectar();
            }

            return item;
        }

        public int GravarEndereco(string cep, int numero, string complemento,
    string bairro, string cidade, string estado)
        {
            int idEndereco;

            Conectar();

            try
            {
                object valorComplemento = string.IsNullOrWhiteSpace(complemento)
                    ? (object)DBNull.Value
                    : complemento;

                using (SqlCommand cmd = new SqlCommand(@"
            SELECT id_end
            FROM Endereco
            WHERE cep = @cep
            AND numero = @numero
            AND ((complemento = @complemento)
                 OR (complemento IS NULL AND @complemento IS NULL))
            AND bairro = @bairro
            AND cidade = @cidade
            AND estado = @estado", conexao))
                {
                    cmd.Parameters.AddWithValue("@cep", cep);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@complemento", valorComplemento);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        idEndereco = Convert.ToInt32(resultado);
                        return idEndereco;
                    }
                }

                using (SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Endereco
            (cep, numero, complemento, bairro, cidade, estado)
            OUTPUT INSERTED.id_end
            VALUES
            (@cep, @numero, @complemento, @bairro, @cidade, @estado)",
                    conexao))
                {
                    cmd.Parameters.AddWithValue("@cep", cep);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@complemento", valorComplemento);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    idEndereco = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                Desconectar();
            }

            return idEndereco;
        }

        public void AssociarEnderecoUsuario(int idUsuario, int idEndereco)
        {
            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
            UPDATE Usuario
            SET usu_id_end = @idEndereco
            WHERE id_usu = @idUsuario", conexao))
                {
                    cmd.Parameters.AddWithValue("@idEndereco", idEndereco);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                Desconectar();
            }
        }

        public int GravarPedido(int idEndereco, int idUsuario, int quantidadeTotal)
        {
            int idPedido;

            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Pedido
            (id_end, id_usu, quant, data_ped, status_ped)
            OUTPUT INSERTED.id_pedido
            VALUES
            (@idEndereco, @idUsuario, @quantidade, @data, @status)",
                    conexao))
                {
                    cmd.Parameters.AddWithValue("@idEndereco", idEndereco);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@quantidade", quantidadeTotal);
                    cmd.Parameters.AddWithValue("@data", DateTime.Today);
                    cmd.Parameters.AddWithValue("@status", "Pendente");

                    idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                Desconectar();
            }

            return idPedido;
        }

        public void GravarItemPedido(int idProduto, int idPedido, int quantidade, decimal preco)
        {
            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
            INSERT INTO ItemPedido
            (id_prod, id_pedido, quant, preco_unitario)
            VALUES
            (@idProduto, @idPedido, @quantidade, @preco)", conexao))
                {
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@preco", preco);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                Desconectar();
            }
        }

        public bool AtualizarEstoque(int idProduto, int quantidade)
        {
            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
            UPDATE Produto
            SET estoque = estoque - @quantidade
            WHERE id_prod = @idProduto
            AND estoque >= @quantidade", conexao))
                {
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                Desconectar();
            }
        }

        public int FinalizarCompra(int idEndereco, int idUsuario, List<ClsItemCarrinho> itens)
        {
            int idPedido;

            Conectar();

            SqlTransaction transacao = conexao.BeginTransaction();

            try
            {
                int quantidadeTotal = itens.Sum(item => item.Quantidade);

                using (SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Pedido
            (id_end, id_usu, quant, data_ped, status_ped)
            OUTPUT INSERTED.id_pedido
            VALUES
            (@idEndereco, @idUsuario, @quantidade, @data, @status)",
                    conexao, transacao))
                {
                    cmd.Parameters.AddWithValue("@idEndereco", idEndereco);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@quantidade", quantidadeTotal);
                    cmd.Parameters.AddWithValue("@data", DateTime.Today);
                    cmd.Parameters.AddWithValue("@status", "Pendente");

                    idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (ClsItemCarrinho item in itens)
                {
                    using (SqlCommand cmdEstoque = new SqlCommand(@"
                UPDATE Produto
                SET estoque = estoque - @quantidade
                WHERE id_prod = @idProduto
                AND estoque >= @quantidade",
                        conexao, transacao))
                    {
                        cmdEstoque.Parameters.AddWithValue("@idProduto", item.IdProduto);
                        cmdEstoque.Parameters.AddWithValue("@quantidade", item.Quantidade);

                        if (cmdEstoque.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("Estoque insuficiente para: " + item.NomeProduto);
                        }
                    }

                    using (SqlCommand cmdItem = new SqlCommand(@"
                INSERT INTO ItemPedido
                (id_prod, id_pedido, quant, preco_unitario)
                VALUES
                (@idProduto, @idPedido, @quantidade, @preco)",
                        conexao, transacao))
                    {
                        cmdItem.Parameters.AddWithValue("@idProduto", item.IdProduto);
                        cmdItem.Parameters.AddWithValue("@idPedido", idPedido);
                        cmdItem.Parameters.AddWithValue("@quantidade", item.Quantidade);
                        cmdItem.Parameters.AddWithValue("@preco", item.Preco);

                        cmdItem.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                Desconectar();
            }

            return idPedido;
        }

        public DataTable ConsultarPedidosUsuario(int idUsuario)
        {
            DataTable tabela = new DataTable();

            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spConsultarPedidosUsuario", conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabela);
                    }
                }
            }
            finally
            {
                Desconectar();
            }

            return tabela;
        }

        public DataTable ConsultarItensPedido(int idPedido)
        {
            DataTable tabela = new DataTable();

            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spConsultarItensPedido", conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idPedido", idPedido);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabela);
                    }
                }
            }
            finally
            {
                Desconectar();
            }

            return tabela;
        }

        public DataTable ConsultarEnderecoPedido(int idPedido)
        {
            DataTable tabela = new DataTable();

            Conectar();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spConsultarEnderecoPedido", conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idPedido", idPedido);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabela);
                    }
                }
            }
            finally
            {
                Desconectar();
            }

            return tabela;
        }

        public Boolean AlterarNome(int id, string senhaAtual, string novoNome)
        {
            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "AterarNomexxxx";

            comando.Parameters.Clear();

            comando.Parameters.Add("@id_usu", SqlDbType.Int).Value = id;
            comando.Parameters.Add("@senha_atual", SqlDbType.VarChar, 50).Value = senhaAtual;
            comando.Parameters.Add("@novo_nome", SqlDbType.VarChar, 50).Value = novoNome;

            SqlParameter retorno = new SqlParameter();
            retorno.ParameterName = "@RETURN_VALUE";
            retorno.SqlDbType = SqlDbType.Int;
            retorno.Direction = ParameterDirection.ReturnValue;

            comando.Parameters.Add(retorno);

            try
            {
                conexao.Open();

                comando.ExecuteNonQuery();

                return Convert.ToInt32(retorno.Value) == 1;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }
        }
        public Boolean AlterarEmail(int id, string senhaAtual, string novoEmail)
        {
            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "AlterarEmailexxxx";

            comando.Parameters.Clear();

            comando.Parameters.Add("@id_usu", SqlDbType.Int).Value = id;
            comando.Parameters.Add("@senha_atual", SqlDbType.VarChar, 50).Value = senhaAtual;
            comando.Parameters.Add("@novo_email", SqlDbType.VarChar, 40).Value = novoEmail;

            SqlParameter retorno = new SqlParameter();
            retorno.ParameterName = "@RETURN_VALUE";
            retorno.SqlDbType = SqlDbType.Int;
            retorno.Direction = ParameterDirection.ReturnValue;

            comando.Parameters.Add(retorno);

            try
            {
                conexao.Open();

                comando.ExecuteNonQuery();

                return Convert.ToInt32(retorno.Value) == 1;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }
        }

        public Boolean AlterarSenha(int id, string senhaAtual, string novoEmail)
        {
            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "AlterarSenhexxxx";

            comando.Parameters.Clear();

            comando.Parameters.Add("@id_usu", SqlDbType.Int).Value = id;
            comando.Parameters.Add("@senha_atual", SqlDbType.VarChar, 50).Value = senhaAtual;
            comando.Parameters.Add("@novo_email", SqlDbType.VarChar, 50).Value = novoEmail;

            SqlParameter retorno = new SqlParameter();
            retorno.ParameterName = "@RETURN_VALUE";
            retorno.SqlDbType = SqlDbType.Int;
            retorno.Direction = ParameterDirection.ReturnValue;

            comando.Parameters.Add(retorno);

            try
            {
                conexao.Open();

                comando.ExecuteNonQuery();

                return Convert.ToInt32(retorno.Value) == 1;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }
        }
    }
}