using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


public class ClsConexao
{
    public class Conexao
    {

        //String de conexão GENÉRICA, lembra de mudar quando você abrir o banco na escola!!!!
        private string strConexao =
            @"Data Source=.\SQLEXPRESS;
              Initial Catalog=SeuBanco;
              Integrated Security=True;";

        private SqlConnection conexao;

        public Conexao()
        {
            conexao = new SqlConnection(strConexao);
        }

        public void Conectar()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
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
    }
}
