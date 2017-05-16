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
    public partial class frmEsqueceuSenha : Form
    {
        ctrUsuario control = new ctrUsuario();

        public frmEsqueceuSenha()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (control.RecuperaDados(txtLog.Text))
            {
                lblPergunta.Text = control.getPergunta() + "";
                lblPergunta.Visible = true;
                txtResposta.Visible = true;
                btnConfirma.Visible = true;
            }
            else
            {
                lblErro.Text = "Usuário não encontrado!";
                lblErro.Visible = true;
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (control.getResposta().Equals(txtResposta.Text))
            {
                MessageBox.Show("Sua senha é: " + control.getSenha());
            }
            else
            {
                lblErro.Text = "Resposta secreta não confere";
                lblErro.Visible = true;
            }
        }
    }
}