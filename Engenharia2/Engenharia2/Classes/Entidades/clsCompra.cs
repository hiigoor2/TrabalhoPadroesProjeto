using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsCompra : Persistencia
    {
        int codigo;
        decimal valor;
        List<clsICompraProd> produtos;
        string formapgto;
        int numparcela;
        string obs;
        DateTime data;
        int fornecedor;

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int cod)
        {
            codigo = cod;
        }

        public int getFornecedor()
        {
            return fornecedor;
        }

        public void setFornecedor(int cod)
        {
            fornecedor = cod;
        }

        public string getFormaPgto()
        {
            return formapgto;
        }

        public void setFormaPgto(string valor)
        {
            formapgto = valor;
        }

        public decimal getValor()
        {
            return valor;
        }

        public void setValor(decimal valor)
        {
            this.valor = valor;
        }


        public int getNumPar()
        {
            return numparcela;
        }

        public void setNumPar(int valor)
        {
            numparcela = valor;
        }

        public string getObs()
        {
            return obs;
        }

        public void setObs(string valor)
        {
            obs = valor;
        }
        
        public DateTime getData()
        {
            return data;
        }

        public void setData(DateTime valor)
        {
            data = valor;
        }

        public List<clsICompraProd> getLista()
        {
            return produtos;
        }

        public void setInsereLista(clsICompraProd c)
        {
            produtos.Add(c);
        }

        public void setLista(List<clsICompraProd> lista)
        {
            produtos = lista;
        }

        public clsCompra()
        {
            codigo = 0;
            valor = 0;
            formapgto = "";
            numparcela = 0;
            obs = "";
            data = new DateTime();
            produtos = new List<clsICompraProd>();
        }

        public clsCompra(int cod, decimal val, int num, string forma, string obs, DateTime dat, List<clsICompraProd>lprod)
        {
            codigo = cod;
            valor = val;
            numparcela = num;
            formapgto = forma;
            this.obs = obs;
            data = dat;
            produtos = new List<clsICompraProd>();
            produtos = lprod;
        }

        public bool Inserir()
        {
            
            string sql = "INSERT INTO COMPRA (COM_VALOR, COM_FORMAPGTO, COM_NUMPARCELA, COM_OBS, COM_DATA, FOR_CODIGO) VALUES (" + valor + ", '" + formapgto + "', " + numparcela + ", '" + obs + "', '" + data.Month + "/"+data.Day+"/"+data.Year+"', " + fornecedor +")";
            if (ExecutaSQL(sql) > 0)
            {
                DataTable dt = RetornaDT("SELECT MAX(COM_CODIGO) AS COD FROM COMPRA");
                codigo = Convert.ToInt32(dt.Rows[0]["COD"]);
                foreach (clsICompraProd prod in produtos)
                {
                    prod.setCodCompra(codigo);
                    if (!prod.Inserir())
                        return false;
                    if (ExecutaSQL("UPDATE PRODUTO SET PROD_QTDE = (PROD_QTDE+" + prod.getQtde() + ") WHERE PROD_CODIGO = " + prod.getCodProduto()) == 0)
                        return false;
                }
                return true;
            }
            return false;

        }

        public bool Alterar()
        {
            ExecutaSQL("DELETE FROM ITEM_PRODCOM WHERE COM_CODIGO = "+ codigo);
            string sql = "UPDATE COMPRA SET COM_VALOR = " + valor + ", COM_FORMAPGTO = '" + formapgto + "', COM_NUMPARCELA = " + numparcela + ", COM_OBS = '" + obs + "', COM_DATA = '" + data + "', FOR_CODIGO = "+fornecedor+" WHERE COM_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Excluir()
        {
            
            string sql = "DELETE FROM COMPRA WHERE COM_CODIGO = " + codigo;
            string sql1 = "DELETE FROM ITEM_PRODCOM WHERE COM_CODIGO = " + codigo;
            if (ExecutaSQL(sql1) > 0 && ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool RecuperaDados()
        {
            bool aux = false;
            string sql = "SELECT * FROM COMPRA WHERE COM_CODIGO = " + codigo;
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                valor = Convert.ToDecimal(dt.Rows[0]["COM_VALOR"]);
                formapgto = dt.Rows[0]["COM_FORMAPGTO"].ToString();
                numparcela = Convert.ToInt32(dt.Rows[0]["COM_NUMPARCELA"]);
                obs = dt.Rows[0]["COM_OBS"].ToString();
                data = Convert.ToDateTime(dt.Rows[0]["COM_DATA"]);
                fornecedor = Convert.ToInt32(dt.Rows[0]["FOR_CODIGO"]);
            }
            return aux;
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            string sql = "SELECT * FROM COMPRA";
            if (Criterio != "")
            {
                if (Parametro == "Código")
                {
                    if (Criterio == "")
                        Criterio = "0";
                    sql = sql + " WHERE COM_CODIGO = " + Criterio;
                }
                else
                {
                    if (Parametro == "Forma de Pagamento")
                        sql = sql + " WHERE COM_FORMAPGTO LIKE '%" + Criterio + "%'";
                    else
                    {
                        if (Parametro == "Valor")
                        {
                            double v;
                            Double.TryParse(Criterio, out v);
                            sql = sql + " WHERE COM_VALOR = " + v;
                        }
                        else
                        {
                            DateTime d;
                            DateTime.TryParse(Criterio, out d);
                            sql = sql + " WHERE COM_DATA = '" + d + "'";
                        }
                    }

                }
            }
            return RetornaDT(sql);
        }
    }
}