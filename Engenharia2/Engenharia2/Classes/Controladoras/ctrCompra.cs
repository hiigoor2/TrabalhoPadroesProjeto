using Engenharia2.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Controladoras
{
    class ctrCompra
    {
        clsCompra compra;
        
        public ctrCompra()
        {
            compra = new clsCompra();
        }

        public clsCompra getCompra(int cod)
        {
            compra.setCodigo(cod);
            compra.RecuperaDados();
            return compra;
        }

        public int getCodigo()
        {
            return compra.getCodigo();
        }

        public void setCodigo(int valor)
        {
            compra.setCodigo(valor);
        }

        public decimal getValor()
        {
            return compra.getValor();
        }

        public void setValor(decimal valor)
        {
            compra.setValor(valor);
        }

        public int getNumParc()
        {
            return compra.getNumPar();
        }

        public void setNumParc(int valor)
        {
            compra.setNumPar(valor);
        }

        public string getFormaPgto()
        {
            return compra.getFormaPgto();
        }

        public void setFormaPgto(string valor)
        {
            compra.setFormaPgto(valor);
        }

        public string getObs()
        {
            return compra.getObs();
        }

        public void setObs(string valor)
        {
            compra.setObs(valor);
        }

        public void setData(DateTime data)
        {
            compra.setData(data);
        }

        public DateTime getData()
        {
            return compra.getData();
        }

        public void setFornecedor(int forn)
        {
            compra.setFornecedor(forn);
        }

        public int getFornecedor()
        {
            return compra.getFornecedor();
        }

        public void setInsereLista(int codcompra, int codprod, int qtde, double prec)
        {
            compra.setInsereLista(new clsICompraProd(codcompra,codprod,qtde,prec));
        }

        public void setLista(List<clsICompraProd> lista)
        {
            compra.setLista(lista);
        }

        public List<clsICompraProd> getLista()
        {
            return compra.getLista();
        }

        public DataTable ProdList(string p)
        {
            clsProduto prod = new clsProduto();
            return prod.List(p);
        }

        public DataTable FornList()
        {
            clsFornecedor f = new clsFornecedor();
            return f.PopulaGrid();
        }

        public bool Gravar()
        {
            return compra.Inserir();
        }

        public bool Delete()
        {
            return compra.Excluir();
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            DataTable dt = new DataTable(), dt2 = new DataTable();
            int aux;
            
            dt = compra.PopulaGrid(Parametro, Criterio);
            dt.Columns.Add("FOR_NOME");
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                aux = (int)dt.Rows[i]["FOR_CODIGO"];
                dt2 = compra.RetornaDT("SELECT FOR_NOME FROM FORNECEDOR WHERE FOR_CODIGO = " + aux);
                dt.Rows[i]["FOR_NOME"] = dt2.Rows[0]["FOR_NOME"];
            }
            return dt;
        }
    }
}