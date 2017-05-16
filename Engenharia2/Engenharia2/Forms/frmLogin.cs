using Engenharia2.Classes;
using Engenharia2.Classes.Controladoras;
using Engenharia2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engenharia2
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            ctrUsuario control = new ctrUsuario();
            if (control.RecuperaDados(txtUsuario.Text, txtSenha.Text))
            {
                if (control.getLogin() == "admin" && control.getSenha() == "admin")
                {
                    MessageBox.Show("Login padrão identificado. Favor criar um usuário");
                    frmCadUsuario form = new frmCadUsuario(control.getCodigo());
                    form.ShowDialog();
                    //Dispose();
                    Close();
                }
                else
                {
                    frmPrincipal form = new frmPrincipal(control.getCodigo());
                    if (!form.IsDisposed)
                    {
                        form.ShowDialog();
                    }
                    //Dispose();
                    Close();
                }
            }
            else
            {
                lblErro.Text = "Erro! Dados incorretos";
                lblErro.Visible = true;
            }
        }

        private void linkEsqueceu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEsqueceuSenha form = new frmEsqueceuSenha();
            form.ShowDialog();
        }
    }
}