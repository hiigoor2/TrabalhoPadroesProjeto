using Engenharia2.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia2.Classes.Controladoras
{
    class ctrAgendamento
    {
        clsAgendamento agenda;

        public ctrAgendamento()
        {
            agenda = new clsAgendamento();
        }

        public clsAgendamento getAgendamento(int cod)
        {
            agenda.setCodigo(cod);
            agenda.RecuperaDados();
            return agenda;
        }

        public int getCodigo()
        {
            return agenda.getCodigo();
        }

        public void setCodigo(int valor)
        {
            agenda.setCodigo(valor);
        }

        public DateTime getData()
        {
            return agenda.getData();
        }

        public void setData(DateTime valor)
        {
            agenda.setData(valor);
        }

        public DateTime getHoraInicial()
        {
            return agenda.getHoraInicio();
        }

        public void setHoraInicial(DateTime valor)
        {
            agenda.setHoraInicio(valor);
        }

        public DateTime getHoraFinal()
        {
            return agenda.getHoraFim();
        }

        public void setHoraFinal(DateTime valor)
        {
            agenda.setHoraFim(valor);
        }

        public int getStatus()
        {
            return agenda.getStatus();
        }

        public void setStatus(int valor)
        {
            agenda.setStatus(valor);
        }

        public int getCliente()
        {
            return agenda.getCliente();
        }

        public void setCliente(int valor)
        {
            agenda.setCliente(valor);
        }


        public void setInsereLista(int codcompra, int codprod, int qtde)
        {
            agenda.setInsereLista(new clsIAgProd(codcompra, codprod, qtde));
        }

        public void setLista(List<clsIAgProd> lista)
        {
            agenda.setLista(lista);
        }

        public List<clsIAgProd> getLista()
        {
            return agenda.getLista();
        }

        public DataTable CliList(string p)
        {
            clsCliente cli = new clsCliente();
            return cli.Listar(p);
        }

        public DataTable ProdList(string p)
        {
            clsProduto prod = new clsProduto();
            return prod.List(p);
        }

        public DataTable carregaAgenda(DateTime data)
        {
            int aux;
            DataTable dt2 = new DataTable();
            DataTable dt = agenda.RetornaDT("SELECT * FROM AGENDAMENTO WHERE AG_DATAINICIAL = '" + data.Month + "/" + data.Day + "/" + data.Year + "' ORDER BY AG_DATAINICIAL");
            dt.Columns.Add("CLI_NOME");
            dt.Columns.Add("COMPARECEU");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                aux = (int)dt.Rows[i]["CLI_CODIGO"];
                dt2 = agenda.RetornaDT("SELECT CLI_NOME FROM CLIENTE WHERE CLI_CODIGO = " + aux);
                dt.Rows[i]["CLI_NOME"] = dt2.Rows[0]["CLI_NOME"];
                if (Convert.ToInt32(dt.Rows[i]["AG_STATUS"]) == 1)
                    dt.Rows[i]["COMPARECEU"] = "Sim";
                else
                    dt.Rows[i]["COMPARECEU"] = "Não";
            }
            return dt;
        }
            
        public bool Gravar()
        {
            return agenda.Inserir();
        }

        public bool Delete()
        {
            return agenda.Excluir();
        }
            
        public void RecuperaDados()
        {
            agenda.RecuperaDados();
        }
    }
}