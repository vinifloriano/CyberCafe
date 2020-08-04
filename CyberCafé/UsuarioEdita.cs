using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace CyberCafé
{
    public partial class UsuarioEdita : UserControl
    {
        public UsuarioEdita()
        {
            InitializeComponent();
        }

        public event EventHandler EditaUsu;

        //
        // Atualiza Usuários Cadastrados
        //
        private void UsuarioEdita_Load(object sender, EventArgs e)
        {
            Atualiza();
        }

        public void Atualiza()
        {
            MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
            objCon.Open();
            DataSet conexaoDataset = new DataSet();
            MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter("SELECT id_usuario 'Id', nome_usuario 'Nome', email_usuario 'Email', DATE_FORMAT(data_nasc_usuario,'%d/%m/%Y') 'Data de Nascimento', tel_cel_usuario 'Telefone Celular', tel_fixo_usuario 'Telefone Fixo' FROM usuario", objCon);
            conexaoAdapter.Fill(conexaoDataset, "usuario");
            dataGridView1.DataSource = conexaoDataset;
            dataGridView1.DataMember = "usuario";

            DataSet conexaoDataset2 = new DataSet();
            MySqlDataAdapter conexaoAdapter2 = new MySqlDataAdapter("SELECT enderecousuario.id_usuario 'Id', endereco.estado 'Estado', endereco.cidade 'Cidade', endereco.bairro 'Bairro', endereco.CEP 'CEP', endereco.logradouro 'Rua', endereco.numero_endereco 'Numero' FROM endereco inner join enderecousuario on endereco.id_endereco = enderecousuario.id_endereco", objCon);
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
            if (MessageBox.Show(("Confirma exclusão do Usuário?"), "Usuários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int id_usu = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objcon.Open();

                MySqlCommand Query = new MySqlCommand("SELECT id_endereco FROM enderecousuario WHERE id_usuario = ?", objcon);
                Query.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id_usu;
                MySqlDataReader dtreader = Query.ExecuteReader();
                int id_end = 0;

                if (dtreader.Read())
                {
                    id_end = int.Parse(dtreader["id_endereco"].ToString());
                    dtreader.Close();

                    MySqlCommand cmdRemEndUsu = new MySqlCommand("delete from enderecousuario where id_endereco = ? and id_usuario = ?", objcon);
                    cmdRemEndUsu.Parameters.Clear();
                    cmdRemEndUsu.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                    cmdRemEndUsu.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id_usu;
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
                    MySqlCommand cmdRemUsu = new MySqlCommand("delete from usuario where id_usuario = ?", objcon);
                    cmdRemUsu.Parameters.Clear();
                    cmdRemUsu.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = id_usu;
                    cmdRemUsu.CommandType = CommandType.Text;
                    cmdRemUsu.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(id_usu.ToString());
                    MessageBox.Show(id_end.ToString());
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
            if(txtPesquisa.Text == "")
            {
                Atualiza();
            }
            else {
                string pesquisa = "";
                if (combBoxPesquisa.Text == "Id") pesquisa = "id_usuario";
                else if (combBoxPesquisa.Text == "Nome") pesquisa = "nome_usuario";
                else if (combBoxPesquisa.Text == "Email") pesquisa = "email_usuario";
                else if (combBoxPesquisa.Text == "Telefone Celular") pesquisa = "tel_cel_usuario";
                else if (combBoxPesquisa.Text == "Telefone Fixo") pesquisa = "tel_fixo_usuario";
                else if (combBoxPesquisa.Text == "Data de Nascimento") pesquisa = "data_nasc_usuario";
                MySqlConnection objCon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                objCon.Open();
                DataSet conexaoDataset = new DataSet();
                string searchbanco = "SELECT id_usuario 'Id', nome_usuario 'Nome', email_usuario 'Email', DATE_FORMAT(data_nasc_usuario, '%d/%m/%Y') 'Data de Nascimento', tel_cel_usuario 'Telefone Celular', tel_fixo_usuario 'Telefone Fixo' FROM usuario WHERE " + pesquisa + " = '" + txtPesquisa.Text + "'";
                MySqlDataAdapter conexaoAdapter = new MySqlDataAdapter(searchbanco, objCon);

                conexaoAdapter.Fill(conexaoDataset, "usuario");
                dataGridView1.DataSource = conexaoDataset;
                dataGridView1.DataMember = "usuario";

                DataSet conexaoDataset2 = new DataSet();
                string searchbanco2 = "SELECT enderecousuario.id_usuario 'Id', endereco.estado 'Estado', endereco.cidade 'Cidade', endereco.bairro 'Bairro', endereco.CEP 'CEP', endereco.logradouro 'Rua', endereco.numero_endereco 'Numero' FROM endereco inner join enderecousuario on endereco.id_endereco = enderecousuario.id_endereco inner join usuario on usuario.id_usuario = enderecousuario.id_usuario where usuario." + pesquisa + " = '" + txtPesquisa.Text + "'";
                MySqlDataAdapter conexaoAdapter2 = new MySqlDataAdapter(searchbanco2, objCon);
                conexaoAdapter2.Fill(conexaoDataset2, "endereco");
                dataGridView2.DataSource = conexaoDataset2;
                dataGridView2.DataMember = "endereco";

                objCon.Close();
            }

        }

        //
        // Edita Usuários Cadastrados
        //
        private void CMEditar_Click(object sender, EventArgs e)
        {
            UsuarioCadastra frm = new UsuarioCadastra();

            frm.lbId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtDataNasc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtTelCel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.txtTelFix.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            frm.txtEstado.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            frm.txtCidade.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            frm.txtBairro.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            frm.txtCEP.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            frm.txtLogradouro.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            frm.txtNum.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();

            frm.Top = 38;
            frm.Left = 18;

            EventHandler handler = EditaUsu;
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
