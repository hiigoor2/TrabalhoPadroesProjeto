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
    public partial class frmConsultaCompra : Form
    {
        ctrCompra com = new ctrCompra();
        DataTable dt = new DataTable();
        public frmConsultaCompra()
        {
            InitializeComponent();
            cbbParametro.SelectedIndex = 0;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            int cod;
            double valor;
            DateTime data;
            if (cbbParametro.Text == "Valor")
                if (!Double.TryParse(txtPesquisa.Text, out valor))
                    MessageBox.Show("Valor inválido para se pesquisar por valor total.");
                else
                {
                    dt = com.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                    dgvCompra.DataSource = dt;
                }
            if (cbbParametro.Text == "Data")
                if (!DateTime.TryParse(txtPesquisa.Text, out data))
                    MessageBox.Show("Valor inválido para se pesquisar por data.");
                else
                {
                    dt = com.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                    dgvCompra.DataSource = dt;
                }
            if (cbbParametro.Text == "Código")
               if (!Int32.TryParse(txtPesquisa.Text, out cod))
                   MessageBox.Show("Valor inválido para se pesquisar por código.");
              else
             {
                dt = com.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                dgvCompra.DataSource = dt;
             }
        }

        public void preencherDados()
        {
            try { com.setCodigo(Convert.ToInt32(dgvCompra.SelectedRows[0].Cells[0].Value)); } catch { }
        }

        private void dgvCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            preencherDados();
            if (com.getCodigo() > 0)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir esta Compra?", "Confirma Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (com.Delete())
                    {
                        MessageBox.Show("Sucesso!!");
                        dgvCompra.DataSource = com.PopulaGrid(cbbParametro.Text, txtPesquisa.Text);
                    }
                    else
                        MessageBox.Show("Erro! Verifique.");
                }
            }
        }
    }
}
