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
    public partial class frmQuitarContasPagar : Form
    {
        ctrContasPagar ct = new ctrContasPagar();
        DataTable dt = new DataTable();

        public frmQuitarContasPagar()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            int cod;
            double valor;
            DateTime data;
            if (cbbParametro.Text == "Valor")
                if (!Double.TryParse(txtPesquisa.Text, out valor))
                    MessageBox.Show("Valor inválido para se pesquisar por valor.");
                else
                {
                    dt = ct.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                    dgvQuita.DataSource = dt;
                }
            if (cbbParametro.Text == "Data de vencimento")
                if (!DateTime.TryParse(txtPesquisa.Text, out data))
                    MessageBox.Show("Valor inválido para se pesquisar por data.");
                else
                {
                    dt = ct.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                    dgvQuita.DataSource = dt;
                }
            if (cbbParametro.Text == "Código")
                if (!Int32.TryParse(txtPesquisa.Text, out cod))
                    MessageBox.Show("Valor inválido para se pesquisar por código.");
                else
                {
                    dt = ct.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                    dgvQuita.DataSource = dt;
                }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            double a;
            if (!double.TryParse(txtValor.Text, out a) || dtpData.Value < Convert.ToDateTime("01/01/2010") || dgvQuita.SelectedRows == null)
                MessageBox.Show("Erro! Campo inválido");
            else
            {
                ct.setCodigo(Convert.ToInt32(dgvQuita.SelectedRows[0].Cells[0].Value));
                ct.setDtpagamento(dtpData.Value);
                ct.setValorpago(a);
                if (ct.Quita())
                    MessageBox.Show("Sucesso!!");
                else
                    MessageBox.Show("Erro! Verifique.");
            }
        }
    }
}
