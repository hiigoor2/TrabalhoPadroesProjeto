using Engenharia2.Classes;
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
    public partial class frmConsultaUsuario : Form
    {
        public int Codigo { get; set; }

        ctrUsuario control = new ctrUsuario();
        public frmConsultaUsuario()
        {
            InitializeComponent();
            cbbCriterio.SelectedIndex = 1;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = control.PopulaGrid(cbbCriterio.Text, txtPesquisa.Text);
            dgvUsuario.DataSource = dt;
        }

        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvUsuario.SelectedCells[0].Value);
            Close();
        }
    }
}
