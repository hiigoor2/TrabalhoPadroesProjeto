namespace Engenharia2.Forms
{
    partial class frmConsultaProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbCriterio = new System.Windows.Forms.ComboBox();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.PROD_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_PRECO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_MARCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_QTDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAT_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(398, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pesquisar por:";
            // 
            // cbbCriterio
            // 
            this.cbbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCriterio.FormattingEnabled = true;
            this.cbbCriterio.Location = new System.Drawing.Point(398, 40);
            this.cbbCriterio.Name = "cbbCriterio";
            this.cbbCriterio.Size = new System.Drawing.Size(183, 31);
            this.cbbCriterio.TabIndex = 2;
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROD_CODIGO,
            this.PROD_DESCRICAO,
            this.PROD_PRECO,
            this.PROD_MARCA,
            this.PROD_QTDE,
            this.CAT_DESCRICAO,
            this.prod_observacoes});
            this.dgvProduto.Location = new System.Drawing.Point(12, 79);
            this.dgvProduto.MultiSelect = false;
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduto.Size = new System.Drawing.Size(660, 569);
            this.dgvProduto.TabIndex = 9;
            this.dgvProduto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduto_CellDoubleClick);
            // 
            // PROD_CODIGO
            // 
            this.PROD_CODIGO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PROD_CODIGO.DataPropertyName = "prod_codigo";
            this.PROD_CODIGO.HeaderText = "Código";
            this.PROD_CODIGO.Name = "PROD_CODIGO";
            this.PROD_CODIGO.ReadOnly = true;
            this.PROD_CODIGO.Width = 81;
            // 
            // PROD_DESCRICAO
            // 
            this.PROD_DESCRICAO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PROD_DESCRICAO.DataPropertyName = "prod_descricao";
            this.PROD_DESCRICAO.HeaderText = "Descrição";
            this.PROD_DESCRICAO.Name = "PROD_DESCRICAO";
            this.PROD_DESCRICAO.ReadOnly = true;
            this.PROD_DESCRICAO.Width = 95;
            // 
            // PROD_PRECO
            // 
            this.PROD_PRECO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PROD_PRECO.DataPropertyName = "prod_preco";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.PROD_PRECO.DefaultCellStyle = dataGridViewCellStyle2;
            this.PROD_PRECO.HeaderText = "Preço";
            this.PROD_PRECO.Name = "PROD_PRECO";
            this.PROD_PRECO.ReadOnly = true;
            this.PROD_PRECO.Width = 71;
            // 
            // PROD_MARCA
            // 
            this.PROD_MARCA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PROD_MARCA.DataPropertyName = "prod_marca";
            this.PROD_MARCA.HeaderText = "Marca";
            this.PROD_MARCA.Name = "PROD_MARCA";
            this.PROD_MARCA.ReadOnly = true;
            this.PROD_MARCA.Width = 75;
            // 
            // PROD_QTDE
            // 
            this.PROD_QTDE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PROD_QTDE.DataPropertyName = "prod_qtde";
            this.PROD_QTDE.HeaderText = "Estoque";
            this.PROD_QTDE.Name = "PROD_QTDE";
            this.PROD_QTDE.ReadOnly = true;
            this.PROD_QTDE.Width = 86;
            // 
            // CAT_DESCRICAO
            // 
            this.CAT_DESCRICAO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CAT_DESCRICAO.DataPropertyName = "cat_codigo";
            this.CAT_DESCRICAO.HeaderText = "Categoria";
            this.CAT_DESCRICAO.Name = "CAT_DESCRICAO";
            this.CAT_DESCRICAO.ReadOnly = true;
            this.CAT_DESCRICAO.Width = 96;
            // 
            // prod_observacoes
            // 
            this.prod_observacoes.DataPropertyName = "prod_observacoes";
            this.prod_observacoes.HeaderText = "Observações";
            this.prod_observacoes.Name = "prod_observacoes";
            this.prod_observacoes.ReadOnly = true;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Location = new System.Drawing.Point(587, 40);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisa.TabIndex = 3;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Digite o que deseja pesquisar:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(12, 40);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(380, 32);
            this.txtPesquisa.TabIndex = 1;
            // 
            // frmConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbCriterio);
            this.Controls.Add(this.dgvProduto);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesquisa);
            this.Font = new System.Drawing.Font("Myanmar Text", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar produto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbCriterio;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_PRECO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_MARCA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_QTDE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAT_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_observacoes;
    }
}