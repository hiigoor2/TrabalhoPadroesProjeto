using Engenharia2.Classes.Utils;
using System;
using System.Data;

namespace Engenharia2.Classes.Entidades
{
    class clsUsuario: Persistencia
    {
        int codigo;
        string login;
        string senha;
        string nome;
        string endereco;
        int nivel;
        string telefone;
        string cpf;
        string pergunta;
        string resposta;

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int cod)
        {
            codigo = cod;
        }

        public string getLogin()
        {
            return login;
        }

        public void setLogin(string valor)
        {
            login = valor;
        }

        public string getSenha()
        {
            return senha;
        }

        public void setSenha(string valor)
        {
            senha = valor;
        }

        public string getNome()
        {
               return nome;
        }

        public void setNome(string valor)
        {
            nome = valor;
        }

        public string getEndereco()
        {
           return endereco;
        }

        public void setEndereco(string valor)
        {
            endereco = valor;
        }

        public int getNivel()
        {
           return nivel;
        }

        public void setNivel(int valor)
        {
            nivel = valor;
        }

        public string getTelefone()
        {
           return telefone;
        }

        public void setTelefone(string valor)
        {
            telefone = valor;
        }

        public string getCpf()
        {
            return cpf;
        }

        public void setCpf(string valor)
        {
            cpf = valor;
        }

        public string getPergunta()
        {
           return pergunta;
        }

        public void setPergunta(string valor)
        {
            pergunta = valor;
        }

        public string getResposta()
        {
            return resposta;
        }

        public void setResposta(string valor)
        {
            resposta = valor;
        }

        public clsUsuario()
        {
            codigo = 0;
            login = "";
            senha = "";
            nome = "";
            endereco = "";
            nivel = 0;
            telefone = "";
            cpf = "";
            pergunta = "";
            resposta = "";
        }

        public clsUsuario(int cod, string log, string sen, string nom, string end, int niv, string tel, string cpf, string per, string res)
        {
            codigo = cod;
            login = log;
            senha = sen;
            nome = nom;
            endereco = end;
            nivel = niv;
            telefone = tel;
            this.cpf = cpf;
            pergunta = per;
            resposta = res;
        }

        public bool Inserir()
        {
            string sql = "INSERT INTO USUARIO (USU_LOGIN, USU_SENHA, USU_NOME, USU_ENDERECO, USU_NIVELACESSO, USU_TELEFONE, USU_CPF, USU_PERGUNTA, USU_RESPOSTA) VALUES ('" + login + "', '" + senha + "', '" + nome + "', '" + endereco + "', " + nivel + ", '" + telefone + "', '" + cpf + "', '" + pergunta + "', '" + resposta + "')";
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Alterar()
        {
            string sql = "UPDATE USUARIO SET USU_LOGIN = '" + login + "', USU_SENHA = '" + senha + "', USU_NOME = '" + nome + "', USU_ENDERECO = '" + endereco + "', USU_NIVELACESSO = " + nivel + ", USU_TELEFONE = '" + telefone + "', USU_CPF = '"+cpf+"', USU_PERGUNTA = '"+pergunta+"', USU_RESPOSTA = '"+resposta+"' WHERE USU_CODIGO = "+codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Excluir()
        {
            string sql = "DELETE FROM USUARIO WHERE USU_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool RecuperaDados()
        {
            bool aux = false;
            string sql = "SELECT * FROM USUARIO WHERE USU_CODIGO = " + codigo;
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                login = dt.Rows[0]["USU_LOGIN"].ToString();
                senha = dt.Rows[0]["USU_SENHA"].ToString();
                nivel = Convert.ToInt32(dt.Rows[0]["USU_NIVELACESSO"]);
                nome = dt.Rows[0]["USU_NOME"].ToString();
                telefone = dt.Rows[0]["USU_TELEFONE"].ToString();
                endereco = dt.Rows[0]["USU_ENDERECO"].ToString();
                cpf = dt.Rows[0]["USU_CPF"].ToString();
                pergunta = dt.Rows[0]["USU_PERGUNTA"].ToString();
                resposta = dt.Rows[0]["USU_RESPOSTA"].ToString();
            }
            return aux;
        }

        public bool RecuperaDados(string log, string pass)
        {
            bool aux = false;
            string sql = "SELECT USU_LOGIN, USU_SENHA, USU_CODIGO FROM USUARIO WHERE USU_LOGIN LIKE '" +log+ "' AND USU_SENHA LIKE '" +pass+ "'";
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                codigo = Convert.ToInt32(dt.Rows[0]["USU_CODIGO"]);
                login = dt.Rows[0]["USU_LOGIN"].ToString();
                senha = dt.Rows[0]["USU_SENHA"].ToString();
            }
            return aux;
        }

        public bool RecuperaDados(string log)
        {
            bool aux = false;
            string sql = "SELECT USU_LOGIN, USU_SENHA, USU_CODIGO, USU_PERGUNTA, USU_RESPOSTA FROM USUARIO WHERE USU_LOGIN LIKE '" + log + "'";
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                codigo = Convert.ToInt32(dt.Rows[0]["USU_CODIGO"]);
                login = dt.Rows[0]["USU_LOGIN"].ToString();
                senha = dt.Rows[0]["USU_SENHA"].ToString();
                pergunta = dt.Rows[0]["USU_PERGUNTA"].ToString();
                resposta = dt.Rows[0]["USU_RESPOSTA"].ToString();
            }
            return aux;
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            string sql = "SELECT * FROM USUARIO";
            if(Parametro == "Código")
            {
                if (Criterio == "")
                    Criterio = "0";
                sql = sql + " WHERE USU_CODIGO = " + Criterio;
            }
            else
            {
                if(Parametro == "Login")
                {
                    sql = sql + " WHERE USU_LOGIN LIKE '%" + Criterio + "%'";
                }
                else
                {
                    sql = sql + " WHERE USU_NOME LIKE '%" + Criterio + "%'";
                }
            }
            return RetornaDT(sql);
        }
    }
}
