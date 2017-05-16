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
    public partial class frmConsultaProduto : Form
    {
        public Int32 Codigo;
        private ctrProduto produto;

        public frmConsultaProduto()
        {
            InitializeComponent();
            cbbCriterio.Items.Add("Descrição");
            cbbCriterio.Items.Add("Código");
            cbbCriterio.Items.Add("Marca");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            produto = new ctrProduto();
            switch (cbbCriterio.Text)
            {
                case "Descrição":
                    produto.setDescricao(txtPesquisa.Text.Trim());
                    break;
                case "Código":
                    produto.setCodigo(txtPesquisa.Text.Trim());
                    break;
                case "Marca":
                    produto.setMarca(txtPesquisa.Text.Trim());
                    break;
            }
            dt = produto.List();
            dgvProduto.DataSource = dt;
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value);
            this.Close();
        }
    }
}
