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
    public partial class frmCadCategoria : Form
    {
        private ctrCategoria categoria;

        public frmCadCategoria()
        {
            InitializeComponent();
            categoria = new ctrCategoria();
            estados(0);
        }

        public void limparCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
        }

        public void preencherDados()
        {
            int auxCod=0;
            try
            {
                auxCod = Convert.ToInt32(txtCodigo.Text);
            }
            catch (Exception) {
                
            }
            categoria.setCodigo(auxCod);
            categoria.setDescricao(txtDescricao.Text);
        }

        public void carregaCampos()
        {
            txtCodigo.Text = categoria.getCodigo()+"";
            txtDescricao.Text = categoria.getDescricao();
        }

        public void estados(int i)
        {
            switch (i)
            {
                case 0://default
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = false;
                    btnAltera.Enabled = false;
                    btnCancela.Enabled = false;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = false;
                    btnNovo.Enabled = true;
                    break;
                case 1://visualizando
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = false;
                    btnAltera.Enabled = true;
                    btnCancela.Enabled = true;
                    btnExclui.Enabled = true;
                    btnGrava.Enabled = true;
                    btnNovo.Enabled = false;
                    break;
                case 2://inserindo
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = true;
                    btnAltera.Enabled = false;
                    btnCancela.Enabled = true;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = true;
                    btnNovo.Enabled = false;
                    break;
                case 3://alterando
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = true;
                    btnAltera.Enabled = false;
                    btnCancela.Enabled = true;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = true;
                    btnNovo.Enabled = false;
                    break;
            }
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
            if (categoria.getDescricao() != null && categoria.getDescricao().Length > 0)
            {
                categoria.gravar();
                MessageBox.Show("Gravado com sucesso!","Mensagem",MessageBoxButtons.OK);
                limparCampos();
                estados(0);
            }else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            preencherDados();
            if (categoria.getCodigo() > 0)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir esta categoria?", "Confirma Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    categoria.delete();
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

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int auxCod = 0;
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            auxCod = f.Codigo;
            estados(1);
            limparCampos();
            categoria = new ctrCategoria();
            categoria.setCodigo(auxCod);
            categoria.select();
            carregaCampos();
        }
    }
}
