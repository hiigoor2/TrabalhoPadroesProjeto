using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engenharia2.Classes.Entidades;

namespace Engenharia2.Classes.Controladoras
{
    class ctrUsuario
    {
        private clsUsuario usu;

        public clsUsuario getUsu()
        {
            return usu;
        }

        public int getCodigo()
        {
            return usu.getCodigo();
        }

        public string getLogin()
        {
            return usu.getLogin();
        }

        public string getSenha()
        {
            return usu.getSenha();
        }

        public string getNome()
        {
            return usu.getNome();
        }

        public string getEndereco()
        {
            return usu.getEndereco();
        }

        public int getNivel()
        {
            return usu.getNivel();
        }

        public string getTelefone()
        {
            return usu.getTelefone();
        }

        public string getCpf()
        {
            return usu.getCpf();
        }

        public string getResposta()
        {
            return usu.getResposta();
        }

        public string getPergunta()
        {
            return usu.getPergunta();
        }

        public void setUsu(int cod, string log, string senha, string nome, string endereco, int nivel, string telefone, string cpf, string pergunta, string resposta)
        {
            usu = new clsUsuario(cod, log, senha, nome, endereco, nivel, telefone, cpf, pergunta, resposta);
        }
        public ctrUsuario(int cod, string log, string senha, string nome, string endereco, int nivel, string telefone, string cpf, string pergunta, string resposta)
        {
            usu = new clsUsuario(cod, log, senha, nome, endereco, nivel, telefone, cpf, pergunta, resposta);
        }

        public ctrUsuario()
        {
            usu = new clsUsuario();
        }

        public bool Inserir()
        {
            return usu.Inserir();
        }

        public bool Alterar()
        {
            return usu.Alterar();
        }

        public bool Excluir()
        {
            return usu.Excluir();
        }

        public bool RecuperaDados()
        {
            return usu.RecuperaDados();
        }

        public bool RecuperaDados(string log, string pass)
        {
            return usu.RecuperaDados(log, pass);
        }

        public bool RecuperaDados(string log)
        {
            return usu.RecuperaDados(log);
        }

        public string ValidaCpf(string cpf)
        {
            string msg = "";
            if (cpf == "")
                msg = msg + "CPF inválido";
            else
            {
                Int64 icpf = 0;
                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace("-", "");
                cpf = cpf.Replace(",", "");
                try { icpf = Convert.ToInt64(cpf); } catch { icpf = 0; }
                if (icpf == 0)
                    msg = msg + "\n CPF inválido!";
                else
                {
                    int cont = 0, aux = 0;
                    if (cpf.Length == 11)
                    {
                        for (int k = 10; k > 1; k--)
                        {
                            aux = aux + (((int)cpf[cont] - 48) * k);
                            cont++;
                        }
                        cont = aux * 10 % 11;
                        if (cont == 10)
                            cont = 0;
                        if (cont == ((int)cpf[9] - 48))
                        {
                            cont = 0;
                            for (int k = 11; k > 1; k--)
                            {
                                aux = aux + (((int)cpf[cont] - 48) * k);
                                cont++;
                            }
                            cont = aux * 10 % 11;
                            if (cont == 10)
                                cont = 0;
                            if (cont == ((int)cpf[10] - 48))
                                msg = msg + "\n CPF inválido!";
                        }
                        else
                            msg = msg + "\n CPF inválido!";
                    }
                    else
                        msg = msg + "\n CPF inválido!";
                }
            }
            return msg;
        }

        public string PreparaDados(string cod, string login, string senha, string nome, string endereco, string nivel, string telefone, string cpf, string pergunta, string resposta)
        {
            string msg = "";
            int i = 0, j = 0;
            if (cod != "")
                i = Convert.ToInt32(cod);
            if (nivel.Equals("Administrador"))
                j = 1;

            DataTable dt = usu.RetornaDT("SELECT USU_CODIGO FROM USUARIO WHERE USU_LOGIN LIKE '" + login + "' AND USU_CODIGO !="+i);
            if (dt.Rows.Count > 0)
                msg = "Login já utilizado!";
            if (senha.Length < 4)
                msg = msg + "\n Senha deve conter no mínimo 4 caracteres";
            msg = msg + ValidaCpf(cpf);
            usu = new clsUsuario(i, login, senha, nome, endereco, j, telefone, cpf, pergunta, resposta);
            return msg;
        }

        public DataTable PopulaGrid(string Param, string Crit)
        {
            return usu.PopulaGrid(Param, Crit);
        }
    }
}
