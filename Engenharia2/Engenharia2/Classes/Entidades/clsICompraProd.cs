using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsICompraProd : Persistencia
    {
        clsCompra codcompra;
        clsProduto codproduto = new clsProduto();
        int qtde;
        double preco;

        public int getCodCompra()
        {
            return codcompra.getCodigo();
        }

        public void setCodCompra(int cod)
        {
            codcompra.setCodigo(cod);
        }

        public int getCodProduto()
        {
            return codproduto.getCodigo();
        }

        public void setCodProduto(int cod)
        {
            codproduto.setCodigo(cod);
            codproduto.Select();
        }

        public int getQtde()
        {
            return qtde;
        }

        public void setQtde(int valor)
        {
            qtde = valor;
        }
        
        public double getPreco()
        {
            return preco;
        }

        public void setPreco(double valor)
        {
            preco = valor;
        }
        public clsICompraProd()
        {
            codcompra.setCodigo(0);
            qtde = 0;
            preco = 0;
            codproduto.setCodigo(0);
        }

        public clsICompraProd(int codcom, int codpro, int qtd, double pre)
        {
            codcompra = new clsCompra();
            codproduto = new clsProduto();
            codcompra.setCodigo(codcom);
            codproduto.setCodigo(codpro);
            codproduto.Select();
            qtde = qtd;
            preco = pre;
        }

        public bool Inserir()
        {
            string sql = "INSERT INTO ITEM_PRODCOM (PROD_CODIGO, COM_CODIGO, IPC_QTDE, IPC_PRECOCOMPRA) VALUES (" + codproduto.getCodigo() + ", " + codcompra.getCodigo() + ", " + qtde + ", "+preco+")";
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Excluir()
        {
            string sql = "DELETE FROM ITEM_PRODCOM WHERE COM_CODIGO = " + codcompra.getCodigo();
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool RecuperaDados()
        {
            bool aux = false;
            string sql = "SELECT * FROM ITEM_PRODCOM WHERE COM_CODIGO = " + codcompra.getCodigo();
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                codproduto.setCodigo(Convert.ToInt32(dt.Rows[0]["PROD_CODIGO"]));
                qtde = Convert.ToInt32(dt.Rows[0]["IPC_QTDE"]);
                preco = Convert.ToDouble(dt.Rows[0]["IPC_PRECO"]);
            }
            return aux;
        }

        public DataTable PopulaGrid(string Criterio)
        {
            string sql = "SELECT * FROM ITEM_PRODCOM";
            if (Criterio == "")
                    Criterio = "0";
            sql = sql + " WHERE COM_CODIGO = " + Criterio;
            
            return RetornaDT(sql);
        }
    }
}