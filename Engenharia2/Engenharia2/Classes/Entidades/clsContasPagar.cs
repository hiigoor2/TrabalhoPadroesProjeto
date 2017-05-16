using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsContasPagar : Persistencia
    {
        int codigo;
        string descricao;
        DateTime dtvencimento;
        DateTime dtcriacao;
        DateTime dtpagamento;
        double valor;
        double valorpago;
        int codcompra;

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int valor)
        {
            codigo = valor;
        }

        public string getDescricao()
        {
            return descricao;
        }

        public void setDescricao(string valor)
        {
            descricao = valor;
        }

        public DateTime getDtvencimento()
        {
            return dtvencimento;
        }

        public void setDtvencimento(DateTime valor)
        {
            dtvencimento = valor;
        }

        public DateTime getDtcriacao()
        {
            return dtcriacao;
        }

        public void setDtcriacao(DateTime valor)
        {
            dtcriacao = valor;
        }

        public DateTime getDtpagamento()
        {
            return dtpagamento;
        }

        public void setDtpagamento(DateTime valor)
        {
            dtpagamento = valor;
        }

        public double getValor()
        {
            return valor;
        }

        public void setValor(double v)
        {
            valor = v;
        }

        public double getValorpago()
        {
            return valorpago;
        }

        public void setValorpago(double v)
        {
            valorpago = v;
        }

        public int getCodcompra()
        {
            return codcompra;
        }

        public void setCodcompra(int valor)
        {
            codcompra = valor;
        }

        public clsContasPagar()
        {
            codigo = 0;
            descricao = "";
            dtvencimento = DateTime.MinValue;
            dtcriacao = DateTime.MinValue;
            dtpagamento = DateTime.MinValue;
            valor = 0;
            valorpago = 0;
            codcompra = 0;
        }

        public clsContasPagar(int cod, string desc, DateTime ven, DateTime cria, DateTime paga, double v, double vp, int cp)
        {
            codigo = cod;
            descricao = desc;
            dtvencimento = ven;
            dtcriacao = cria;
            dtpagamento = paga;
            valor = v;
            valorpago = vp;
            codcompra = cp;
        }

        public bool Inserir()
        {
            string sql = "INSERT INTO CONTAS_PAGAR (PAG_DESCRICAO, PAG_DTVENCIMENTO, PAG_DTCRIACAO, PAG_DTPAGAMENTO, PAG_VALOR, PAG_VALORPAGO, COM_CODIGO) VALUES ('" + descricao + "', '" + dtvencimento.Month + "/" + dtvencimento.Day + "/" + dtvencimento.Year + "', '" + dtcriacao.Month + "/" + dtcriacao.Day + "/" + dtcriacao.Year + "', '" + dtpagamento.Month + "/" + dtpagamento.Day + "/" + dtpagamento.Year + "', " + valor + ", " + valorpago + ", " + codcompra + ")";
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        //Quitar
        public bool Alterar()
        {
            string sql = "UPDATE CONTAS_PAGAR SET PAG_VALORPAGO = " + valorpago + ", PAG_DTPAGAMENTO = '" + dtpagamento.Month + "/" + dtpagamento.Day + "/" + dtpagamento.Year + "' WHERE PAG_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            string sql = "SELECT * FROM CONTAS_PAGAR";
            if (Criterio != "")
            {
                if (Parametro == "Código")
                {
                    if (Criterio == "")
                        Criterio = "0";
                    sql = sql + " WHERE PAG_CODIGO = " + Criterio + " AND PAG_DTPAGAMENTO = '1/1/1'";
                }
                else
                {
                    if (Parametro == "Valor")
                    {
                        double v;
                        Double.TryParse(Criterio, out v);
                        sql = sql + " WHERE PAG_VALOR = " + v + " AND PAG_DTPAGAMENTO = '1/1/1'";
                    }
                    else
                    {
                        DateTime d;
                        DateTime.TryParse(Criterio, out d);
                        sql = sql + " WHERE PAG_DTVENCIMENTO = '" + d + "'" + " AND PAG_DTPAGAMENTO = '1/1/1'";
                    }
                }
            }
            return RetornaDT(sql);
        }
    }
}
