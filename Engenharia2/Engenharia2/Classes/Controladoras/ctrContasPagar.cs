using Engenharia2.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Controladoras
{
    class ctrContasPagar
    {
        clsContasPagar contas;

        public ctrContasPagar()
        {
            contas = new clsContasPagar();
        }

        public ctrContasPagar(int cod, string desc, DateTime ven, DateTime cria, DateTime paga, double v, double vp, int cp)
        {
            contas = new clsContasPagar(cod, desc, ven, cria, paga, v, vp, cp);
        }

        public int getCodigo()
        {
            return contas.getCodigo();
        }

        public void setCodigo(int valor)
        {
            contas.setCodigo(valor);
        }

        public string getDescricao()
        {
            return contas.getDescricao();
        }

        public void setDescricao(string valor)
        {
            contas.setDescricao(valor);
        }

        public DateTime getDtvencimento()
        {
            return contas.getDtvencimento();
        }

        public void setDtvencimento(DateTime valor)
        {
            contas.setDtvencimento(valor);
        }

        public DateTime getDtcriacao()
        {
            return contas.getDtcriacao();
        }

        public void setDtcriacao(DateTime valor)
        {
            contas.setDtcriacao(valor);
        }

        public DateTime getDtpagamento()
        {
            return contas.getDtpagamento();
        }

        public void setDtpagamento(DateTime valor)
        {
            contas.setDtpagamento(valor);
        }

        public double getValor()
        {
            return contas.getValor();
        }

        public void setValor(double v)
        {
            contas.setValor(v);
        }

        public double getValorpago()
        {
            return contas.getValorpago();
        }

        public void setValorpago(double v)
        {
            contas.setValorpago(v);
        }

        public int getCodcompra()
        {
            return contas.getCodcompra();
        }

        public void setCodcompra(int valor)
        {
            contas.setCodcompra(valor);
        }

        public bool Insere(int num)
        {
            for(int i = 0; i < num; i ++)
            {
                if (!contas.Inserir())
                    return false;
                contas.setDtvencimento(contas.getDtvencimento().AddMonths(1));
            }
            return true;
        }

        public bool Quita()
        {
            return (contas.Alterar());
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            return contas.PopulaGrid(Parametro, Criterio);
        }
    }
}
