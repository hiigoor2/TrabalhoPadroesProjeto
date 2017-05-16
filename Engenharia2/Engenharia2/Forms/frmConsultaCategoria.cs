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
    public partial class frmConsultaCategoria : Form
    {
        public Int32 Codigo;
        private ctrCategoria cat;

        public frmConsultaCategoria()
        {
            InitializeComponent();
            Codigo = 0;
            cat = new ctrCategoria();
            preencherCriterio();   
        }

        private void preencherCriterio()
        {
            cbbCriterio.Items.Add("Descrição");
            cbbCriterio.Items.Add("Código");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            cat = new ctrCategoria();
            switch (cbbCriterio.Text)
            {
                case "Descrição":
                    cat.setDescricao(txtPesquisa.Text.Trim());
                    break;
                case "Código":
                    try
                    {
                        cat.setCodigo(Convert.ToInt32(txtPesquisa.Text.Trim()));
                    }
                    catch { }
                    break;
            }
                    dgvProduto.DataSource = cat.lista();
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value);
            this.Close();
        }
    }
}
