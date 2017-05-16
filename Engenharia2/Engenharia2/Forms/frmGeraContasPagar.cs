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
    public partial class frmGeraContasPagar : Form
    {
        ctrContasPagar con = new ctrContasPagar();
        int CodCompra, NumParc;
        
        public frmGeraContasPagar(int cod, double valor, DateTime data, string forn, int numparc)
        {
            InitializeComponent();
            CodCompra = cod;
            txtValor.Text = (valor/numparc)+"";
            dtpDataCria.Value = data;
            dtpDataVenc.Value = data.AddMonths(1);
            txtDescricao.Text = forn;
            NumParc = numparc;
        }

        private void preencheCampos()
        {
            con = new ctrContasPagar(0, txtDescricao.Text, dtpDataVenc.Value, dtpDataCria.Value, DateTime.MinValue, Convert.ToDouble(txtValor.Text),0,CodCompra);
        }

        private void btnGera_Click(object sender, EventArgs e)
        {
            double a;
            if (txtDescricao.Text == "" || !Double.TryParse(txtValor.Text, out a) || DateTime.MinValue == dtpDataCria.Value || DateTime.MinValue == dtpDataVenc.Value)
                MessageBox.Show("Campo obrigatório inválido");
            else
            {
                preencheCampos();
                if (NumParc > 1)
                {
                    if (MessageBox.Show("Fazendo isso você não estará gerando apenas uma parcela, deseja prosseguir?", "Confirma Geração", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (con.Insere(NumParc))
                            MessageBox.Show("Sucesso!!");
                        else
                            MessageBox.Show("Erro! Verifique.");
                    }
                    else
                    {
                        if (con.Insere(NumParc))
                            MessageBox.Show("Sucesso!!");
                        else
                            MessageBox.Show("Erro! Verifique.");
                    }
                }
            }
        }
    }
}
