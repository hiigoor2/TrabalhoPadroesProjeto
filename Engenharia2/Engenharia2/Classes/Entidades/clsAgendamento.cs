using Engenharia2.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Entidades
{
    class clsAgendamento : Persistencia
    {
        int codigo;
        DateTime horainicio;
        DateTime horafim;
        DateTime data;
        int status;
        int cliente;
        List<clsIAgProd> produtos;

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int valor)
        {
            codigo = valor;
        }

        public DateTime getHoraInicio()
        {
            return horainicio;
        }

        public void setHoraInicio(DateTime valor)
        {
            horainicio = valor;
        }

        public DateTime getHoraFim()
        {
            return horafim;
        }

        public void setHoraFim(DateTime valor)
        {
            horafim = valor;
        }

        public DateTime getData()
        {
            return data;
        }

        public void setData(DateTime valor)
        {
            data = valor;
        }

        public int getStatus()
        {
            return status;
        }

        public void setStatus(int valor)
        {
            status = valor;
        }

        public int getCliente()
        {
            return cliente;
        }

        public void setCliente(int valor)
        {
            cliente = valor;
        }

        public void setInsereLista(clsIAgProd c)
        {
            produtos.Add(c);
        }

        public void setLista(List<clsIAgProd> lista)
        {
            produtos = lista;
        }

        public List<clsIAgProd> getLista()
        {
            return produtos;
        }

        public clsAgendamento()
        {
            codigo = 0;
            horainicio = DateTime.MinValue;
            horafim = DateTime.MinValue;
            data = DateTime.MinValue;
            cliente = 0;
            status = 0;
            produtos = new List<clsIAgProd>();
        }

        public clsAgendamento(int cod, DateTime hi, DateTime hf, DateTime dt, int st, int cli)
        {
            codigo = cod;
            horainicio = hi;
            horafim = hf;
            data = dt;
            status = st;
            cliente = cli;
            produtos = new List<clsIAgProd>();
        }

        public bool Inserir()
        {
            string sql = "INSERT INTO AGENDAMENTO (AG_HORAINICIAL, AG_HORAFINAL, AG_DATAINICIAL, AG_STATUS, CLI_CODIGO) VALUES ('"+horainicio.Month+"/"+horainicio.Day+"/"+horainicio.Year+ " " + horainicio.Hour + ":" + horainicio.Minute + ":" + horainicio.Second + "', '" + horafim.Month + "/" + horafim.Day + "/" + horafim.Year + " " + horafim.Hour + ":"+horafim.Minute+":"+horafim.Second+"', '" + data.Month + "/" + data.Day + "/" + data.Year + "', " + status + ", " + cliente + ")";
            if (ExecutaSQL(sql) > 0)
            {
                DataTable dt = RetornaDT("SELECT MAX(AG_CODIGO) AS COD FROM AGENDAMENTO");
                codigo = Convert.ToInt32(dt.Rows[0]["COD"]);
                foreach (clsIAgProd prod in produtos)
                {
                    prod.setCodAgenda(codigo);
                    if (!prod.Inserir())
                        return false;
                }
                    return true;
            }
            return false;
        }

        public bool Alterar()
        {
            ExecutaSQL("DELETE FROM ITEM_PRODAG WHERE AG_CODIGO = " + codigo);
            string sql = "UPDATE AGENDAMENTO SET AG_HORAINICIAL = '" + horainicio.Month + "/" + horainicio.Day + "/" + horainicio.Year + " " + horainicio.TimeOfDay + "', AG_HORAFINAL = '" + horafim.Month + "/" + horafim.Day + "/" + horafim.Year + " " + horafim.TimeOfDay + "', AG_DATAINICIAL = '" + data.Month + "/" + data.Day + "/" + data.Year + "', AG_STATUS = " + status + ", CLI_CODIGO = " + cliente + " WHERE AG_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Excluir()
        {
            ExecutaSQL("DELETE FROM ITEM_PRODAG WHERE AG_CODIGO = " + codigo);
            string sql = "DELETE FROM AGENDAMENTO WHERE AG_CODIGO = " + codigo;
            if (ExecutaSQL(sql) > 0)
                return true;
            return false;
        }

        public bool RecuperaDados()
        {
            bool aux = false;
            string sql = "SELECT * FROM AGENDAMENTO WHERE AG_CODIGO = " + codigo;
            DataTable dt = RetornaDT(sql);
            if (dt.Rows.Count > 0)
            {
                aux = true;
                horainicio = Convert.ToDateTime(dt.Rows[0]["AG_HORAINICIAL"]);
                horafim = Convert.ToDateTime(dt.Rows[0]["AG_HORAFINAL"]);
                data = Convert.ToDateTime(dt.Rows[0]["AG_DATAINICIAL"]);
                status = Convert.ToInt32(dt.Rows[0]["AG_STATUS"]);
                cliente = Convert.ToInt32(dt.Rows[0]["CLI_CODIGO"]);
            }
            return aux;
        }

        public DataTable PopulaGrid(string Parametro, string Criterio)
        {
            string sql = "SELECT * FROM AGENDAMENTO";
            if (Parametro == "Código")
            {
                if (Criterio == "")
                    Criterio = "0";
                sql = sql + " WHERE AG_CODIGO = " + Criterio;
            }
            else
            {
                    sql = sql + " WHERE AG_DATAINICIAL LIKE '" + Criterio + "'";
            }
            return RetornaDT(sql);
        }
    }
}
