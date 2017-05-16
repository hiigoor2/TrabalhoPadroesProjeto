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
    public partial class frmCadProduto : Form
    {
        private ctrProduto produto;

        public frmCadProduto()
        {
            InitializeComponent();
            produto = new ctrProduto();
            preencheCb();
            cbCategoria.SelectedIndex = -1;
            estados(0);
        }

        public void preencheCb()
        {
            DataTable dt = new ctrCategoria().lista();
            cbCategoria.DataSource = dt;
            cbCategoria.DisplayMember = "CAT_DESCRICAO";
            cbCategoria.ValueMember = "CAT_CODIGO";
        }

        public void limparCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtEstoque.Text = "";
            txtMarca.Text = "";
            txtObs.Text = "";
            txtPreco.Text = "";
            cbCategoria.SelectedIndex = -1;
        }

        public void preencherDados()
        {
            int auxCod = 0;
            try
            {
                auxCod = Convert.ToInt32(txtCodigo.Text);
            }
            catch (Exception)
            {

            }
            produto.setCodigo(auxCod+"");
            produto.setDescricao(txtDescricao.Text);
            produto.setCategoria(cbCategoria.SelectedValue+"");
            produto.setMarca(txtMarca.Text.Trim());
            produto.setObservacao(txtObs.Text.Trim());
            produto.setPreco(txtPreco.Text.Replace("R$","").Trim());
            produto.setQuantidade(txtEstoque.Text.Trim());
        }

        public void carregaCampos()
        {
            txtCodigo.Text = produto.getCodigo()+"";
            txtDescricao.Text = produto.getDescricao() + "";
            txtEstoque.Text = produto.getQuantidade() + "";
            txtMarca.Text = produto.getMarca() + "";
            txtObs.Text = produto.getObservacao() + "";
            txtPreco.Text = String.Format("{0:C2}",produto.getPreco() + "");
            cbCategoria.SelectedValue = produto.getCategoria();
        }

        public void estados(int i)
        {
            switch (i)
            {
                case 0://default
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = false;
                    txtEstoque.Enabled = false;
                    txtMarca.Enabled = false;
                    txtObs.Enabled = false;
                    txtPreco.Enabled = false;
                    cbCategoria.Enabled = false;

                    btnAltera.Enabled = false;
                    btnCancela.Enabled = false;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = false;
                    btnNovo.Enabled = true;
                    break;
                case 1://visualizando
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = false;
                    txtEstoque.Enabled = false;
                    txtMarca.Enabled = false;
                    txtObs.Enabled = false;
                    txtPreco.Enabled = false;
                    cbCategoria.Enabled = false;
                    btnAltera.Enabled = true;
                    btnCancela.Enabled = true;
                    btnExclui.Enabled = true;
                    btnGrava.Enabled = false;
                    btnNovo.Enabled = false;
                    break;
                case 2://inserindo
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = true;
                    txtEstoque.Enabled = true;
                    txtMarca.Enabled = true;
                    txtObs.Enabled = true;
                    txtPreco.Enabled = true;
                    cbCategoria.Enabled = true;
                    btnAltera.Enabled = false;
                    btnCancela.Enabled = true;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = true;
                    btnNovo.Enabled = false;
                    break;
                case 3://alterando
                    txtCodigo.Enabled = false;
                    txtDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    txtEstoque.Enabled = true;
                    txtMarca.Enabled = true;
                    txtObs.Enabled = true;
                    txtPreco.Enabled = true;
                    cbCategoria.Enabled = true;
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
            if (produto.getCategoria() > 0 && produto.getDescricao().Length > 0 && produto.getMarca().Length > 0 && produto.getPreco() > 0 && produto.getQuantidade() > 0)
            {
                if (produto.Gravar() > 0)
                {
                    MessageBox.Show("Gravado com sucesso!", "Mensagem", MessageBoxButtons.OK);
                    limparCampos();
                    estados(0);
                }
                else
                {
                    MessageBox.Show("Não foi possivel gravar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            preencherDados();
            if (produto.getCodigo() > 0)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir este produto?", "Confirma Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    produto.Delete();
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
            frmConsultaProduto f = new frmConsultaProduto();
            f.ShowDialog();
            auxCod = f.Codigo;
            estados(1);
            limparCampos();
            produto = new ctrProduto();
            produto.setCodigo(auxCod+"");
            produto.Select();
            carregaCampos();
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {
            Decimal aux = 0;
            try
            {
                aux = Convert.ToDecimal(Convert.ToDecimal(txtPreco.Text.Replace("R$", "").Trim().ToString()));
                if (aux < 0)
                {
                    aux = 0;
                    MessageBox.Show("Valor inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Valor inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtPreco.Text = string.Format("{0:c2}", aux);
        }

        private void txtEstoque_Leave(object sender, EventArgs e)
        {
            int aux = 0;
            try
            {
                aux = Convert.ToInt32(txtEstoque.Text.Trim());
                if (aux < 0)
                {
                    aux = 0;
                    MessageBox.Show("Valor inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Valor inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtEstoque.Text = aux + "";
        }
    }
}