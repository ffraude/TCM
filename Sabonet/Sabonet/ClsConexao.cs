using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sabonet
{
    public class ClsConexao
    {
        //String de conexão GENÉRICA, lembra de mudar quando você abrir o banco na escola!!!!
        //String de conexão do notebook do Máximo: DESKBOTTOM\SQLEXPRESS
        private string strConexao =
            @"Data Source=DESKBOTTOM\SQLEXPRESS;
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
    }
}