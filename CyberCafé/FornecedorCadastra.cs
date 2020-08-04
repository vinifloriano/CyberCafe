using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace CyberCafé
{
    public partial class FornecedorCadastra : UserControl
    {
        public FornecedorCadastra()
        {
            InitializeComponent();
            txtCidade.KeyPress += new KeyPressEventHandler(Validacoes.txtCidade_KeyPress);
            txtNome.KeyPress += new KeyPressEventHandler(Validacoes.txtNome_KeyPress);
            txtNum.KeyPress += new KeyPressEventHandler(Validacoes.txtNum_KeyPress);
        }
        private void txtCEP_Leave(object sender, EventArgs e)
        {
            if (!txtCEP.Text.Contains(' '))
            {
                try
                {
                    string teste = txtCEP.Text;
                    teste = teste.Trim();
                    teste.Replace("-", "");

                    DataSet ds = new DataSet();
                    string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", teste);

                    ds.ReadXml(xml);
                    txtLogradouro.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                    txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                    txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                    txtEstado.Text = ds.Tables[0].Rows[0]["UF"].ToString();

                }
                catch
                {
                    MessageBox.Show("Digite um CEP válido");
                }
            }
        }

        public void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (!Validacoes.ValidaEmail(txtEmail.Text))
                MessageBox.Show("Insira seu email.");
            else if (txtCNPJ.Text.Contains(' '))
                MessageBox.Show("Insira um CNPJ correto.");
            else if (txtCEP.Text.Contains(' ') || txtEstado.Text.Contains(' ') || txtCidade.Text == " " || txtLogradouro.Text == " " || txtNum.Text == " ")
                MessageBox.Show("Preencha todos os campos do Endereço.");
            else
            {
                // passa a string de conexao
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                // abre o banco
                objcon.Open();
                // comando para inserir na tabela
                MySqlCommand cmdEnd = new MySqlCommand("insert into endereco (CEP, estado, cidade, bairro, logradouro, numero_endereco, complemento) values (?,?,?,?,?,?,?)", objcon);
                //parametros
                cmdEnd.Parameters.Add("@CEP", MySqlDbType.VarChar, 9).Value = txtCEP.Text;
                cmdEnd.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = txtEstado.Text;
                cmdEnd.Parameters.Add("@cidade", MySqlDbType.VarChar, 70).Value = txtCidade.Text;
                cmdEnd.Parameters.Add("@bairro", MySqlDbType.VarChar, 70).Value = txtBairro.Text;
                cmdEnd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtLogradouro.Text;
                cmdEnd.Parameters.Add("@numero_endereco", MySqlDbType.VarChar, 5).Value = txtNum.Text;
                cmdEnd.Parameters.Add("@complemento", MySqlDbType.VarChar, 45).Value = txtComplemento.Text;
                //comando para executar a query
                cmdEnd.ExecuteNonQuery();

                // comando para inserir na tabela
                MySqlCommand cmdFor = new MySqlCommand("insert into fornecedor (nome_fornecedor, email_fornecedor, cnpj) values (?,?,?)", objcon);
                //parametros
                cmdFor.Parameters.Add("@nome_fornecedor", MySqlDbType.VarChar, 70).Value = txtNome.Text;
                cmdFor.Parameters.Add("@email_fornecedor", MySqlDbType.VarChar, 70).Value = txtEmail.Text;
                cmdFor.Parameters.Add("@cnpj", MySqlDbType.VarChar, 18).Value = txtCNPJ.Text;
                //comando para executar a query
                cmdFor.ExecuteNonQuery();

                Int32 id_for = 0, id_end = 0;

                MySqlCommand Query = new MySqlCommand();
                Query.Connection = objcon;
                Query.CommandText = @"SELECT id_fornecedor FROM fornecedor ORDER BY id_fornecedor DESC LIMIT 1";
                MySqlDataReader dtreader = Query.ExecuteReader();
                if (dtreader.Read())
                    id_for = int.Parse(dtreader["id_fornecedor"].ToString());
                dtreader.Close();
                MySqlCommand Query2 = new MySqlCommand();
                Query2.Connection = objcon;
                Query2.CommandText = @"SELECT id_endereco FROM endereco ORDER BY id_endereco DESC LIMIT 1";
                MySqlDataReader dtreader2 = Query2.ExecuteReader();
                if (dtreader2.Read())
                    id_end = int.Parse(dtreader2["id_endereco"].ToString());
                dtreader2.Close();
                MySqlCommand cmdEndCli = new MySqlCommand("insert into EnderecoFornecedor (id_endereco, id_fornecedor) values (?,?)", objcon);
                cmdEndCli.Parameters.Add("@id_endereco", MySqlDbType.Int32).Value = id_end;
                cmdEndCli.Parameters.Add("@id_fornecedor", MySqlDbType.Int32).Value = id_for;
                cmdEndCli.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Dados inseridos com sucesso!");
                TextBox[] txtsForn = { txtNome, txtEmail, txtCidade, txtLogradouro, txtNum, txtComplemento, txtBairro };
                foreach (TextBox aux in txtsForn) aux.Clear();
                txtCNPJ.Clear();
                txtCEP.Clear();
                txtEstado.Text = "";
            }
        }
    }
}
