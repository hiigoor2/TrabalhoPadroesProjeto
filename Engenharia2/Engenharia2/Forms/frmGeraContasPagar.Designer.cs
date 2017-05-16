namespace Engenharia2.Forms
{
    partial class frmGeraContasPagar
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
            this.dtpDataVenc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataCria = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGera = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpDataVenc
            // 
            this.dtpDataVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVenc.Location = new System.Drawing.Point(12, 37);
            this.dtpDataVenc.Name = "dtpDataVenc";
            this.dtpDataVenc.Size = new System.Drawing.Size(105, 32);
            this.dtpDataVenc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data de Vencimento *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(553, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Data de Criação *";
            // 
            // dtpDataCria
            // 
            this.dtpDataCria.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataCria.Location = new System.Drawing.Point(567, 37);
            this.dtpDataCria.Name = "dtpDataCria";
            this.dtpDataCria.Size = new System.Drawing.Size(105, 32);
            this.dtpDataCria.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(553, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Valor *";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(12, 111);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(105, 32);
            this.txtDescricao.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Descrição *";
            // 
            // btnGera
            // 
            this.btnGera.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold);
            this.btnGera.Location = new System.Drawing.Point(301, 222);
            this.btnGera.Name = "btnGera";
            this.btnGera.Size = new System.Drawing.Size(82, 27);
            this.btnGera.TabIndex = 5;
            this.btnGera.Text = "Gerar";
            this.btnGera.UseVisualStyleBackColor = true;
            this.btnGera.Click += new System.EventHandler(this.btnGera_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(567, 111);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(105, 32);
            this.txtValor.TabIndex = 18;
            // 
            // frmGeraContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnGera);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDataCria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDataVenc);
            this.Font = new System.Drawing.Font("Myanmar Text", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeraContasPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Contas a Pagar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpDataVenc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataCria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGera;
        private System.Windows.Forms.TextBox txtValor;
    }
}