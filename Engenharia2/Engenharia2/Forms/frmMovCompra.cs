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
    public partial class frmMovCompra : Form
    {
        ctrCompra com = new ctrCompra();
        DataTable dt = new DataTable();
        public frmMovCompra()
        {
            InitializeComponent();
            estados(0);

            cbbFornecedor.DataSource = com.FornList();
            cbbFornecedor.DisplayMember = "FOR_NOME";
            cbbFornecedor.ValueMember = "FOR_CODIGO";

            dt.Columns.Add("Código Compra");
            dt.Columns.Add("Código Produto");
            dt.Columns.Add("Descrição");
            dt.Columns.Add("Quantidade");
            dt.Columns.Add("Preço");
        }

        public void preencherDados()
        {
            try { com.setCodigo(Convert.ToInt32(txtCod.Text)); } catch { }
            try { com.setValor(Convert.ToInt32(lblTotal.Text)); } catch { }
            com.setFormaPgto(cbbFormaPgto.SelectedItem + "");
            try { com.setData(txtData.Value); } catch { };
            try { com.setNumParc(Convert.ToInt32(txtNumParc.Text)); } catch { }
            com.setObs(txtObs.Text.Trim());
            try { com.setFornecedor(Convert.ToInt32(cbbFornecedor.SelectedValue)); } catch { }
            for (int i = 0; i < dt.Rows.Count; i++)
                com.setInsereLista(Convert.ToInt32(dt.Rows[i]["Código Compra"]), Convert.ToInt32(dt.Rows[i]["Código Produto"]), Convert.ToInt32(dt.Rows[i]["Quantidade"]), Convert.ToDouble(dt.Rows[i]["Preço"]));

        }

        public void limparCampos()
        {
            txtCod.Text = "";
            txtData.Text = "";
            txtNumParc.Text = "";
            txtObs.Text = "";
            txtPreco.Text = "";
            txtQtde.Text = "";
            cbbFornecedor.SelectedIndex = 0;
            cbbFormaPgto.SelectedIndex = 0;
            txtBusca.Text = "";
            lblTotal.Text = "00.00";
            dt.Rows.Clear();
        }

        private void carregaCampos()
        {
            txtCod.Text = com.getCodigo() + "";
            lblTotal.Text = com.getValor()+"";
            cbbFormaPgto.SelectedText = com.getFormaPgto() + "";
            txtNumParc.Text = com.getNumParc() + "";
            txtObs.Text = com.getObs() + "";
            txtData.Text = com.getData()+ "";
            cbbFornecedor.SelectedValue = com.getFornecedor();
        }

        private void estados(int i)
        {
            switch (i)
            {
                case 0://default
                    txtCod.Enabled = false;
                    cbbFormaPgto.Enabled = false;
                    txtNumParc.Enabled = false;
                    txtData.Enabled = false;
                    txtObs.Enabled = false;
                    txtPreco.Enabled = false;
                    txtQtde.Enabled = false;
                    cbbFornecedor.Enabled = false;

                    btnBusca.Enabled = false;
                    btnCancela.Enabled = false;
                    btnExclui.Enabled = true;
                    btnGrava.Enabled = false;
                    btnNovo.Enabled = true;
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    break;

                case 2://inserindo
                    txtCod.Enabled = false;
                    cbbFormaPgto.Enabled = true;
                    txtNumParc.Enabled = true;
                    txtData.Enabled = true;
                    txtObs.Enabled = true;
                    txtPreco.Enabled = true;
                    txtQtde.Enabled = true;
                    cbbFornecedor.Enabled = true;

                    btnBusca.Enabled = true;
                    btnCancela.Enabled = true;
                    btnExclui.Enabled = false;
                    btnGrava.Enabled = true;
                    btnNovo.Enabled = false;
                    btnAdd.Enabled = true;
                    btnRemove.Enabled = true;
                    break;
            }
        }

        private bool AlteraQtde(int cod)
        {
            int aux, qtd, nqtd;
            double preco, precounit;
            Int32.TryParse(txtQtde.Text, out qtd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Int32.TryParse(dt.Rows[i][1].ToString(), out aux);
                Double.TryParse(dt.Rows[i]["Preço"].ToString(), out precounit);
                Int32.TryParse(dt.Rows[i]["Quantidade"].ToString(), out nqtd);
                if (aux == cod)
                {
                    nqtd = nqtd + qtd;
                    if (txtPreco.Text == "")
                    {
                        dt.Rows[i]["Quantidade"] = nqtd;
                        preco = Convert.ToDouble(lblTotal.Text) + (qtd * precounit);
                        lblTotal.Text = preco + "";
                    }
                    else
                        MessageBox.Show("Não é possivel inserir o mesmo produto com preços diferentes. Favor deixar o campo Preço em branco!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int cod;
            if (dgvProdutos.SelectedRows == null || txtQtde.Text == "")
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Int32.TryParse(dgvProdutos.SelectedCells[0].Value+"", out cod);
                if (!AlteraQtde(cod))
                {
                    if (txtPreco.Text == "")
                        MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        dt.Rows.Add(0, dgvProdutos.SelectedCells[0].Value, dgvProdutos.SelectedCells[1].Value, txtQtde.Text, txtPreco.Text);
                        dgvItens.DataSource = dt;
                        double aux = Convert.ToDouble(lblTotal.Text) + (Convert.ToDouble(txtPreco.Text) * Convert.ToDouble(txtQtde.Text));
                        lblTotal.Text = "" + aux;
                    }
                }
                txtPreco.Text = "";
                txtQtde.Text = "";
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            estados(2);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            preencherDados();
            if (com.getFormaPgto().Length > 0 && com.getNumParc() > 0 && com.getData() !=null && com.getFornecedor() > 0 && com.getLista().Count > 0)
            {
                string s = cbbFornecedor.Text;
                if (com.Gravar())
                {                    
                    limparCampos();
                    estados(0);
                    frmGeraContasPagar f = new frmGeraContasPagar(com.getCodigo(), Convert.ToDouble(com.getValor()), com.getData(), s, com.getNumParc());
                    f.ShowDialog();
                    com = new ctrCompra();
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
            frmConsultaCompra f = new frmConsultaCompra();
            f.ShowDialog();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            limparCampos();
            estados(0);
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = com.ProdList(txtBusca.Text);
            dgvProdutos.DataSource = dt;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            double aux = Convert.ToDouble(lblTotal.Text) - (Convert.ToDouble(dgvItens.SelectedCells[3].Value) * Convert.ToDouble(dgvItens.SelectedCells[4].Value));
            dt.Rows.RemoveAt(dgvItens.SelectedCells[0].RowIndex);
            lblTotal.Text = aux + "";
        }
    }
}