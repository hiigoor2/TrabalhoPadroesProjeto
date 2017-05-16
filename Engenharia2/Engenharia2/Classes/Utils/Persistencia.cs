using System.Data;
using System.Data.SqlClient;

namespace Engenharia2.Classes.Utils
{
    class Persistencia
    {
        private SqlConnection _conexao;
        private SqlCommand _comando;

        public Persistencia()
        {
            string sStringConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonardo\Downloads\Engenharia2\Engenharia2\Banco.mdf;Integrated Security=True";

            _conexao = new SqlConnection(sStringConexao);
            _comando = new SqlCommand();
            _comando.Connection = _conexao;
        }

        public bool ConectaBanco()
        {
            try
            {
                _conexao.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DesconectaBanco()
        {
            try
            {
                _conexao.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataTable RetornaDT(string sSQL)
        {
            DataTable dtDados = new DataTable();
            if (_conexao.State == ConnectionState.Open)
                DesconectaBanco();
            if (ConectaBanco())
            {
                _comando.CommandText = sSQL;
                dtDados.Load(_comando.ExecuteReader());
                DesconectaBanco();
            }
            return dtDados;
        }

        public DataSet RetornaDS(string sSQL)
        {
            DataSet dsDados = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            if (_conexao.State == ConnectionState.Open)
                DesconectaBanco();
            if (ConectaBanco())
            {
                _comando.CommandText = sSQL;
                dataAdapter.SelectCommand = _comando;
                dataAdapter.Fill(dsDados);
                DesconectaBanco();
            }

            return dsDados;
        }

        public SqlDataReader RetornaDR(string sSQL)
        {
            if (_conexao.State == ConnectionState.Closed)
            {
                _conexao.Open();
            }
            _comando.CommandText = sSQL;
            SqlDataReader drDados = _comando.ExecuteReader();
            return drDados;
        }

        public int ExecutaSQL(string sSQL)
        {
            int iLinhas = 0;
            if (_conexao.State == ConnectionState.Open)
                DesconectaBanco();
            if (ConectaBanco())
            {
                _comando.CommandText = sSQL;
                iLinhas = _comando.ExecuteNonQuery();
                DesconectaBanco();
            }
            return iLinhas;
        }
    }
}