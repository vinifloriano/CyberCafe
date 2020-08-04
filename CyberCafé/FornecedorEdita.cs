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
    public partial class FornecedorEdita : UserControl
    {
        public FornecedorEdita()
        {
            InitializeComponent();
        }

        private void FornecedorEdita_Load(object sender, EventArgs e)
        {
            Atualiza();
        }

        public event EventHandler EditaForn;

        public void Atualiza()
        {
            MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
            objCon.Open();
            DataSet conexaoDataset = new DataSet();
            MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter("SELECT id_fornecedor 'Id', nome_fornecedor 'Nome', email_fornecedor 'Email', CNPJ FROM fornecedor", objCon);
            conexaoAdapter.Fill(conexaoDataset, "fornecedor");
            dataGridView1.DataSource = conexaoDataset;
            dataGridView1.DataMember = "fornecedor";

            DataSet conexaoDataset2 = new DataSet();
            MySqlDataAdapter conexaoAdapter2 = new MySqlDataAdapter("SELECT enderecofornecedor.id_fornecedor 'Id', endereco.estado 'Estado', endereco.cidade 'Cidade', endereco.bairro 'Bairro', endereco.CEP 'CEP', endereco.logradouro 'Rua', endereco.numero_endereco 'Numero' FROM endereco inner join enderecofornecedor on endereco.id_endereco = enderecofornecedor.id_endereco", objCon);
            conexaoAdapter2.Fill(conexaoDataset2, "endereco");
            dataGridView2.DataSource = conexaoDataset2;
            dataGridView2.DataMember = "endereco";
            objCon.Close();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {

        }

        private void CMEditar_Click(object sender, EventArgs e)
        {
            FornecedorCadastra frm = new FornecedorCadastra();

            frm.lbId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtCNPJ.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtEstado.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            frm.txtCidade.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            frm.txtBairro.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            frm.txtCEP.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            frm.txtLogradouro.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            frm.txtNum.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            frm.Top = 38;
            frm.Left = 18;

            EventHandler handler = EditaForn;
            handler?.Invoke(frm, e);

        }

        private void CMRemover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(("Confirma exclusão do Fornecedor?"), "Fornecedores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int id_forn = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objcon.Open();

                MySqlCommand Query = new MySqlCommand("SELECT id_endereco FROM enderecofornecedor WHERE id_fornecedor = ?", objcon);
                Query.Parameters.Add("@id_fornecedor", MySqlDbType.Int16).Value = id_forn;
                MySqlDataReader dtreader = Query.ExecuteReader();
                int id_end = 0;

                if (dtreader.Read())
                {
                    id_end = int.Parse(dtreader["id_endereco"].ToString());
                    dtreader.Close();

                    MySqlCommand cmdRemEndUsu = new MySqlCommand("delete from enderecofornecedor where id_endereco = ? and id_fornecedor = ?", objcon);
                    cmdRemEndUsu.Parameters.Clear();
                    cmdRemEndUsu.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                    cmdRemEndUsu.Parameters.Add("@id_fornecedor", MySqlDbType.Int16).Value = id_forn;
                    cmdRemEndUsu.CommandType = CommandType.Text;
                    cmdRemEndUsu.ExecuteNonQuery();

                    MySqlCommand cmdRemEnd = new MySqlCommand("delete from endereco where id_endereco = ?", objcon);
                    cmdRemEnd.Parameters.Clear();
                    cmdRemEnd.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                    cmdRemEnd.CommandType = CommandType.Text;
                    cmdRemEnd.ExecuteNonQuery();

                }

                try
                {
                    MySqlCommand cmdRemUsu = new MySqlCommand("delete from fornecedor where id_fornecedor = ?", objcon);
                    cmdRemUsu.Parameters.Clear();
                    cmdRemUsu.Parameters.Add("@id_fornecedor", MySqlDbType.Int16).Value = id_forn;
                    cmdRemUsu.CommandType = CommandType.Text;
                    cmdRemUsu.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(id_forn.ToString());
                    MessageBox.Show(id_end.ToString());
                }

                objcon.Close();
                MessageBox.Show("Dados Removidos com sucesso!");
                Atualiza();
            }
        }


        private void mudaSelecao1()
        {
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    if (dataGridView1.Rows[i].Cells[j].Selected)
                    {
                        dataGridView2.Rows[i].Cells[j].Selected = true;
                        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[j];
                    }
        }

        private void mudaSelecao2()
        {
            for (int j = 0; j < dataGridView2.ColumnCount; j++)
                for (int i = 0; i < dataGridView2.RowCount; i++)
                    if (dataGridView2.Rows[i].Cells[j].Selected)
                    {
                        if (j != dataGridView2.ColumnCount - 1)
                        {
                            dataGridView1.Rows[i].Cells[j].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j - 1].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j - 1];
                        }
                    }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mudaSelecao1();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mudaSelecao2();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            mudaSelecao1();
        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            mudaSelecao2();
        }
    }
}
