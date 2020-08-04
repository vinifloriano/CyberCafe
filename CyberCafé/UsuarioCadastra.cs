using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;


namespace CyberCafé
{
    public partial class UsuarioCadastra : UserControl
    {
        public UsuarioCadastra()
        {
            InitializeComponent();
            txtCidade.KeyPress += new KeyPressEventHandler(Validacoes.txtCidade_KeyPress);
            txtNome.KeyPress += new KeyPressEventHandler(Validacoes.txtNome_KeyPress);
            txtNum.KeyPress += new KeyPressEventHandler(Validacoes.txtNum_KeyPress);
        }

        //
        // Validações
        //
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

        private void txtConfSenha_Leave(object sender, EventArgs e)
        {
            if (txtConfSenha.Text != txtSenha.Text && txtConfSenha.Text != "")
            {
                MessageBox.Show("As senhas não conferem.");
                txtConfSenha.Clear();
                txtConfSenha.Focus();
            }
        }

        //
        // Mandar dados
        //
        public void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (!Validacoes.ValidaEmail(txtEmail.Text))
                MessageBox.Show("Insira seu email.");
            else if (txtSenha.Text.Length < 5)
                MessageBox.Show("Insira uma senha.");
            else if (txtConfSenha.Text != txtSenha.Text)
                MessageBox.Show("As senhas não conferem.");
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
                MySqlCommand cmdCli = new MySqlCommand("insert into usuario (nome_usuario, email_usuario, senha_usuario, data_nasc_usuario, tel_cel_usuario, tel_fixo_usuario) values (?,?,?,?,?,?)", objcon);
                //parametros
                cmdCli.Parameters.Add("@nome_usuario", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                cmdCli.Parameters.Add("@email_usuario", MySqlDbType.VarChar, 75).Value = txtEmail.Text;
                cmdCli.Parameters.Add("@senha_usuario", MySqlDbType.VarChar, 45).Value = txtSenha.Text;
                cmdCli.Parameters.Add("@data_nasc_usuario", MySqlDbType.Date).Value = dataNasc;
                cmdCli.Parameters.Add("@tel_cel_usuario", MySqlDbType.VarChar, 17).Value = txtTelCel.Text;
                cmdCli.Parameters.Add("@tel_fixo_usuario", MySqlDbType.VarChar, 13).Value = txtTelFix.Text;
                //comando para executar a query
                cmdCli.ExecuteNonQuery();

                Int32 id_usu = 0, id_end = 0;

                MySqlCommand Query = new MySqlCommand();
                Query.Connection = objcon;
                Query.CommandText = @"SELECT id_usuario FROM usuario ORDER BY id_usuario DESC LIMIT 1";
                MySqlDataReader dtreader = Query.ExecuteReader();
                if (dtreader.Read())
                    id_usu = int.Parse(dtreader["id_usuario"].ToString());
                dtreader.Close();
                MySqlCommand Query2 = new MySqlCommand();
                Query2.Connection = objcon;
                Query2.CommandText = @"SELECT id_endereco FROM endereco ORDER BY id_endereco DESC LIMIT 1";
                MySqlDataReader dtreader2 = Query2.ExecuteReader();
                if (dtreader2.Read())
                    id_end = int.Parse(dtreader2["id_endereco"].ToString());
                dtreader2.Close();
                MySqlCommand cmdEndCli = new MySqlCommand("insert into EnderecoUsuario (id_endereco, id_usuario) values (?,?)", objcon);
                cmdEndCli.Parameters.Add("@id_endereco", MySqlDbType.Int32).Value = id_end;
                cmdEndCli.Parameters.Add("@id_usuario", MySqlDbType.Int32).Value = id_usu;
                cmdEndCli.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Dados inseridos com sucesso!");
                TextBox[] txtsUsu = { txtNome, txtEmail, txtSenha, txtConfSenha, txtCidade, txtLogradouro, txtNum, txtComplemento, txtBairro };
                MaskedTextBox[] txts2Usu = { txtTelCel, txtTelFix, txtDataNasc, txtCEP };
                foreach (TextBox aux in txtsUsu) aux.Clear();
                foreach (MaskedTextBox aux in txts2Usu) aux.Clear();
                txtEstado.Text = "";

            }
        }

    }
}
