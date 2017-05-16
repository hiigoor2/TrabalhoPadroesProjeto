using Engenharia2.Classes.Entidades;
using System;

namespace Engenharia2.Classes.Controladoras
{
    class ctrEmpresa
    {
        private clsEmpresa _empresa;

        public ctrEmpresa()
        {
            _empresa = new clsEmpresa();
        }

        public int getCodigo()
        {
            return _empresa.getCodigo();
        }
        public void setCodigo(int codigo)
        {
            _empresa.setCodigo(codigo);
        }
        public string getRazao()
        {
            return _empresa.getRazao();
        }
        public void setRazao(string razao)
        {
            _empresa.setRazao(razao);
        }
        public string getCnpj()
        {
            return _empresa.getCnpj();
        }
        public void setCnpj(string cnpj)
        {
            _empresa.setCnpj(cnpj);
        }
        public string getNomeFantasia()
        {
            return _empresa.getNomeFantasia();
        }
        public void setNomeFantasia(string nomef)
        {
            _empresa.setNomeFantasia(nomef);
        }
        /*public string getEndereco()
        {
            return _empresa.getEndereco();
        }
        public void setEndereco(string endereco)
        {
            _empresa.setEndereco(endereco);
        }*/
        public string getRua()
        {
            return _empresa.getRua();
        }
        public void setRua(string rua)
        {
            _empresa.setRua(rua);
        }
        public string getBairro()
        {
            return _empresa.getBairro();
        }
        public void setBairro(string bairro)
        {
            _empresa.setBairro(bairro);
        }
        public int getNumero()
        {
            return _empresa.getNumero();
        }
        public void setNumero(string num)
        {
            int aux = Convert.ToInt32(num);
            _empresa.setNumero(aux);
        }
        public string getComplemento()
        {
            return _empresa.getComplemento();
        }
        public void setComplemento(string comp)
        {
            _empresa.setComplemento(comp);
        }
        public string getLogo()
        {
            return _empresa.getLogo();
        }
        public void setLogo(string logo)
        {
            _empresa.setLogo(logo);
        }

        public int Gravar()
        {
            if (getCodigo() == 0)
            {
                return _empresa.Insert();
            }
            else
            {
                return _empresa.Update();
            }
                
        }

        public void Select()
        {
            _empresa.Select();
        }
    }
}
