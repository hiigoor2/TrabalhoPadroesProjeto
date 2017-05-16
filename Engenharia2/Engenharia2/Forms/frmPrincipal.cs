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
    public partial class frmPrincipal : Form
    {
        int UserAtual;
        private ctrEmpresa emp;
        public frmPrincipal(int codigo)
        {
            InitializeComponent();
            ctrUsuario control = new ctrUsuario();
            control.setUsu(codigo,"","","","",0,"","","","");
            control.RecuperaDados();
            UserAtual = codigo;
            if (control.getNivel() == 1)
            {
                menuStrip1.Visible = true;
                menuStrip2.Visible = false;
            }
            else
            {
                menuStrip2.Visible = true;
                menuStrip1.Visible = false;
            }
            emp = new ctrEmpresa();
            emp.Select();
            if (emp.getCodigo() == 0)
            {
                frmCadEmpresa f = new frmCadEmpresa();
                bool sair = false;
                do
                {
                    if (MessageBox.Show("Empresa não cadastrada!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        f.ShowDialog();
                    else
                    {
                        sair = true;
                        this.Close();
                    }
                } while (!f.Cadastro && !sair);
            }
        }

        private void btSair(object sender, EventArgs e)
        {
            Close();
        }

        private void btCadUsuario(object sender, EventArgs e)
        {
            frmCadUsuario f = new frmCadUsuario(UserAtual);
            f.ShowDialog();
        }
        private void btConsultaUsuario(object sender, EventArgs e)
        {
            frmConsultaUsuario f = new frmConsultaUsuario();
            f.ShowDialog();
        }
        private void btCadProduto(object sender, EventArgs e)
        {
            frmCadProduto f = new frmCadProduto();
            f.ShowDialog();
        }
        private void btConsultaProduto(object sender, EventArgs e)
        {
            frmConsultaProduto f = new frmConsultaProduto();
            f.ShowDialog();
        }
        private void btCadCategoria(object sender, EventArgs e)
        {
            frmCadCategoria f = new frmCadCategoria();
            f.ShowDialog();
        }
        private void btConsultaCategoria(object sender, EventArgs e)
        {
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
        }
        private void btEmpresa(object sender, EventArgs e)
        {
            frmCadEmpresa f = new frmCadEmpresa();
            f.ShowDialog();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovCompra f = new frmMovCompra();
            f.ShowDialog();
        }

        private void agendamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovAgendamento f = new frmMovAgendamento();
            f.ShowDialog();
        }

        private void quitarContasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuitarContasPagar f = new frmQuitarContasPagar();
            f.ShowDialog();
        }
    }
}