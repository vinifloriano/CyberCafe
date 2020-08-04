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
    public partial class FuncionarioEdita : UserControl
    {
        public FuncionarioEdita()
        {
            InitializeComponent();
        }

        public event EventHandler EditaFunc;

        //
        // Atualiza Usuários Cadastrados
        //
        private void FuncionarioEdita_Load(object sender, EventArgs e)
        {
            Atualiza();
        }

        public void Atualiza()
        {
            MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
            objCon.Open();
            DataSet conexaoDataset = new DataSet();
            MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter("SELECT id_funcionario 'Id', nome_funcionario 'Nome', email_funcionario 'Email', DATE_FORMAT(data_nasc_funcionario,'%d/%m/%Y') 'Data de Nascimento', DATE_FORMAT(data_contratacao,'%d/%m/%Y') 'Data de Contratação', tel_cel_func 'Telefone Celular', tel_fixo_func 'Telefone Fixo' FROM funcionario", objCon);
            conexaoAdapter.Fill(conexaoDataset, "funcionario");
            dataGridView1.DataSource = conexaoDataset;
            dataGridView1.DataMember = "funcionario";

            DataSet conexaoDataset2 = new DataSet();
            MySqlDataAdapter conexaoAdapter2 = new MySqlDataAdapter("SELECT funcionario.id_funcionario 'Id', endereco.estado 'Estado', endereco.cidade 'Cidade', endereco.bairro 'Bairro', endereco.CEP 'CEP', endereco.logradouro 'Rua', endereco.numero_endereco 'Numero' FROM endereco inner join funcionario on funcionario.id_endereco = endereco.id_endereco", objCon);
            conexaoAdapter2.Fill(conexaoDataset2, "endereco");
            dataGridView2.DataSource = conexaoDataset2;
            dataGridView2.DataMember = "endereco";
            objCon.Close();
        }

        //
        // Remove Usuários Cadastrados
        //
        private void Remove(object sender, EventArgs e)
        {
            if (MessageBox.Show(("Confirma exclusão do Funcionário?"), "Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int id_func = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objcon.Open();

                MySqlCommand Query = new MySqlCommand("SELECT id_endereco FROM funcionario WHERE id_funcionario = ?", objcon);
                Query.Parameters.Add("@id_funcionario", MySqlDbType.Int16).Value = id_func;
                MySqlDataReader dtreader = Query.ExecuteReader();
                int id_end = 0;

                if (dtreader.Read())
                {
                    id_end = int.Parse(dtreader["id_endereco"].ToString());
                    dtreader.Close();
                    MySqlCommand cmdRemFunc = new MySqlCommand("delete from funcionario where id_funcionario = ?", objcon);
                    cmdRemFunc.Parameters.Clear();
                    cmdRemFunc.Parameters.Add("@id_funcionario", MySqlDbType.Int16).Value = id_func;
                    cmdRemFunc.CommandType = CommandType.Text;
                    cmdRemFunc.ExecuteNonQuery();


                }

                try
                {
                    MySqlCommand cmdRemEnd = new MySqlCommand("delete from endereco where id_endereco = ?", objcon);
                    cmdRemEnd.Parameters.Clear();
                    cmdRemEnd.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                    cmdRemEnd.CommandType = CommandType.Text;
                    cmdRemEnd.ExecuteNonQuery();
                }
                catch
                {
                }

                objcon.Close();
                MessageBox.Show("Dados Removidos com sucesso!");
                Atualiza();
            }
        }

        //
        // Pesquisa entre Usuários Cadastrados
        //
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == "")
            {
                Atualiza();
            }
            else
            {
                string pesquisa = "";
                if (combBoxPesquisa.Text == "Id") pesquisa = "id_funcionario";
                else if (combBoxPesquisa.Text == "Nome") pesquisa = "nome_funcionario";
                else if (combBoxPesquisa.Text == "Email") pesquisa = "email_funcionario";
                else if (combBoxPesquisa.Text == "Telefone Celular") pesquisa = "tel_cel_funcionario";
                else if (combBoxPesquisa.Text == "Telefone Fixo") pesquisa = "tel_fixo_funcionario";
                else if (combBoxPesquisa.Text == "Data de Nascimento") pesquisa = "data_nasc_funcionario";
                MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objCon.Open();
                DataSet conexaoDataset = new DataSet();
                string searchbanco = "SELECT id_funcionario 'Id', nome_funcionario 'Nome', email_funcionario 'Email', DATE_FORMAT(data_nasc_funcionario, '%d/%m/%Y') 'Data de Nascimento', DATE_FORMAT(data_contratacao, '%d/%m/%Y') 'Data de Contratacao', tel_cel_funcionario 'Telefone Celular', tel_fixo_funcionario 'Telefone Fixo' FROM funcionario WHERE " + pesquisa + " = '" + txtPesquisa.Text + "'";
                MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter(searchbanco, objCon);

                conexaoAdapter.Fill(conexaoDataset, "funcionario");
                dataGridView1.DataSource = conexaoDataset;
                dataGridView1.DataMember = "funcionario";

                DataSet conexaoDataset2 = new DataSet();
                string searchbanco2 = "SELECT funcionariofuncionario.id_funcionario 'Id', funcionario.estado 'Estado', funcionario.cidade 'Cidade', funcionario.bairro 'Bairro', funcionario.CEP 'CEP', funcionario.logradouro 'Rua', funcionario.numero_funcionario 'Numero' FROM funcionario inner join funcionariofuncionario on funcionario.id_funcionario = funcionariofuncionario.id_funcionario inner join funcionario on funcionario.id_funcionario = funcionariofuncionario.id_funcionario where funcionario." + pesquisa + " = '" + txtPesquisa.Text + "'";
                MySqlDataAdapter conexaoAdapter2 = new MySqlDataAdapter(searchbanco2, objCon);
                conexaoAdapter2.Fill(conexaoDataset2, "funcionario");
                dataGridView2.DataSource = conexaoDataset2;
                dataGridView2.DataMember = "funcionario";

                objCon.Close();
            }

        }

        //
        // Edita Usuários Cadastrados
        //
        private void CMEditar_Click(object sender, EventArgs e)
        {
            FuncionarioCadastra frm = new FuncionarioCadastra();

            frm.lbId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtDataNasc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtDataCont.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.txtTelCel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm.txtTelFix.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            frm.txtEstado.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            frm.txtCidade.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            frm.txtBairro.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            frm.txtCEP.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            frm.txtLogradouro.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            frm.txtNum.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            frm.Top = 38;
            frm.Left = 18;

            EventHandler handler = EditaFunc;
            handler?.Invoke(frm, e);
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
                            dataGridView1.Rows[i].Cells[j].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                    }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mudaSelecao2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mudaSelecao1();
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
