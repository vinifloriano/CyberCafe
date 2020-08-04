using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;


namespace CyberCafé
{
    public partial class FuncionarioCadastra : UserControl
    {
        public FuncionarioCadastra()
        {
            InitializeComponent();
            txtCidade.KeyPress += new KeyPressEventHandler(Validacoes.txtCidade_KeyPress);
            txtNome.KeyPress += new KeyPressEventHandler(Validacoes.txtNome_KeyPress);
            txtNum.KeyPress += new KeyPressEventHandler(Validacoes.txtNum_KeyPress);
        }

        public void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (!Validacoes.ValidaEmail(txtEmail.Text))
                MessageBox.Show("Insira seu email.");
            else if (txtTelCel.Text.Contains(' '))
                MessageBox.Show("Insira um telefone celular.");
            else if (txtTelFix.Text.Contains(' '))
                MessageBox.Show("Insira um telefone fixo.");
            else if (!Validacoes.ValidaData(txtDataNasc.Text))
                MessageBox.Show("Insira uma data de nascimento correta.");
            else if (txtCEP.Text.Contains(' ') || txtEstado.Text.Contains(' ') || txtCidade.Text == " " || txtLogradouro.Text == " " || txtNum.Text == " ")
                MessageBox.Show("Preencha todos os campos do Endereço.");
            else
            {
                string[] datanascAntes = txtDataNasc.Text.Split('/');

                string dataNasc = datanascAntes[2] + '-' + datanascAntes[1] + '-' + datanascAntes[0];

                string[] datacontAntes = txtDataCont.Text.Split('/');

                string dataCont = datacontAntes[2] + '-' + datacontAntes[1] + '-' + datacontAntes[0];

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

                Int32  id_end = 0;

                MySqlCommand Query2 = new MySqlCommand();
                Query2.Connection = objcon;
                Query2.CommandText = @"SELECT id_endereco FROM endereco ORDER BY id_endereco DESC LIMIT 1";
                MySqlDataReader dtreader2 = Query2.ExecuteReader();
                if (dtreader2.Read())
                    id_end = int.Parse(dtreader2["id_endereco"].ToString());
                dtreader2.Close();
                // comando para inserir na tabela
                MySqlCommand cmdFunc = new MySqlCommand("insert into funcionario (nome_funcionario, email_funcionario, data_nasc_funcionario, tel_cel_func, tel_fixo_func, data_contratacao, id_endereco) values (?,?,?,?,?,?,?)", objcon);
                //parametros
                cmdFunc.Parameters.Add("@nome_funcionario", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                cmdFunc.Parameters.Add("@email_funcionario", MySqlDbType.VarChar, 75).Value = txtEmail.Text;
                cmdFunc.Parameters.Add("@data_nasc_funcionario", MySqlDbType.Date).Value = dataNasc;
                cmdFunc.Parameters.Add("@tel_cel_func", MySqlDbType.VarChar, 17).Value = txtTelCel.Text;
                cmdFunc.Parameters.Add("@tel_fixo_func", MySqlDbType.VarChar, 13).Value = txtTelFix.Text;
                cmdFunc.Parameters.Add("@data_contratacao", MySqlDbType.Date).Value = dataCont;
                cmdFunc.Parameters.Add("@id_endereco", MySqlDbType.Int32).Value = id_end;
                //comando para executar a query
                cmdFunc.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Dados inseridos com sucesso!");
                TextBox[] txtsFunc = { txtNome, txtEmail, txtCidade, txtLogradouro, txtNum, txtComplemento, txtBairro };
                MaskedTextBox[] txts2Func = { txtTelCel, txtTelFix, txtDataNasc, txtDataCont, txtCEP };
                foreach (TextBox aux in txtsFunc) aux.Clear();
                foreach (MaskedTextBox aux in txts2Func) aux.Clear();
                txtEstado.Text = "";
               

            }

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


    }
}
