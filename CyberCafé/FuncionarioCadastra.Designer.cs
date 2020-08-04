namespace CyberCafé
{
    partial class FuncionarioCadastra
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDataCont = new System.Windows.Forms.MaskedTextBox();
            this.lblDataCont = new System.Windows.Forms.Label();
            this.txtDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.txtTelCel = new System.Windows.Forms.MaskedTextBox();
            this.txtTelFix = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelCel = new System.Windows.Forms.Label();
            this.lblDataNasc = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTelFix = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.lblLogradouro = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.lbId);
            this.splitContainer1.Panel1.Controls.Add(this.txtDataCont);
            this.splitContainer1.Panel1.Controls.Add(this.lblDataCont);
            this.splitContainer1.Panel1.Controls.Add(this.txtDataNasc);
            this.splitContainer1.Panel1.Controls.Add(this.txtTelCel);
            this.splitContainer1.Panel1.Controls.Add(this.txtTelFix);
            this.splitContainer1.Panel1.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel1.Controls.Add(this.lblTelCel);
            this.splitContainer1.Panel1.Controls.Add(this.lblDataNasc);
            this.splitContainer1.Panel1.Controls.Add(this.lblEmail);
            this.splitContainer1.Panel1.Controls.Add(this.txtNome);
            this.splitContainer1.Panel1.Controls.Add(this.lblNome);
            this.splitContainer1.Panel1.Controls.Add(this.lblTelFix);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.txtLogradouro);
            this.splitContainer1.Panel2.Controls.Add(this.lblLogradouro);
            this.splitContainer1.Panel2.Controls.Add(this.txtEstado);
            this.splitContainer1.Panel2.Controls.Add(this.btnConfirmar);
            this.splitContainer1.Panel2.Controls.Add(this.txtComplemento);
            this.splitContainer1.Panel2.Controls.Add(this.txtNum);
            this.splitContainer1.Panel2.Controls.Add(this.txtBairro);
            this.splitContainer1.Panel2.Controls.Add(this.txtCidade);
            this.splitContainer1.Panel2.Controls.Add(this.lblComplemento);
            this.splitContainer1.Panel2.Controls.Add(this.lblNum);
            this.splitContainer1.Panel2.Controls.Add(this.lblEstado);
            this.splitContainer1.Panel2.Controls.Add(this.lblCidade);
            this.splitContainer1.Panel2.Controls.Add(this.lblBairro);
            this.splitContainer1.Panel2.Controls.Add(this.txtCEP);
            this.splitContainer1.Panel2.Controls.Add(this.lblCEP);
            this.splitContainer1.Size = new System.Drawing.Size(690, 520);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtDataCont
            // 
            this.txtDataCont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtDataCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCont.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCont.ForeColor = System.Drawing.Color.White;
            this.txtDataCont.Location = new System.Drawing.Point(20, 325);
            this.txtDataCont.Margin = new System.Windows.Forms.Padding(5);
            this.txtDataCont.Mask = "00/00/0000";
            this.txtDataCont.Name = "txtDataCont";
            this.txtDataCont.Size = new System.Drawing.Size(285, 38);
            this.txtDataCont.TabIndex = 5;
            this.txtDataCont.ValidatingType = typeof(System.DateTime);
            // 
            // lblDataCont
            // 
            this.lblDataCont.AutoSize = true;
            this.lblDataCont.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblDataCont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblDataCont.Location = new System.Drawing.Point(16, 298);
            this.lblDataCont.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDataCont.Name = "lblDataCont";
            this.lblDataCont.Size = new System.Drawing.Size(231, 32);
            this.lblDataCont.TabIndex = 100;
            this.lblDataCont.Text = "Data de Contratação";
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtDataNasc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataNasc.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataNasc.ForeColor = System.Drawing.Color.White;
            this.txtDataNasc.Location = new System.Drawing.Point(20, 395);
            this.txtDataNasc.Margin = new System.Windows.Forms.Padding(5);
            this.txtDataNasc.Mask = "00/00/0000";
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(285, 38);
            this.txtDataNasc.TabIndex = 6;
            this.txtDataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // txtTelCel
            // 
            this.txtTelCel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtTelCel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelCel.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelCel.ForeColor = System.Drawing.Color.White;
            this.txtTelCel.Location = new System.Drawing.Point(20, 255);
            this.txtTelCel.Margin = new System.Windows.Forms.Padding(5);
            this.txtTelCel.Mask = "(99)00000-0000";
            this.txtTelCel.Name = "txtTelCel";
            this.txtTelCel.Size = new System.Drawing.Size(285, 38);
            this.txtTelCel.TabIndex = 4;
            // 
            // txtTelFix
            // 
            this.txtTelFix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtTelFix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelFix.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelFix.ForeColor = System.Drawing.Color.White;
            this.txtTelFix.Location = new System.Drawing.Point(21, 185);
            this.txtTelFix.Margin = new System.Windows.Forms.Padding(5);
            this.txtTelFix.Mask = "(99)0000-0000";
            this.txtTelFix.Name = "txtTelFix";
            this.txtTelFix.Size = new System.Drawing.Size(285, 38);
            this.txtTelFix.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(20, 115);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 38);
            this.txtEmail.TabIndex = 2;
            // 
            // lblTelCel
            // 
            this.lblTelCel.AutoSize = true;
            this.lblTelCel.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblTelCel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblTelCel.Location = new System.Drawing.Point(15, 228);
            this.lblTelCel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTelCel.Name = "lblTelCel";
            this.lblTelCel.Size = new System.Drawing.Size(177, 32);
            this.lblTelCel.TabIndex = 99;
            this.lblTelCel.Text = "Telefone Celular";
            // 
            // lblDataNasc
            // 
            this.lblDataNasc.AutoSize = true;
            this.lblDataNasc.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblDataNasc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblDataNasc.Location = new System.Drawing.Point(15, 368);
            this.lblDataNasc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDataNasc.Name = "lblDataNasc";
            this.lblDataNasc.Size = new System.Drawing.Size(193, 32);
            this.lblDataNasc.TabIndex = 99;
            this.lblDataNasc.Text = "Data Nascimento";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblEmail.Location = new System.Drawing.Point(16, 88);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(69, 32);
            this.lblEmail.TabIndex = 99;
            this.lblEmail.Text = "Email";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(20, 45);
            this.txtNome.Margin = new System.Windows.Forms.Padding(5);
            this.txtNome.MaxLength = 150;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(285, 38);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblNome.Location = new System.Drawing.Point(16, 18);
            this.lblNome.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(78, 32);
            this.lblNome.TabIndex = 99;
            this.lblNome.Text = "Nome";
            // 
            // lblTelFix
            // 
            this.lblTelFix.AutoSize = true;
            this.lblTelFix.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblTelFix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblTelFix.Location = new System.Drawing.Point(15, 158);
            this.lblTelFix.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTelFix.Name = "lblTelFix";
            this.lblTelFix.Size = new System.Drawing.Size(148, 32);
            this.lblTelFix.TabIndex = 99;
            this.lblTelFix.Text = "Telefone Fixo";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogradouro.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogradouro.ForeColor = System.Drawing.Color.White;
            this.txtLogradouro.Location = new System.Drawing.Point(38, 255);
            this.txtLogradouro.Margin = new System.Windows.Forms.Padding(5);
            this.txtLogradouro.MaxLength = 80;
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(285, 38);
            this.txtLogradouro.TabIndex = 12;
            // 
            // lblLogradouro
            // 
            this.lblLogradouro.AutoSize = true;
            this.lblLogradouro.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblLogradouro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblLogradouro.Location = new System.Drawing.Point(34, 228);
            this.lblLogradouro.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLogradouro.Name = "lblLogradouro";
            this.lblLogradouro.Size = new System.Drawing.Size(137, 32);
            this.lblLogradouro.TabIndex = 101;
            this.lblLogradouro.Text = "Logradouro";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtEstado.DropDownHeight = 100;
            this.txtEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.ForeColor = System.Drawing.Color.White;
            this.txtEstado.IntegralHeight = false;
            this.txtEstado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.txtEstado.Location = new System.Drawing.Point(181, 45);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(0);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(140, 39);
            this.txtEstado.TabIndex = 9;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(36, 447);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(285, 56);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Enviar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComplemento.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComplemento.ForeColor = System.Drawing.Color.White;
            this.txtComplemento.Location = new System.Drawing.Point(36, 395);
            this.txtComplemento.Margin = new System.Windows.Forms.Padding(5);
            this.txtComplemento.MaxLength = 50;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(285, 38);
            this.txtComplemento.TabIndex = 14;
            // 
            // txtNum
            // 
            this.txtNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.ForeColor = System.Drawing.Color.White;
            this.txtNum.Location = new System.Drawing.Point(36, 325);
            this.txtNum.Margin = new System.Windows.Forms.Padding(5);
            this.txtNum.MaxLength = 10;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(285, 38);
            this.txtNum.TabIndex = 13;
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.ForeColor = System.Drawing.Color.White;
            this.txtBairro.Location = new System.Drawing.Point(38, 185);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(5);
            this.txtBairro.MaxLength = 80;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(285, 38);
            this.txtBairro.TabIndex = 11;
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCidade.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.ForeColor = System.Drawing.Color.White;
            this.txtCidade.Location = new System.Drawing.Point(36, 115);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(5);
            this.txtCidade.MaxLength = 100;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(285, 38);
            this.txtCidade.TabIndex = 10;
            // 
            // lblComplemento
            // 
            this.lblComplemento.AutoSize = true;
            this.lblComplemento.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblComplemento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblComplemento.Location = new System.Drawing.Point(32, 368);
            this.lblComplemento.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(162, 32);
            this.lblComplemento.TabIndex = 99;
            this.lblComplemento.Text = "Complemento";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblNum.Location = new System.Drawing.Point(32, 298);
            this.lblNum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(99, 32);
            this.lblNum.TabIndex = 99;
            this.lblNum.Text = "Número";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblEstado.Location = new System.Drawing.Point(175, 18);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(85, 32);
            this.lblEstado.TabIndex = 99;
            this.lblEstado.Text = "Estado";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblCidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblCidade.Location = new System.Drawing.Point(32, 88);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(87, 32);
            this.lblCidade.TabIndex = 99;
            this.lblCidade.Text = "Cidade";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblBairro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblBairro.Location = new System.Drawing.Point(34, 158);
            this.lblBairro.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(75, 32);
            this.lblBairro.TabIndex = 99;
            this.lblBairro.Text = "Bairro";
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.txtCEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCEP.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCEP.ForeColor = System.Drawing.Color.White;
            this.txtCEP.Location = new System.Drawing.Point(36, 45);
            this.txtCEP.Margin = new System.Windows.Forms.Padding(5);
            this.txtCEP.Mask = "00000-999";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(128, 38);
            this.txtCEP.TabIndex = 8;
            this.txtCEP.Leave += new System.EventHandler(this.txtCEP_Leave);
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.lblCEP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.lblCEP.Location = new System.Drawing.Point(32, 18);
            this.lblCEP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(55, 32);
            this.lblCEP.TabIndex = 99;
            this.lblCEP.Text = "CEP";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(294, 11);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(33, 29);
            this.lbId.TabIndex = 101;
            this.lbId.Text = "Id";
            this.lbId.Visible = false;
            // 
            // FuncionarioCadastra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FuncionarioCadastra";
            this.Size = new System.Drawing.Size(690, 520);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label lblTelCel;
        public System.Windows.Forms.Label lblTelFix;
        public System.Windows.Forms.Label lblDataNasc;
        public System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.Label lblNome;
        public System.Windows.Forms.Label lblLogradouro;
        public System.Windows.Forms.Label lblComplemento;
        public System.Windows.Forms.Label lblNum;
        public System.Windows.Forms.Label lblEstado;
        public System.Windows.Forms.Label lblCidade;
        public System.Windows.Forms.Label lblBairro;
        public System.Windows.Forms.Label lblCEP;
        public System.Windows.Forms.Label lblDataCont;
        public System.Windows.Forms.MaskedTextBox txtDataNasc;
        public System.Windows.Forms.MaskedTextBox txtTelCel;
        public System.Windows.Forms.MaskedTextBox txtTelFix;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtNome;
        public System.Windows.Forms.TextBox txtLogradouro;
        public System.Windows.Forms.ComboBox txtEstado;
        public System.Windows.Forms.TextBox txtComplemento;
        public System.Windows.Forms.TextBox txtNum;
        public System.Windows.Forms.TextBox txtBairro;
        public System.Windows.Forms.TextBox txtCidade;
        public System.Windows.Forms.MaskedTextBox txtCEP;
        public System.Windows.Forms.MaskedTextBox txtDataCont;
        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Label lbId;
    }
}
