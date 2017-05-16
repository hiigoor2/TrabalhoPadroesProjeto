using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsFornecedor : Persistencia
    {
        int codigo;
        string nome;
        string nomefantasia;
        string endereco;
        string telefone;
        string cnpj;

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int cod)
        {
            codigo = cod;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string valor)
        {
            nome = valor;
        }

        public string getNomeFantasia()
        {
            return nomefantasia;
        }

        public void setNomeFantasia(string valor)
        {
            nomefantasia = valor;
        }


        public string getEndereco()
        {
            return endereco;
        }

        public void setEndereco(string valor)
        {
            endereco = valor;
        }

        public string getTelefone()
        {
            return telefone;
        }

        public void setTelefone(string valor)
        {
            telefone = valor;
        }

        public string getCnpj()
        {
            return cnpj;
        }

        public void setCnpj(string valor)
        {
            cnpj = valor;
        }

        public clsFornecedor()
        {
            codigo = 0;
            nome = "";
            nomefantasia = "";
            endereco = "";
            telefone = "";
            cnpj = "";
        }

        public clsFornecedor(int cod, string nom, string nomfant,string end, string tel, string cnpj)
        {
            codigo = cod;
            nome = nom;
            nomefantasia = nomfant;
            endereco = end;
            telefone = tel;
            this.cnpj = cnpj;
        }

        public bool Inserir()
        {
            string sql = "INSERT INTO FORNECEDOR (FOR_NOME, FOR_NOMEFANTASIA, FOR_CNPJ, FOR_TELEFONE, FOR_ENDERECO) VALUES ('" + nome + "', '" + nomefantasia + "', '" + cnpj + "', '" + telefone + "', '" + endereco + "')";
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Alterar()
        {
            string sql = "UPDATE FORNECEDOR SET FOR_NOME = '" + nome + "', FOR_ENDERECO = '" + endereco + "', FOR_TELEFONE = '" + telefone + "', FOR_CNPJ = '" + cnpj + "', FOR_NOMEFANTASIA = '" + nomefantasia + "' WHERE FOR_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Excluir()
        {
            string sql = "DELETE FROM FORNECEDOR WHERE FOR_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool RecuperaDados()
        {
            bool aux = false;
            string sql = "SELECT * FROM FORNECEDOR WHERE FOR_CODIGO = " + codigo;
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                nome = dt.Rows[0]["FOR_NOME"].ToString();
                nomefantasia = dt.Rows[0]["FOR_NOMEFANTASIA"].ToString();
                cnpj = dt.Rows[0]["FOR_CNPJ"].ToString();
                telefone = dt.Rows[0]["FOR_TELEFONE"].ToString();
                endereco = dt.Rows[0]["FOR_ENDERECO"].ToString();
            }
            return aux;
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            string sql = "SELECT * FROM FORNECEDOR";
            if (Parametro == "Código")
            {
                if (Criterio == "")
                    Criterio = "0";
                sql = sql + " WHERE FOR_CODIGO = " + Criterio;
            }
            else
            {
                if (Parametro == "Nome")
                {
                    sql = sql + " WHERE FOR_NOME LIKE '%" + Criterio + "%'";
                }
                else
                {
                    sql = sql + " WHERE FOR_NOMEFANTASIA LIKE '%" + Criterio + "%'";
                }
            }
            return RetornaDT(sql);
        }

        public DataTable PopulaGrid()
        {
            return RetornaDT("SELECT * FROM FORNECEDOR");
        }
    }
}