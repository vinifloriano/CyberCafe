namespace CyberCafé
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_cf1 = new System.Windows.Forms.Label();
            this.btnDesliga = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnArrasta1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menu1 = new CyberCafé.Menu();
            this.produtoEdita1 = new CyberCafé.ProdutoEdita();
            this.fornecedorEdita1 = new CyberCafé.FornecedorEdita();
            this.usuarioEdita1 = new CyberCafé.UsuarioEdita();
            this.fornecedorCadastra1 = new CyberCafé.FornecedorCadastra();
            this.funcionarioCadastra1 = new CyberCafé.FuncionarioCadastra();
            this.usuarioCadastra1 = new CyberCafé.UsuarioCadastra();
            this.produtoCadastra1 = new CyberCafé.ProdutoCadastra();
            this.funcionarioEdita1 = new CyberCafé.FuncionarioEdita();
            this.home1 = new CyberCafé.Home();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDesliga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnArrasta1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.splitContainer1.Panel1.Controls.Add(this.menu1);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_cf1);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.home1);
            this.splitContainer1.Panel2.Controls.Add(this.produtoEdita1);
            this.splitContainer1.Panel2.Controls.Add(this.fornecedorEdita1);
            this.splitContainer1.Panel2.Controls.Add(this.usuarioEdita1);
            this.splitContainer1.Panel2.Controls.Add(this.btnDesliga);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.fornecedorCadastra1);
            this.splitContainer1.Panel2.Controls.Add(this.funcionarioCadastra1);
            this.splitContainer1.Panel2.Controls.Add(this.usuarioCadastra1);
            this.splitContainer1.Panel2.Controls.Add(this.pnArrasta1);
            this.splitContainer1.Panel2.Controls.Add(this.produtoCadastra1);
            this.splitContainer1.Panel2.Controls.Add(this.funcionarioEdita1);
            this.splitContainer1.Panel2MinSize = 730;
            this.splitContainer1.Size = new System.Drawing.Size(1020, 569);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_cf1
            // 
            this.lbl_cf1.AutoSize = true;
            this.lbl_cf1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cf1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(226)))));
            this.lbl_cf1.Location = new System.Drawing.Point(39, 17);
            this.lbl_cf1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_cf1.Name = "lbl_cf1";
            this.lbl_cf1.Size = new System.Drawing.Size(164, 29);
            this.lbl_cf1.TabIndex = 13;
            this.lbl_cf1.Text = "CYBER CAFÉ";
            // 
            // btnDesliga
            // 
            this.btnDesliga.Image = ((System.Drawing.Image)(resources.GetObject("btnDesliga.Image")));
            this.btnDesliga.Location = new System.Drawing.Point(689, 6);
            this.btnDesliga.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnDesliga.Name = "btnDesliga";
            this.btnDesliga.Size = new System.Drawing.Size(28, 28);
            this.btnDesliga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDesliga.TabIndex = 8;
            this.btnDesliga.TabStop = false;
            this.btnDesliga.Click += new System.EventHandler(this.btnDesliga_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(653, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnArrasta1
            // 
            this.pnArrasta1.Controls.Add(this.lblTitle);
            this.pnArrasta1.Location = new System.Drawing.Point(3, 3);
            this.pnArrasta1.Name = "pnArrasta1";
            this.pnArrasta1.Size = new System.Drawing.Size(646, 31);
            this.pnArrasta1.TabIndex = 13;
            this.pnArrasta1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnArrasta1_MouseDown);
            this.pnArrasta1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnArrasta1_MouseMove);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.lblTitle.Location = new System.Drawing.Point(299, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(63, 23);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "HOME\r\n";
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.Transparent;
            this.menu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.menu1.Location = new System.Drawing.Point(-5, 61);
            this.menu1.Margin = new System.Windows.Forms.Padding(6);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(285, 990);
            this.menu1.TabIndex = 14;
            // 
            // produtoEdita1
            // 
            this.produtoEdita1.BackColor = System.Drawing.Color.Transparent;
            this.produtoEdita1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.produtoEdita1.Location = new System.Drawing.Point(18, 38);
            this.produtoEdita1.Margin = new System.Windows.Forms.Padding(6);
            this.produtoEdita1.Name = "produtoEdita1";
            this.produtoEdita1.Size = new System.Drawing.Size(690, 520);
            this.produtoEdita1.TabIndex = 17;
            // 
            // fornecedorEdita1
            // 
            this.fornecedorEdita1.BackColor = System.Drawing.Color.Transparent;
            this.fornecedorEdita1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.fornecedorEdita1.Location = new System.Drawing.Point(18, 38);
            this.fornecedorEdita1.Margin = new System.Windows.Forms.Padding(5);
            this.fornecedorEdita1.Name = "fornecedorEdita1";
            this.fornecedorEdita1.Size = new System.Drawing.Size(690, 520);
            this.fornecedorEdita1.TabIndex = 16;
            // 
            // usuarioEdita1
            // 
            this.usuarioEdita1.BackColor = System.Drawing.Color.Transparent;
            this.usuarioEdita1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.usuarioEdita1.Location = new System.Drawing.Point(18, 38);
            this.usuarioEdita1.Margin = new System.Windows.Forms.Padding(5);
            this.usuarioEdita1.Name = "usuarioEdita1";
            this.usuarioEdita1.Size = new System.Drawing.Size(690, 520);
            this.usuarioEdita1.TabIndex = 12;
            // 
            // fornecedorCadastra1
            // 
            this.fornecedorCadastra1.BackColor = System.Drawing.Color.Transparent;
            this.fornecedorCadastra1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.fornecedorCadastra1.Location = new System.Drawing.Point(18, 38);
            this.fornecedorCadastra1.Margin = new System.Windows.Forms.Padding(5);
            this.fornecedorCadastra1.Name = "fornecedorCadastra1";
            this.fornecedorCadastra1.Size = new System.Drawing.Size(690, 520);
            this.fornecedorCadastra1.TabIndex = 10;
            // 
            // funcionarioCadastra1
            // 
            this.funcionarioCadastra1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.funcionarioCadastra1.Location = new System.Drawing.Point(18, 38);
            this.funcionarioCadastra1.Margin = new System.Windows.Forms.Padding(6);
            this.funcionarioCadastra1.Name = "funcionarioCadastra1";
            this.funcionarioCadastra1.Size = new System.Drawing.Size(690, 520);
            this.funcionarioCadastra1.TabIndex = 11;
            // 
            // usuarioCadastra1
            // 
            this.usuarioCadastra1.BackColor = System.Drawing.Color.Transparent;
            this.usuarioCadastra1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioCadastra1.Location = new System.Drawing.Point(18, 38);
            this.usuarioCadastra1.Margin = new System.Windows.Forms.Padding(6);
            this.usuarioCadastra1.Name = "usuarioCadastra1";
            this.usuarioCadastra1.Size = new System.Drawing.Size(690, 520);
            this.usuarioCadastra1.TabIndex = 7;
            // 
            // produtoCadastra1
            // 
            this.produtoCadastra1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.produtoCadastra1.Location = new System.Drawing.Point(18, 38);
            this.produtoCadastra1.Margin = new System.Windows.Forms.Padding(5);
            this.produtoCadastra1.Name = "produtoCadastra1";
            this.produtoCadastra1.Size = new System.Drawing.Size(690, 520);
            this.produtoCadastra1.TabIndex = 14;
            // 
            // funcionarioEdita1
            // 
            this.funcionarioEdita1.BackColor = System.Drawing.Color.Transparent;
            this.funcionarioEdita1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.funcionarioEdita1.Location = new System.Drawing.Point(18, 38);
            this.funcionarioEdita1.Margin = new System.Windows.Forms.Padding(5);
            this.funcionarioEdita1.Name = "funcionarioEdita1";
            this.funcionarioEdita1.Size = new System.Drawing.Size(690, 520);
            this.funcionarioEdita1.TabIndex = 15;
            // 
            // home1
            // 
            this.home1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.home1.Location = new System.Drawing.Point(18, 38);
            this.home1.Margin = new System.Windows.Forms.Padding(5);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(690, 520);
            this.home1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1020, 569);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyber Café";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDesliga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnArrasta1.ResumeLayout(false);
            this.pnArrasta1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_cf1;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private Menu menu1;
        private UsuarioEdita usuarioEdita1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox btnDesliga;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FornecedorCadastra fornecedorCadastra1;
        private FuncionarioCadastra funcionarioCadastra1;
        private UsuarioCadastra usuarioCadastra1;
        private System.Windows.Forms.Panel pnArrasta1;
        private ProdutoCadastra produtoCadastra1;
        private FuncionarioEdita funcionarioEdita1;
        private FornecedorEdita fornecedorEdita1;
        private ProdutoEdita produtoEdita1;
        private Home home1;
    }
}

