using Engenharia2.Classes.Utils;
using System;
using System.Data;

namespace Engenharia2.Classes.Entidades
{
    class clsEmpresa : Persistencia
    {
        //atributos
        private Int32 _codigo;
        private String _razao;
        private String _cnpj;
        private String _nomefantasia;
        //private String _endereco;
        private String _rua;
        private String _bairro;
        private Int32 _numero;
        private String _complemento;
        private String _logo;
        

        //construtores
        public clsEmpresa()
        {
            Codigo = 0;
            Razao = "";
            Cnpj = "";
            Nomefantasia = "";
            //Endereco = "";
            Rua = "";
            Bairro = "";
            Numero = 0;
            Complemento = "";
            Logo = "";
        }

        public clsEmpresa(int codigo, string razao, string cnpj, string nomeft, string rua, int numero, string bairro, string complemento, string logo)
        {
            Codigo = codigo;
            Razao = razao;
            Cnpj = cnpj;
            Nomefantasia = nomeft;
            //Endereco = endereco;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            Logo = logo;
        }

        //gets e sets
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public string Razao
        {
            get
            {
                return _razao;
            }

            set
            {
                _razao = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return _cnpj;
            }

            set
            {
                _cnpj = value;
            }
        }

        public string Nomefantasia
        {
            get
            {
                return _nomefantasia;
            }

            set
            {
                _nomefantasia = value;
            }
        }

        /*public string Endereco
        {
            get
            {
                return _endereco;
            }

            set
            {
                _endereco = value;
            }
        }*/

        public string Logo
        {
            get
            {
                return _logo;
            }

            set
            {
                _logo = value;
            }
        }

        public string Rua
        {
            get
            {
                return _rua;
            }

            set
            {
                _rua = value;
            }
        }

        public string Bairro
        {
            get
            {
                return _bairro;
            }

            set
            {
                _bairro = value;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public string Complemento
        {
            get
            {
                return _complemento;
            }

            set
            {
                _complemento = value;
            }
        }

        public int getCodigo()
        {
            return Codigo;
        }
        public void setCodigo(int codigo)
        {
            Codigo = codigo;
        }
        public string getRazao()
        {
            return Razao;
        }
        public void setRazao(string razao)
        {
            Razao = razao;
        }
        public string getCnpj()
        {
            return Cnpj;
        }
        public void setCnpj(string cnpj)
        {
            Cnpj = cnpj;
        }
        public string getNomeFantasia()
        {
            return Nomefantasia;
        }
        public void setNomeFantasia(string nomef)
        {
            Nomefantasia = nomef;
        }
        /*public string getEndereco()
        {
            return Endereco;
        }
        public void setEndereco(string endereco)
        {
            Endereco = endereco;
        }*/
        public string getRua()
        {
            return Rua;
        }
        public void setRua(string rua)
        {
            Rua = rua;
        }
        public string getBairro()
        {
            return Bairro;
        }
        public void setBairro(string bairro)
        {
            Bairro = bairro;
        }
        public int getNumero()
        {
            return Numero;
        }
        public void setNumero(int num)
        {
            Numero = num;
        }
        public string getComplemento()
        {
            return Complemento;
        }
        public void setComplemento(string comp)
        {
            Complemento = comp;
        }
        public string getLogo()
        {
            return Logo;
        }
        public void setLogo(string logo)
        {
            Logo = logo;
        }
        //operações

        //select
        public int Select()
        {
            String sSql = "SELECT * FROM EMPRESA";
            DataTable dt = RetornaDT(sSql);
            if (dt.Rows.Count > 0)
            {
                Codigo = Convert.ToInt32(dt.Rows[0]["EMP_CODIGO"].ToString());
                Razao = dt.Rows[0]["EMP_RAZAOSOCIAL"].ToString();
                Cnpj = dt.Rows[0]["EMP_CNPJ"].ToString();
                Nomefantasia = dt.Rows[0]["EMP_NOMEFANTASIA"].ToString();
                Rua = dt.Rows[0]["EMP_RUA"].ToString();
                Numero = Convert.ToInt32(dt.Rows[0]["EMP_NUMERO"].ToString());
                Bairro = dt.Rows[0]["EMP_BAIRRO"].ToString();
                Complemento = dt.Rows[0]["EMP_COMPLEMENTO"].ToString();
                //Endereco = dt.Rows[0]["EMP_ENDERECO"].ToString();
                Logo = dt.Rows[0]["EMP_LOGO"].ToString();
                //outros atributos
                return 1;
            }
            else
                return 0;
        }

        //update
        public int Update()
        {
            String sSql = "UPDATE EMPRESA SET " +//ADICIONAR ATRIBUTOS
                " EMP_RAZAOSOCIAL = '" +Razao+ "'," +
                " EMP_CNPJ = '" +Cnpj+ "'," +
                " EMP_NOMEFANTASIA = '" +Nomefantasia+ "'," +
                //" EMP_ENDERECO = " +Endereco+
                " EMP_RUA = '" + Rua + "'," +
                " EMP_NUMERO = " + Numero +","+
                " EMP_BAIRRO = '" + Bairro + "'," +
                " EMP_COMPLEMENTO = '" + Complemento + "'," +
                " EMP_LOGO = '" +Logo+ "' " +
                " WHERE EMP_CODIGO = " + Codigo;
                
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }

        //insert
        public int Insert()
        {
            String sSql = "INSERT INTO EMPRESA(EMP_RAZAOSOCIAL,EMP_CNPJ,EMP_NOMEFANTASIA,EMP_RUA,EMP_NUMERO,EMP_BAIRRO,EMP_COMPLEMENTO,EMP_LOGO)" +
                " VALUES('"+Razao+"', '"+Cnpj+"', '"+Nomefantasia+"', '"+Rua+"', " + Numero + ", '" + Bairro + "', '" + Complemento + "', '" + Logo+"')";//ADICIONAR ATRIBUTOS
            int linhas = ExecutaSQL(sSql);
            return linhas;
        }
    }
}
