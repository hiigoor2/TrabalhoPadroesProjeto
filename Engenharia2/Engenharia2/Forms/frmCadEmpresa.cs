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
    public partial class frmCadEmpresa : Form
    {
        public Boolean Cadastro;
        private ctrEmpresa empresa;

        public frmCadEmpresa()
        {
            InitializeComponent();
            empresa = new ctrEmpresa();
            empresa.Select();
            carregaCampos();
            if (empresa.getCodigo() > 0)
            {
                estados(0);
            }
            else
            {
                estados(3);
            }
        }

        public void limparCampos()
        {
            txtCodigo.Text = "";
            txtBairro.Text = "";
            txtCNPJ.Text = "";
            txtComplemento.Text = "";
            txtNomeF.Text = "";
            txtNumero.Text = "";
            txtRazao.Text = "";
            txtRua.Text = "";
            pbLogo.Image = null;
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
            empresa.setBairro(txtBairro.Text.Trim());
            empresa.setCnpj(txtCNPJ.Text.Trim());
            empresa.setCodigo(auxCod);
            empresa.setComplemento(txtComplemento.Text.Trim());

            empresa.setNomeFantasia(txtNomeF.Text.Trim());
            empresa.setNumero(txtNumero.Text.Trim());
            empresa.setRazao(txtRazao.Text.Trim());
            empresa.setRua(txtRua.Text.Trim());
            
        }

        public void carregaCampos()
        {
            if (empresa.getCodigo() == 0)
                txtCodigo.Text = "";
            else
                txtCodigo.Text = empresa.getCodigo()+"";
            txtBairro.Text = empresa.getBairro();
            txtCNPJ.Text = empresa.getCnpj();
            txtComplemento.Text = empresa.getComplemento();
            txtNomeF.Text = empresa.getNomeFantasia();
            if (empresa.getNumero() == 0)
                txtNumero.Text = "";
            else
                txtNumero.Text = empresa.getNumero() + "";
            txtRazao.Text = empresa.getRazao();
            txtRua.Text = empresa.getRua();
            pbLogo.ImageLocation = empresa.getLogo();
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void estados(int i)
        {
            switch (i)
            {
                case 0://default
                    txtCodigo.Enabled = false;
                    txtBairro.Enabled = false;
                    txtCNPJ.Enabled = false;
                    txtComplemento.Enabled = false;
                    txtNomeF.Enabled = false;
                    txtNumero.Enabled = false;
                    txtRazao.Enabled = false;
                    txtRua.Enabled = false;

                    //botões
                    btSelecionar.Enabled = false;

                    btnAltera.Enabled = true;
                    btnCancela.Enabled = false;
                    btnGrava.Enabled = false;
                    break;
                case 1://visualizando
                    txtCodigo.Enabled = false;
                    txtBairro.Enabled = false;
                    txtCNPJ.Enabled = false;
                    txtComplemento.Enabled = false;
                    txtNomeF.Enabled = false;
                    txtNumero.Enabled = false;
                    txtRazao.Enabled = false;
                    txtRua.Enabled = false;

                    //botões
                    btSelecionar.Enabled = false;
                    btnAltera.Enabled = true;
                    btnCancela.Enabled = true;
                    btnGrava.Enabled = true;
                    break;
                case 3://alterando
                    txtCodigo.Enabled = false;
                    txtBairro.Enabled = true;
                    txtCNPJ.Enabled = true;
                    txtComplemento.Enabled = true;
                    txtNomeF.Enabled = true;
                    txtNumero.Enabled = true;
                    txtRazao.Enabled = true;
                    txtRua.Enabled = true;

                    //botões
                    btSelecionar.Enabled = true;
                    btnAltera.Enabled = false;
                    btnCancela.Enabled = true;
                    btnGrava.Enabled = true;
                    break;
            }
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                preencherDados();
                if (empresa.getBairro().Length > 0 && empresa.getCnpj().Length > 0 && empresa.getNumero() >= 0 && empresa.getRazao().Length > 0) {
                    if (empresa.Gravar() > 0)
                    {
                        Cadastro = true;
                        MessageBox.Show("Gravado com sucesso!", "Mensagem", MessageBoxButtons.OK);
                        //limparCampos();
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
            catch(Exception) {
                MessageBox.Show("Não foi possivel gravar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            FileDialog.Filter = "jpeg (*.jpeg)|*.jpeg|jpg (*.jpg)|*.jpg|png (*.png)|*.png|Todos os arquivos (*.*)|*.*";
            FileDialog.ShowDialog();
            pbLogo.Image = Image.FromFile(FileDialog.FileName);
            Image i = Image.FromFile(FileDialog.FileName);
            string nomeArq = FileDialog.SafeFileName;
            string[] partes = nomeArq.Split('.');
            nomeArq = "D:\\Logos\\LogoEmpresa." + partes[partes.Length-1];
            i.Save(nomeArq);
            empresa.setLogo(nomeArq);
            //salvar o caminho acima no banco
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            empresa.Select();
            estados(3);
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            estados(0);
        }
    }
}
