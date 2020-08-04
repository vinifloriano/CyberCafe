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
    public partial class ProdutoEdita : UserControl
    {
        public ProdutoEdita()
        {
            InitializeComponent();
        }

        private void ProdutoEdita_Load(object sender, EventArgs e)
        {
            Atualiza();
        }

        public void Atualiza()
        {
            MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
            objCon.Open();
            DataSet conexaoDataset = new DataSet();
            MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter("SELECT id_produto 'Id', nome_produto 'Nome', quantidade_produto 'Quantidade', preco_produto 'Preco' FROM produto", objCon);
            conexaoAdapter.Fill(conexaoDataset, "produto");
            dataGridView1.DataSource = conexaoDataset;
            dataGridView1.DataMember = "produto";
            objCon.Close();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == "")
            {
                Atualiza();
            }
            else
            {
                string pesquisa = "";
                if (combBoxPesquisa.Text == "Id") pesquisa = "id_produto";
                else if (combBoxPesquisa.Text == "Nome") pesquisa = "nome_produto";
                else if (combBoxPesquisa.Text == "Preco") pesquisa = "preco_produto";
                else if (combBoxPesquisa.Text == "Quantidade") pesquisa = "quantidade_produto";
                MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objCon.Open();
                DataSet conexaoDataset = new DataSet();
                string searchbanco = "SELECT id_produto 'Id', nome_produto 'Nome', quantidade_produto 'Quantidade', preco_produto 'Preco' FROM produto WHERE " + pesquisa + " = '" + txtPesquisa.Text + "'";
                MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter(searchbanco, objCon);

                conexaoAdapter.Fill(conexaoDataset, "produto");
                dataGridView1.DataSource = conexaoDataset;
                dataGridView1.DataMember = "produto";


                objCon.Close();
            }
        }

        public event EventHandler EditaProd;

        private void CMEditar_Click(object sender, EventArgs e)
        {
            ProdutoCadastra frm = new ProdutoCadastra();

            frm.lbId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtNum.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtPreco.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.Top = 38;
            frm.Left = 18;

            EventHandler handler = EditaProd;
            handler?.Invoke(frm, e);

        }

        private void CMRemover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(("Confirma exclusão do Produto?"), "Produtos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int id_prod = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objcon.Open();

                MySqlCommand cmdRemEnd = new MySqlCommand("delete from produto where id_produto = ?", objcon);
                cmdRemEnd.Parameters.Clear();
                cmdRemEnd.Parameters.Add("@id_produto", MySqlDbType.Int16).Value = id_prod;
                cmdRemEnd.CommandType = CommandType.Text;
                cmdRemEnd.ExecuteNonQuery();


                objcon.Close();
                MessageBox.Show("Dados Removidos com sucesso!");
                Atualiza();
            }
        }
    }
}
