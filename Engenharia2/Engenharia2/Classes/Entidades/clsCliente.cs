using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsCliente : Persistencia
    {
        private Int32 _codigo;
        private String _nome;
        private String _telefone1;
        private String _telefone2;
        private String _cep;
        //private String _cidade;
        //private String _estado;
        private String _cpf;
        private String _rua;
        private String _bairro;
        private Int32 _numero;

        //construtor
        public clsCliente()
        {

        }

        //gets e sets
        public void setCodigo(int cod)
        {
            _codigo = cod;
        }

        public int getCodigo()
        {
            return _codigo;
        }

        public String getNome()
        {
            return _nome;
        }
        public void setNome(string nome)
        {
            _nome = nome;
        }
        public String getRua()
        {
            return _rua;
        }
        public void setRua(string rua)
        {
            _rua = rua;
        }
        public String getBairro()
        {
            return _bairro;
        }
        public void setBairro(string bairro)
        {
            _bairro = bairro;
        }
        public String getTel1()
        {
            return _telefone1;
        }
        public void setTel1(string tel1)
        {
            _telefone1 = tel1;
        }
        public String getTel2()
        {
            return _telefone2;
        }
        public void setTel2(string tel2)
        {
            _telefone2 = tel2;
        }
        public String getCep()
        {
            return _cep;
        }
        public void setCep(string cep)
        {
            _cep = cep;
        }
        public String getCpf()
        {
            return _cpf;
        }
        public void setCpf(string cpf)
        {
            _cpf = cpf;
        }
        public int getNumero()
        {
            return _numero;
        }
        public void setNumero(int numero)
        {
            _numero = numero;
        }

        //operações
        public int Select()
        {
            String sSql = "SELECT * FROM CLIENTE";
            DataTable dt = RetornaDT(sSql);
            if (dt.Rows.Count > 0)
            {
                _codigo = Convert.ToInt32(dt.Rows[0]["CLI_CODIGO"].ToString());
                _nome = dt.Rows[0]["CLI_NOME"].ToString();
                _cpf = dt.Rows[0]["CLI_CPF"].ToString();
                _cep = dt.Rows[0]["CLI_CEP"].ToString();
                _rua = dt.Rows[0]["CLI_RUA"].ToString();
                _numero = Convert.ToInt32(dt.Rows[0]["CLI_NUMERO"].ToString());
                _bairro = dt.Rows[0]["CLI_BAIRRO"].ToString();
                _telefone1 = dt.Rows[0]["CLI_TELEFONE1"].ToString();
                _telefone2 = dt.Rows[0]["CLI_TELEFONE2"].ToString();
                
                return 1;
            }
            else
                return 0;
        }

        //update
        public int Update()
        {
            String sSql = "UPDATE CLIENTE SET " +//ADICIONAR ATRIBUTOS
                " CLI_NOME = '" + _nome + "'," +
                " CLI_CPF = '" + _cpf + "'," +
                " CLI_CEP = '" + _cep + "'," +
                " CLI_TELEFONE1 = '" + _telefone2 + "'," +
                " CLI_TELEFONE2 = '" + _telefone2 + "'," +
                " CLI_RUA = '" + _rua + "'," +
                " CLI_BAIRRO = '" + _bairro + "'," +
                " CLI_NUMERO = " + _numero + "," +
                " WHERE CLI_CODIGO = " + _codigo;

            int linhas = ExecutaSQL(sSql);
            return linhas;
        }

        public int retornaCodigo()
        {
            string sSql = "SELECT * FROM CLIENTE ORDER BY CLI_CODIGO DESC";
            DataTable dt = RetornaDT(sSql);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["CLI_CODIGO"]);
            else
                return -1;
        }

        //insert
        public int Insert()
        {
            String sSql = "INSERT INTO CLIENTE(CLI_NOME,CLI_NUMERO,CLI_CPF,CLI_CEP,CLI_RUA,CLI_BAIRRO,CLI_TELEFONE1,CLI_TELEFONE2)" +
                " VALUES('" + _nome + "', " + _numero + ", '" + _cpf + "', '" + _cep + "', '" + _rua + "', '" + _bairro + "', '" + _telefone1 + "', '" + _telefone1 + "')";
            int linhas = ExecutaSQL(sSql);
            if (linhas > 0)
            {
                _codigo = retornaCodigo();
            }
            return linhas;
        }
        public int Delete()
        {
            int linhas = 0;
            if (_codigo != 0)
            {
                String sSql = "DELETE FROM CLIENTE WHERE CLI_CODIGO = " + _codigo;
                linhas = ExecutaSQL(sSql);
            }
            return linhas;
        }
        public DataTable Listar()
        {
            String sSql = "SELECT * FROM CLIENTE";
            if(_nome != null && _nome.Length>0)
                sSql+= " WHERE CLI_NOME LIKE '%"+_nome+"%'";
            return RetornaDT(sSql);
        }

        public DataTable Listar(string p)
        {
            String sSql = "SELECT * FROM CLIENTE WHERE CLI_NOME LIKE '%" + p + "%'";
            return RetornaDT(sSql);
        }
    }
}
