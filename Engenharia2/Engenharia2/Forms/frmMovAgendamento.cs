using Engenharia2.Classes.Controladoras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engenharia2.Forms
{
    public partial class frmMovAgendamento : Form
    {
        DataTable dt = new DataTable();
        ctrAgendamento ag = new ctrAgendamento();

        public frmMovAgendamento()
        {
            InitializeComponent();
            estados(2);
            cbbCliente.DataSource = ag.CliList("");
            cbbCliente.DisplayMember = "CLI_NOME";
            cbbCliente.ValueMember = "CLI_CODIGO";
            dt.Columns.Add("Código Agendamento");
            dt.Columns.Add("Código Produto");
            dt.Columns.Add("Descrição");
            dt.Columns.Add("Quantidade");

            dtpData.Value = DateTime.Now;
        }

        public void limparCampos()
        {
            txtCod.Text = "";
            dtpData.Value = DateTime.Now;
            txtQtde.Text = "";
            cbbCliente.SelectedIndex = 0;
            txtBusca.Text = "";
        }

        public void preencherDados()
        {
            try { ag.setCodigo(Convert.ToInt32(txtCod.Text)); } catch { }
            ag.setData(dtpData.Value);
            ag.setHoraInicial(Convert.ToDateTime(dgvAgenda.SelectedRows[0].Cells["Column3"].Value));
            ag.setHoraFinal(ag.getHoraInicial().AddMinutes(30));
            ag.setStatus(0);
            try { ag.setCliente(Convert.ToInt32(cbbCliente.SelectedValue)); } catch { }
            for (int i = 0; i < dt.Rows.Count; i++)
                ag.setInsereLista(0, Convert.ToInt32(dt.Rows[i]["Código Produto"]), Convert.ToInt32(dt.Rows[i]["Quantidade"]));
        }

        public void carregaCampos()
        {
            txtCod.Text = ag.getCodigo() + "";
            dtpData.Value = ag.getData();
            cbbCliente.SelectedValue = ag.getCliente();
        }

        public void estados(int i)
        {
            switch (i)
            {
                case 0://default
                    txtCod.Enabled = false;
                    dtpData.Enabled = false;
                    txtQtde.Enabled = false;
                    txtBusca.Enabled = false;
                    cbbCliente.Enabled = false;

                    btnCancela.Enabled = false;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = false;
                    btnNovo.Enabled = true;
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    break;
                case 1://visualizando
                    txtCod.Enabled = false;
                    dtpData.Enabled = false;
                    txtQtde.Enabled = false;
                    txtBusca.Enabled = false;
                    cbbCliente.Enabled = false;

                    btnCancela.Enabled = true;
                    btnExclui.Enabled = true;
                    btnGrava.Enabled = false;
                    btnNovo.Enabled = false;
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    break;
                case 2://inserindo
                    txtCod.Enabled = false;
                    dtpData.Enabled = true;
                    txtQtde.Enabled = true;
                    txtBusca.Enabled = true;
                    cbbCliente.Enabled = true;

                    btnCancela.Enabled = true;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = true;
                    btnNovo.Enabled = false;
                    btnAdd.Enabled = true;
                    btnRemove.Enabled = true;
                    break;
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(0, dgvProdutos.SelectedCells[0].Value, dgvProdutos.SelectedCells[1].Value, txtQtde.Text);
            dgvItens.DataSource = dt;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dt.Rows.RemoveAt(dgvItens.SelectedCells[0].RowIndex);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            estados(2);
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            estados(3);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            preencherDados();
            if (ag.getData() != null && ag.getHoraInicial() != null && ag.getHoraFinal() != null && ag.getCliente() > 0 && ag.getLista().Count > 0)
            {
                if (ag.Gravar())
                {
                    MessageBox.Show("Gravado com sucesso!", "Mensagem", MessageBoxButtons.OK);
                    limparCampos();
                    estados(1);
                    dtpData.Value = DateTime.Now;
                    dgvItens.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Não foi possivel gravar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            preencherDados();
            if (ag.getCodigo() > 0)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir?", "Confirma Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ag.Delete();
                    limparCampos();
                    estados(0);
                }
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            limparCampos();
            estados(0);
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ag.ProdList(txtBusca.Text);
            dgvProdutos.DataSource = dt;
        }

        private int Vago(DateTime hora, DataTable aux)
        {
            for(int i = 0; i < aux.Rows.Count; i++)
            {
                if (Convert.ToDateTime(aux.Rows[i]["AG_HORAINICIAL"]).TimeOfDay == hora.TimeOfDay)
                    return i;
            }
            return -1;
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            int index = -1;
            DateTime hora = Convert.ToDateTime(dtpData.Value.ToShortDateString()+" 08:00:00");
            DataTable aux = ag.carregaAgenda(dtpData.Value), dat;
            dat = new DataTable();
            dat.Columns.Add("AG_HORAINICIAL");
            dat.Columns.Add("CLI_NOME");
            dat.Columns.Add("COMPARECEU");
            dat.Columns.Add("AG_CODIGO");
            for (int i = 0; i < 20; i++)
            {
                dat.Rows.Add();
                dat.Rows[i]["AG_HORAINICIAL"] = hora.TimeOfDay;
                index = Vago(hora, aux);
                if (index!= -1)
                {
                    dat.Rows[i]["CLI_NOME"] = aux.Rows[index]["CLI_NOME"];
                    dat.Rows[i]["COMPARECEU"] = aux.Rows[index]["COMPARECEU"];
                    dat.Rows[i]["AG_CODIGO"] = aux.Rows[index]["AG_CODIGO"];
                }
                hora = hora.AddMinutes(30);
            }
            dgvAgenda.DataSource = dat;
        }

        private void dgvAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ag.setCodigo(Convert.ToInt32(dgvAgenda.SelectedCells[3].Value));
            ag.RecuperaDados();
            carregaCampos();
            estados(1);
        }
    }
}
