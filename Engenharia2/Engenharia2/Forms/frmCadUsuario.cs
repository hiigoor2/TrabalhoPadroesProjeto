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
    public partial class frmCadUsuario : Form
    {
        ctrUsuario control = new ctrUsuario();
        int UserAtual;
        public frmCadUsuario(int cod)
        {
            InitializeComponent();
            EstadoCamposInicial();
            EstadoBotoesInicial();
            UserAtual = cod;
            if (cod == 1)
            {
                btnAltera.Enabled = false;
                btnGrava.Enabled = true;
                btnNovo.Enabled = false;
                btnExclui.Enabled = false;
                btnCancela.Enabled = true;
                HabilitaCampos();
                int aux = 1;
                control.setUsu(aux, "", "", "", "", 0, "", "", "", "");
                control.RecuperaDados();
                txtCodigo.Text = "" + aux;
                txtCPF.Text = control.getCpf();
                txtEndereco.Text = control.getEndereco();
                txtLogin.Text = control.getLogin();
                txtNome.Text = control.getNome();
                txtPergunta.Text = control.getPergunta();
                txtResposta.Text = control.getResposta();
                txtSenha.Text = control.getSenha();
                txtTelefone.Text = control.getTelefone();
                if (control.getNivel() == 1)
                    cbbNivel.SelectedIndex = 0;
                else
                    cbbNivel.SelectedIndex = 1;
            }
        }

        public void EstadoBotoesInicial()
        {
            btnNovo.Enabled = true;
            btnAltera.Enabled = true;
            btnGrava.Enabled = false;
            btnExclui.Enabled = true;
            btnCancela.Enabled = false;
        }

        public void EstadoCamposInicial()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtPergunta.Text = "";
            txtResposta.Text = "";

            txtNome.ReadOnly = true;
            txtCPF.ReadOnly = true;
            txtTelefone.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            txtLogin.ReadOnly = true;
            txtSenha.ReadOnly = true;
            txtPergunta.ReadOnly = true;
            txtResposta.ReadOnly = true;
            cbbNivel.Enabled = false;
            cbbNivel.SelectedIndex = 0;
        }

        public void HabilitaCampos()
        {
            txtNome.ReadOnly = false;
            txtCPF.ReadOnly = false;
            txtTelefone.ReadOnly = false;
            txtEndereco.ReadOnly = false;
            txtLogin.ReadOnly = false;
            txtSenha.ReadOnly = false;
            txtPergunta.ReadOnly = false;
            txtResposta.ReadOnly = false;
            cbbNivel.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitaCampos();
            btnGrava.Enabled = true;
            btnCancela.Enabled = true;
            btnExclui.Enabled = false;
            btnAltera.Enabled = false;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            EstadoBotoesInicial();
            EstadoCamposInicial();
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            int aux;
            btnAltera.Enabled = false;
            btnGrava.Enabled = true;
            btnNovo.Enabled = false;
            btnExclui.Enabled = false;
            btnCancela.Enabled = true;
            HabilitaCampos();
            frmConsultaUsuario form = new frmConsultaUsuario();
            form.ShowDialog();
            aux = form.Codigo;
            if (aux != 0)
            {
                control.setUsu(aux, "", "", "", "", 0, "", "", "", "");
                control.RecuperaDados();
                txtCodigo.Text = "" + aux;
                txtCPF.Text = control.getCpf();
                txtEndereco.Text = control.getEndereco();
                txtLogin.Text = control.getLogin();
                txtNome.Text = control.getNome();
                txtPergunta.Text = control.getPergunta();
                txtResposta.Text = control.getResposta();
                txtSenha.Text = control.getSenha();
                txtTelefone.Text = control.getTelefone();
                if (control.getNivel() == 1)
                    cbbNivel.SelectedIndex = 0;
                else
                    cbbNivel.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Nenhum usuário selecionado!");
                EstadoCamposInicial();
                EstadoBotoesInicial();
            }
        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            int aux = 0;
            btnExclui.Enabled = false;
            btnNovo.Enabled = false;
            btnAltera.Enabled = false;
            frmConsultaUsuario form = new frmConsultaUsuario();
            form.ShowDialog();
            aux = form.Codigo;
            txtCodigo.Text = "" + aux;
            control.setUsu(aux, "", "", "", "", 0, "", "", "", "");
            control.RecuperaDados();
            txtCodigo.Text = "" + aux;
            txtCPF.Text = control.getCpf();
            txtEndereco.Text = control.getEndereco();
            txtLogin.Text = control.getLogin();
            txtNome.Text = control.getNome();
            txtPergunta.Text = control.getPergunta();
            txtResposta.Text = control.getResposta();
            txtSenha.Text = control.getSenha();
            txtTelefone.Text = control.getTelefone();
            if (MessageBox.Show("Tem certeza que deseja excluir esse usuário?", "Confirma Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (aux != UserAtual)
                    control.Excluir();
                else
                    MessageBox.Show("Não é possivel excluir o administrador atual!");
            EstadoBotoesInicial();
            EstadoCamposInicial();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string msg = control.PreparaDados(txtCodigo.Text, txtLogin.Text, txtSenha.Text, txtNome.Text, txtEndereco.Text, cbbNivel.Text, txtTelefone.Text, txtCPF.Text, txtPergunta.Text, txtResposta.Text);
            if (txtNome.Text == "" || txtLogin.Text == "" || txtSenha.Text == "" || txtPergunta.Text == "" || txtResposta.Text == "")
                msg = msg + "\nCampo obrigatório em branco";
            if (msg == "")
            {
                if (txtCodigo.Text != "")
                    control.Alterar();
                else
                    control.Inserir();
                EstadoBotoesInicial();
                EstadoCamposInicial();
            }
            else
                MessageBox.Show(msg);
        }
    }
}