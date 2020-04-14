namespace LojaCL {
    partial class FrmCrudCartao {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( ) {
            this.dgvCartaoVenda = new System.Windows.Forms.DataGridView();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtIdCartao = new System.Windows.Forms.TextBox();
            this.lblCartao = new System.Windows.Forms.Label();
            this.btnCadastro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartaoVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCartaoVenda
            // 
            this.dgvCartaoVenda.AllowUserToAddRows = false;
            this.dgvCartaoVenda.AllowUserToDeleteRows = false;
            this.dgvCartaoVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartaoVenda.Location = new System.Drawing.Point(12, 197);
            this.dgvCartaoVenda.Name = "dgvCartaoVenda";
            this.dgvCartaoVenda.ReadOnly = true;
            this.dgvCartaoVenda.Size = new System.Drawing.Size(423, 150);
            this.dgvCartaoVenda.TabIndex = 31;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Location = new System.Drawing.Point(197, 13);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisa.TabIndex = 30;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(350, 102);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 29;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(350, 73);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 28;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(350, 44);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(78, 80);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(194, 20);
            this.txtUsuario.TabIndex = 24;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(60, 47);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(212, 20);
            this.txtNumero.TabIndex = 23;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(19, 87);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 20;
            this.lblUsuario.Text = "Usuário";
            // 
            // lblNome
            // 
            this.lblNome.AutoEllipsis = true;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(19, 49);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(44, 13);
            this.lblNome.TabIndex = 19;
            this.lblNome.Text = "Numero";
            // 
            // txtIdCartao
            // 
            this.txtIdCartao.Location = new System.Drawing.Point(60, 13);
            this.txtIdCartao.Name = "txtIdCartao";
            this.txtIdCartao.Size = new System.Drawing.Size(122, 20);
            this.txtIdCartao.TabIndex = 18;
            // 
            // lblCartao
            // 
            this.lblCartao.AutoSize = true;
            this.lblCartao.Location = new System.Drawing.Point(27, 16);
            this.lblCartao.Name = "lblCartao";
            this.lblCartao.Size = new System.Drawing.Size(16, 13);
            this.lblCartao.TabIndex = 17;
            this.lblCartao.Text = "Id";
            this.lblCartao.Click += new System.EventHandler(this.lblCpf_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(350, 13);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(75, 23);
            this.btnCadastro.TabIndex = 16;
            this.btnCadastro.Text = "Cadastrar";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // FrmCrudCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 361);
            this.Controls.Add(this.dgvCartaoVenda);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtIdCartao);
            this.Controls.Add(this.lblCartao);
            this.Controls.Add(this.btnCadastro);
            this.Name = "FrmCrudCartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartão";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartaoVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCartaoVenda;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtIdCartao;
        private System.Windows.Forms.Label lblCartao;
        private System.Windows.Forms.Button btnCadastro;
    }
}