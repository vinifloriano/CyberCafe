using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CyberCafé
{
    public partial class ProdutoCadastra : UserControl
    {
        public ProdutoCadastra()
        {
            InitializeComponent();
            txtNum.KeyPress += new KeyPressEventHandler(Validacoes.txtNum_KeyPress);
            txtNome.KeyPress += new KeyPressEventHandler(Validacoes.txtNome_KeyPress);
        }

        public void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (txtNum.Text == "")
                MessageBox.Show("Insira a quantidade.");
            else if (txtPreco.Text == "")
                MessageBox.Show("Insira um preço.");
            else
            {
                // passa a string de conexao
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                // abre o banco
                objcon.Open();
                // comando para inserir na tabela
                MySqlCommand cmdEnd = new MySqlCommand("insert into produto (nome_produto, quantidade_produto, preco_produto) values (?,?,?)", objcon);
                //parametros
                cmdEnd.Parameters.Add("@nome_produto", MySqlDbType.VarChar, 9).Value = txtNome.Text;
                cmdEnd.Parameters.Add("@quantidade_produto", MySqlDbType.Int16).Value = int.Parse(txtNum.Text);
                cmdEnd.Parameters.Add("@preco_produto", MySqlDbType.Double).Value = txtPreco.Text;
                //comando para executar a query
                cmdEnd.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Dados inseridos com sucesso!");
                txtNome.Clear();
                txtNum.Clear();
                txtPreco.Clear();

            }
        }
    }
}
