using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberCafé
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Backup()
        {
            // Faz o backup
            string arquivo = "backup.sql";

            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
            conn.Close();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    mb.ExportToFile(arquivo);
                    conn.Close();
                }
            }
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            using (WaitForm frm = new WaitForm(Backup))
            {
                frm.ShowDialog(this);
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Restaurar()
        {
            // Carrega arquivo de backup
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
            string script = File.ReadAllText("backup.sql");
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = script;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btn_Restaurar_Click(object sender, EventArgs e)
        {
            using (WaitForm frm = new WaitForm(Restaurar))
            {
                frm.ShowDialog(this);
            }
        }

        public event EventHandler ModoEscuro;


        public void btn_Salvar_Click(object sender, EventArgs e)
        {
            if(chkModoEsc.Checked)
            {
                Form1.esc = 0;
            }
            else
            {
                Form1.esc = 1;
            }
            EventHandler handler = ModoEscuro;
            handler?.Invoke(this, e);
            this.Hide();
            
        }

        private void chkModoEsc_CheckedChanged(object sender, EventArgs e)
        {
            if(chkModoEsc.Checked)
            {
                this.BackColor = Color.Black;
                lbModoEscuro.ForeColor = Color.White;
                lbBackup.ForeColor = Color.White;
                chkModoEsc.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(216, 231, 226);
                lbModoEscuro.ForeColor = Color.FromArgb(40, 125, 161);
                lbBackup.ForeColor = Color.FromArgb(40, 125, 161);
                chkModoEsc.ForeColor = Color.FromArgb(40, 125, 161);
            }
        }
    }
}
