using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsIAgProd : Persistencia
    {
        clsAgendamento codagenda;
        clsProduto codproduto = new clsProduto();
        int qtde;

        public int getCodAgenda()
        {
            return codagenda.getCodigo();
        }

        public void setCodAgenda(int cod)
        {
            codagenda.setCodigo(cod);
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

        public clsIAgProd()
        {
            codagenda.setCodigo(0);
            qtde = 0;;
            codproduto.setCodigo(0);
        }

        public clsIAgProd(int codcom, int codpro, int qtd)
        {
            codagenda = new clsAgendamento();
            codproduto = new clsProduto();
            codagenda.setCodigo(codcom);
            codproduto.setCodigo(codpro);
            codproduto.Select();
            qtde = qtd;
        }

        public bool Inserir()
        {
            string sql = "INSERT INTO ITEM_PRODAG (PROD_CODIGO, AG_CODIGO, IPA_QTDE) VALUES (" + codproduto.getCodigo() + ", " + codagenda.getCodigo() + ", " + qtde + ")";
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Excluir()
        {
            string sql = "DELETE FROM ITEM_PRODAG WHERE AG_CODIGO = " + codagenda.getCodigo();
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool RecuperaDados()
        {
            bool aux = false;
            string sql = "SELECT * FROM ITEM_PRODAG WHERE AG_CODIGO = " + codagenda.getCodigo();
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                codproduto.setCodigo(Convert.ToInt32(dt.Rows[0]["PROD_CODIGO"]));
                qtde = Convert.ToInt32(dt.Rows[0]["IPA_QTDE"]);
            }
            return aux;
        }

        public DataTable PopulaGrid(string Criterio)
        {
            string sql = "SELECT * FROM ITEM_PRODAG";
            if (Criterio == "")
                Criterio = "0";
            sql = sql + " WHERE AG_CODIGO = " + Criterio;

            return RetornaDT(sql);
        }
    }
}