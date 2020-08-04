namespace CyberCafé
{
    partial class Config
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
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbModoEscuro = new System.Windows.Forms.Label();
            this.chkModoEsc = new System.Windows.Forms.CheckBox();
            this.lbBackup = new System.Windows.Forms.Label();
            this.btn_Backup = new System.Windows.Forms.Button();
            this.btn_Restaurar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btn_Salvar.FlatAppearance.BorderSize = 0;
            this.btn_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salvar.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.btn_Salvar.ForeColor = System.Drawing.Color.White;
            this.btn_Salvar.Location = new System.Drawing.Point(595, 353);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(110, 67);
            this.btn_Salvar.TabIndex = 0;
            this.btn_Salvar.Text = "Salvar Alterações";
            this.btn_Salvar.UseVisualStyleBackColor = false;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Location = new System.Drawing.Point(479, 353);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(110, 67);
            this.btn_Cancelar.TabIndex = 1;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbModoEscuro
            // 
            this.lbModoEscuro.AutoSize = true;
            this.lbModoEscuro.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbModoEscuro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.lbModoEscuro.Location = new System.Drawing.Point(12, 9);
            this.lbModoEscuro.Name = "lbModoEscuro";
            this.lbModoEscuro.Size = new System.Drawing.Size(123, 25);
            this.lbModoEscuro.TabIndex = 2;
            this.lbModoEscuro.Text = "Modo Escuro";
            // 
            // chkModoEsc
            // 
            this.chkModoEsc.AutoSize = true;
            this.chkModoEsc.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.chkModoEsc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.chkModoEsc.Location = new System.Drawing.Point(66, 41);
            this.chkModoEsc.Name = "chkModoEsc";
            this.chkModoEsc.Size = new System.Drawing.Size(95, 29);
            this.chkModoEsc.TabIndex = 4;
            this.chkModoEsc.Text = "Ativado";
            this.chkModoEsc.UseVisualStyleBackColor = true;
            this.chkModoEsc.CheckedChanged += new System.EventHandler(this.chkModoEsc_CheckedChanged);
            // 
            // lbBackup
            // 
            this.lbBackup.AutoSize = true;
            this.lbBackup.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(125)))), ((int)(((byte)(161)))));
            this.lbBackup.Location = new System.Drawing.Point(12, 86);
            this.lbBackup.Name = "lbBackup";
            this.lbBackup.Size = new System.Drawing.Size(73, 25);
            this.lbBackup.TabIndex = 5;
            this.lbBackup.Text = "Backup";
            // 
            // btn_Backup
            // 
            this.btn_Backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btn_Backup.FlatAppearance.BorderSize = 0;
            this.btn_Backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Backup.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.btn_Backup.ForeColor = System.Drawing.Color.White;
            this.btn_Backup.Location = new System.Drawing.Point(63, 118);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(139, 61);
            this.btn_Backup.TabIndex = 6;
            this.btn_Backup.Text = "Fazer backup agora";
            this.btn_Backup.UseVisualStyleBackColor = false;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // btn_Restaurar
            // 
            this.btn_Restaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btn_Restaurar.FlatAppearance.BorderSize = 0;
            this.btn_Restaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Restaurar.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F);
            this.btn_Restaurar.ForeColor = System.Drawing.Color.White;
            this.btn_Restaurar.Location = new System.Drawing.Point(208, 118);
            this.btn_Restaurar.Name = "btn_Restaurar";
            this.btn_Restaurar.Size = new System.Drawing.Size(139, 61);
            this.btn_Restaurar.TabIndex = 7;
            this.btn_Restaurar.Text = "Restaurar para último backup";
            this.btn_Restaurar.UseVisualStyleBackColor = false;
            this.btn_Restaurar.Click += new System.EventHandler(this.btn_Restaurar_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(717, 432);
            this.Controls.Add(this.btn_Restaurar);
            this.Controls.Add(this.btn_Backup);
            this.Controls.Add(this.lbBackup);
            this.Controls.Add(this.chkModoEsc);
            this.Controls.Add(this.lbModoEscuro);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Salvar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyber Café - Configurações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbModoEscuro;
        private System.Windows.Forms.Label lbBackup;
        private System.Windows.Forms.Button btn_Backup;
        private System.Windows.Forms.Button btn_Restaurar;
        public System.Windows.Forms.CheckBox chkModoEsc;
    }
}