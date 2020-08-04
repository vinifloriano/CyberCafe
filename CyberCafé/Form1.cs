using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace CyberCafé
{
    public partial class Form1 : Form
    {
        public static int esc = 0;
        int x = 0, arrastaX, arrastaY;

        public Form1()
        {
            InitializeComponent();
            FuncoesLayout.UseCustomFont(21, lbl_cf1);
            FuncoesLayout.UseCustomFont(15, lblTitle);
            splitContainer1.Panel1.MouseWheel += pnRodaMenu;
            menu1.FuncCad_Click += lbl_fun_cad_Click;
            menu1.UsuCad_Click += lbl_u_cad_Click;
            menu1.FornCad_Click += lbl_f_cad_Click;
            menu1.ProdCad_Click += lbl_prod_cad_Click;
            menu1.UsuEd_Click += lbl_u_ed_Click;
            menu1.FuncEd_Click += lbl_fun_ed_Click;
            menu1.FornEd_Click += lbl_f_ed_Click;
            menu1.ProdEd_Click += lbl_prod_ed_Click;
            usuarioEdita1.EditaUsu += editaUsuario;
            funcionarioEdita1.EditaFunc += editaFuncionario;
            fornecedorEdita1.EditaForn += editaFornecedor;
            produtoEdita1.EditaProd += editaProduto;
        }


        //
        // Scroll do Menu
        //
        private void pnRodaMenu(object sender, MouseEventArgs e)
        {
            if(e.Delta == -120 && menu1.Height + menu1.Top > 569)
            {
                x-=40;
            }
            else if(e.Delta == 120 && menu1.Top < 61)
            {
                x+=40;
            }
            menu1.Top = x+61;
            lbl_cf1.Top = x + 31;
        }

        //
        // Mostra os Editar
        //

        // Edita Usuario
        UsuarioCadastra frmUsu;
        FuncionarioCadastra frmFunc;
        FornecedorCadastra frmForn;
        ProdutoCadastra frmProd;

        private void editaUsuario(object sender, EventArgs e)
        {
            frmUsu = sender as UsuarioCadastra;
            frmUsu.btnConfirmar.Click -= frmUsu.btnConfirmar_Click;
            frmUsu.btnConfirmar.Click += ConfEditarUsuario;
            splitContainer1.Panel2.Controls.Add(frmUsu);
            frmUsu.BringToFront();
        }

        private void editaFuncionario(object sender, EventArgs e)
        {
            frmFunc = sender as FuncionarioCadastra;
            frmFunc.btnConfirmar.Click -= frmFunc.btnConfirmar_Click;
            frmFunc.btnConfirmar.Click += ConfEditarFuncionario;
            splitContainer1.Panel2.Controls.Add(frmFunc);
            frmFunc.BringToFront();
        }

        private void editaFornecedor(object sender, EventArgs e)
        {
            frmForn = sender as FornecedorCadastra;
            frmForn.btnConfirmar.Click -= frmForn.btnConfirmar_Click;
            frmForn.btnConfirmar.Click += ConfEditarFornecedor;
            splitContainer1.Panel2.Controls.Add(frmForn);
            frmForn.BringToFront();
        }

        private void editaProduto(object sender, EventArgs e)
        {
            frmProd = sender as ProdutoCadastra;
            frmProd.btnConfirmar.Click -= frmProd.btnConfirmar_Click;
            frmProd.btnConfirmar.Click += ConfEditarProduto;
            splitContainer1.Panel2.Controls.Add(frmProd);
            frmProd.BringToFront();
        }

        private void ConfEditarUsuario(object sender, EventArgs e)
        {
            if (frmUsu.txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (!Validacoes.ValidaEmail(frmUsu.txtEmail.Text))
                MessageBox.Show("Insira seu email.");
            else if (frmUsu.txtSenha.Text.Length < 5)
                MessageBox.Show("Insira uma senha.");
            else if (frmUsu.txtConfSenha.Text != frmUsu.txtSenha.Text)
                MessageBox.Show("As senhas não conferem.");
            else if (frmUsu.txtTelCel.Text.Contains(' '))
                MessageBox.Show("Insira um telefone celular.");
            else if (frmUsu.txtTelFix.Text.Contains(' '))
                MessageBox.Show("Insira um telefone fixo.");
            else if (!Validacoes.ValidaData(frmUsu.txtDataNasc.Text))
                MessageBox.Show("Insira uma data de nascimento correta.");
            else if (frmUsu.txtCEP.Text.Contains(' ') || frmUsu.txtEstado.Text.Contains(' ') || frmUsu.txtCidade.Text == " " || frmUsu.txtLogradouro.Text == " " || frmUsu.txtNum.Text == " ")
                MessageBox.Show("Preencha todos os campos do Endereço.");
            else
            {
                string[] datanascAntes = frmUsu.txtDataNasc.Text.Split('/');

                string dataNasc = datanascAntes[2] + '-' + datanascAntes[1] + '-' + datanascAntes[0];

                // passa a string de conexao
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                // abre o banco
                objcon.Open();
                int id_end = 1;
                MySqlCommand Query2 = new MySqlCommand();
                Query2.Connection = objcon;
                Query2.CommandText = @"SELECT id_endereco FROM enderecousuario WHERE id_usuario = ?";
                Query2.Parameters.Add("@id_usuario", MySqlDbType.Int32).Value = int.Parse(frmUsu.lbId.Text);
                MySqlDataReader dtreader2 = Query2.ExecuteReader();
                if (dtreader2.Read())
                    id_end = int.Parse(dtreader2["id_endereco"].ToString());
                dtreader2.Close();

                MySqlCommand cmdEnd = new MySqlCommand("update endereco set CEP = ?, estado = ?, cidade = ?, bairro = ?, logradouro = ?, numero_endereco = ?, complemento = ? where id_endereco = ?", objcon);
                //parametros
                cmdEnd.Parameters.Add("@CEP", MySqlDbType.VarChar, 9).Value = frmUsu.txtCEP.Text;
                cmdEnd.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = frmUsu.txtEstado.Text;
                cmdEnd.Parameters.Add("@cidade", MySqlDbType.VarChar, 70).Value = frmUsu.txtCidade.Text;
                cmdEnd.Parameters.Add("@bairro", MySqlDbType.VarChar, 70).Value = frmUsu.txtBairro.Text;
                cmdEnd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = frmUsu.txtLogradouro.Text;
                cmdEnd.Parameters.Add("@numero_endereco", MySqlDbType.VarChar, 5).Value = frmUsu.txtNum.Text;
                cmdEnd.Parameters.Add("@complemento", MySqlDbType.VarChar, 45).Value = frmUsu.txtComplemento.Text;
                cmdEnd.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                //comando para executar a query
                cmdEnd.ExecuteNonQuery();

                // comando para inserir na tabela
                MySqlCommand cmdCli = new MySqlCommand("update usuario set nome_usuario = ?, email_usuario = ?, senha_usuario = ?, data_nasc_usuario = ?, tel_cel_usuario = ?, tel_fixo_usuario = ? where id_usuario = ?", objcon);
                //parametros
                cmdCli.Parameters.Add("@nome_usuario", MySqlDbType.VarChar, 100).Value = frmUsu.txtNome.Text;
                cmdCli.Parameters.Add("@email_usuario", MySqlDbType.VarChar, 75).Value = frmUsu.txtEmail.Text;
                cmdCli.Parameters.Add("@senha_usuario", MySqlDbType.VarChar, 45).Value = frmUsu.txtSenha.Text;
                cmdCli.Parameters.Add("@data_nasc_usuario", MySqlDbType.Date).Value = dataNasc;
                cmdCli.Parameters.Add("@tel_cel_usuario", MySqlDbType.VarChar, 17).Value = frmUsu.txtTelCel.Text;
                cmdCli.Parameters.Add("@tel_fixo_usuario", MySqlDbType.VarChar, 13).Value = frmUsu.txtTelFix.Text;
                cmdCli.Parameters.Add("@id_usuario", MySqlDbType.Int16).Value = int.Parse(frmUsu.lbId.Text);
                //comando para executar a query
                cmdCli.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Dados Alterados com sucesso!");
                usuarioEdita1.Atualiza();
                splitContainer1.Panel2.Controls.Remove(frmUsu);
                frmUsu = null;
                usuarioEdita1.Atualiza();
            }
        }

        private void ConfEditarFuncionario(object sender, EventArgs e)
        {
            if (frmFunc.txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (!Validacoes.ValidaEmail(frmFunc.txtEmail.Text))
                MessageBox.Show("Insira seu email.");
            else if (frmFunc.txtTelCel.Text.Contains(' '))
                MessageBox.Show("Insira um telefone celular.");
            else if (frmFunc.txtTelFix.Text.Contains(' '))
                MessageBox.Show("Insira um telefone fixo.");
            else if (!Validacoes.ValidaData(frmFunc.txtDataNasc.Text))
                MessageBox.Show("Insira uma data de nascimento correta.");
            else if (frmFunc.txtCEP.Text.Contains(' ') || frmFunc.txtEstado.Text.Contains(' ') || frmFunc.txtCidade.Text == " " || frmFunc.txtLogradouro.Text == " " || frmFunc.txtNum.Text == " ")
                MessageBox.Show("Preencha todos os campos do Endereço.");
            else
            {
                string[] datanascAntes = frmFunc.txtDataNasc.Text.Split('/');

                string dataNasc = datanascAntes[2] + '-' + datanascAntes[1] + '-' + datanascAntes[0];

                string[] datacontAntes = frmFunc.txtDataCont.Text.Split('/');

                string dataCont = datacontAntes[2] + '-' + datacontAntes[1] + '-' + datacontAntes[0];

                // passa a string de conexao
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                // abre o banco
                objcon.Open();
                int id_end = 1;
                MySqlCommand Query2 = new MySqlCommand();
                Query2.Connection = objcon;
                Query2.CommandText = @"SELECT id_endereco FROM funcionario WHERE id_funcionario = ?";
                Query2.Parameters.Add("@id_funcionario", MySqlDbType.Int32).Value = int.Parse(frmFunc.lbId.Text);
                MySqlDataReader dtreader2 = Query2.ExecuteReader();
                if (dtreader2.Read())
                    id_end = int.Parse(dtreader2["id_endereco"].ToString());
                dtreader2.Close();

                MySqlCommand cmdEnd = new MySqlCommand("update endereco set CEP = ?, estado = ?, cidade = ?, bairro = ?, logradouro = ?, numero_endereco = ?, complemento = ? where id_endereco = ?", objcon);
                //parametros
                cmdEnd.Parameters.Add("@CEP", MySqlDbType.VarChar, 9).Value = frmFunc.txtCEP.Text;
                cmdEnd.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = frmFunc.txtEstado.Text;
                cmdEnd.Parameters.Add("@cidade", MySqlDbType.VarChar, 70).Value = frmFunc.txtCidade.Text;
                cmdEnd.Parameters.Add("@bairro", MySqlDbType.VarChar, 70).Value = frmFunc.txtBairro.Text;
                cmdEnd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = frmFunc.txtLogradouro.Text;
                cmdEnd.Parameters.Add("@numero_endereco", MySqlDbType.VarChar, 5).Value = frmFunc.txtNum.Text;
                cmdEnd.Parameters.Add("@complemento", MySqlDbType.VarChar, 45).Value = frmFunc.txtComplemento.Text;
                cmdEnd.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                //comando para executar a query
                cmdEnd.ExecuteNonQuery();

                // comando para inserir na tabela
                MySqlCommand cmdFunc = new MySqlCommand("update funcionario set nome_funcionario = ?, email_funcionario = ?, data_nasc_funcionario = ?, data_contratacao = ?, tel_cel_func = ?, tel_fixo_func = ? where id_funcionario = ?", objcon);
                //parametros
                cmdFunc.Parameters.Add("@nome_funcionario", MySqlDbType.VarChar, 100).Value = frmFunc.txtNome.Text;
                cmdFunc.Parameters.Add("@email_funcionario", MySqlDbType.VarChar, 75).Value = frmFunc.txtEmail.Text;
                cmdFunc.Parameters.Add("@data_nasc_funcionario", MySqlDbType.Date).Value = dataNasc;
                cmdFunc.Parameters.Add("@data_contratacao", MySqlDbType.Date).Value = dataCont;
                cmdFunc.Parameters.Add("@tel_cel_func", MySqlDbType.VarChar, 17).Value = frmFunc.txtTelCel.Text;
                cmdFunc.Parameters.Add("@tel_fixo_func", MySqlDbType.VarChar, 13).Value = frmFunc.txtTelFix.Text;
                cmdFunc.Parameters.Add("@id_funcionario", MySqlDbType.Int16).Value = int.Parse(frmFunc.lbId.Text);
                //comando para executar a query
                cmdFunc.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Dados Alterados com sucesso!");
                funcionarioEdita1.Atualiza();
                splitContainer1.Panel2.Controls.Remove(frmFunc);
                frmFunc = null;
                funcionarioEdita1.Atualiza();
            }
        }

        private void ConfEditarFornecedor(object sender, EventArgs e)
        {
            if (frmForn.txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (!Validacoes.ValidaEmail(frmForn.txtEmail.Text))
                MessageBox.Show("Insira seu email.");
            if (frmForn.txtCNPJ.Text.Contains(' '))
                MessageBox.Show("Insira o CNPJ.");
            else if (frmForn.txtCEP.Text.Contains(' ') || frmForn.txtEstado.Text.Contains(' ') || frmForn.txtCidade.Text == " " || frmForn.txtLogradouro.Text == " " || frmForn.txtNum.Text == " ")
                MessageBox.Show("Preencha todos os campos do Endereço.");
            else
            {

                // passa a string de conexao
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                // abre o banco
                objcon.Open();
                int id_end = 1;
                MySqlCommand Query2 = new MySqlCommand();
                Query2.Connection = objcon;
                Query2.CommandText = @"SELECT id_endereco FROM enderecofornecedor WHERE id_fornecedor = ?";
                Query2.Parameters.Add("@id_fornecedor", MySqlDbType.Int32).Value = int.Parse(frmForn.lbId.Text);
                MySqlDataReader dtreader2 = Query2.ExecuteReader();
                if (dtreader2.Read())
                    id_end = int.Parse(dtreader2["id_endereco"].ToString());
                dtreader2.Close();

                MySqlCommand cmdEnd = new MySqlCommand("update endereco set CEP = ?, estado = ?, cidade = ?, bairro = ?, logradouro = ?, numero_endereco = ?, complemento = ? where id_endereco = ?", objcon);
                //parametros
                cmdEnd.Parameters.Add("@CEP", MySqlDbType.VarChar, 9).Value = frmForn.txtCEP.Text;
                cmdEnd.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = frmForn.txtEstado.Text;
                cmdEnd.Parameters.Add("@cidade", MySqlDbType.VarChar, 70).Value = frmForn.txtCidade.Text;
                cmdEnd.Parameters.Add("@bairro", MySqlDbType.VarChar, 70).Value = frmForn.txtBairro.Text;
                cmdEnd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = frmForn.txtLogradouro.Text;
                cmdEnd.Parameters.Add("@numero_endereco", MySqlDbType.VarChar, 5).Value = frmForn.txtNum.Text;
                cmdEnd.Parameters.Add("@complemento", MySqlDbType.VarChar, 45).Value = frmForn.txtComplemento.Text;
                cmdEnd.Parameters.Add("@id_endereco", MySqlDbType.Int16).Value = id_end;
                //comando para executar a query
                cmdEnd.ExecuteNonQuery();

                // comando para inserir na tabela
                MySqlCommand cmdCli = new MySqlCommand("update fornecedor set nome_fornecedor = ?, email_fornecedor = ?, cnpj = ? where id_fornecedor = ?", objcon);
                //parametros
                cmdCli.Parameters.Add("@nome_fornecedor", MySqlDbType.VarChar, 100).Value = frmForn.txtNome.Text;
                cmdCli.Parameters.Add("@email_fornecedor", MySqlDbType.VarChar, 75).Value = frmForn.txtEmail.Text;
                cmdCli.Parameters.Add("@cnpj", MySqlDbType.VarChar, 18).Value = frmForn.txtCNPJ.Text;
                cmdCli.Parameters.Add("@id_fornecedor", MySqlDbType.Int16).Value = int.Parse(frmForn.lbId.Text);
                //comando para executar a query
                cmdCli.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Dados Alterados com sucesso!");
                usuarioEdita1.Atualiza();
                splitContainer1.Panel2.Controls.Remove(frmForn);
                frmUsu = null;
                fornecedorEdita1.Atualiza();
            }
        }

        private void ConfEditarProduto(object sender, EventArgs e)
        {
            if (frmProd.txtNome.Text.Length < 5)
                MessageBox.Show("Insira o nome completo.");
            else if (frmProd.txtNum.Text == "")
                MessageBox.Show("Insira a quantidade.");
            else if (frmProd.txtPreco.Text == "")
                MessageBox.Show("Insira um preço.");
            else
            {
                // passa a string de conexao
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cybercafe");
                // abre o banco
                objcon.Open();
                // comando para inserir na tabela
                MySqlCommand cmdEnd = new MySqlCommand("update produto set nome_produto = ?, quantidade_produto = ?, preco_produto = ? WHERE id_produto = ?", objcon);
                //parametros
                cmdEnd.Parameters.Add("@nome_produto", MySqlDbType.VarChar, 9).Value = frmProd.txtNome.Text;
                cmdEnd.Parameters.Add("@quantidade_produto", MySqlDbType.Int16).Value = int.Parse(frmProd.txtNum.Text);
                cmdEnd.Parameters.Add("@preco_produto", MySqlDbType.Double).Value = frmProd.txtPreco.Text;
                cmdEnd.Parameters.Add("@id_produto", MySqlDbType.Int16).Value = int.Parse(frmProd.lbId.Text);
                //comando para executar a query
                cmdEnd.ExecuteNonQuery();

                objcon.Close();

                MessageBox.Show("Dados alterados com sucesso!");
                splitContainer1.Panel2.Controls.Remove(frmProd);
                frmProd = null;
                produtoEdita1.Atualiza();
            }
        }

        //
        // Botão Configuração
        //
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Config fmconf = new Config();
            if (esc == 1)
                fmconf.chkModoEsc.Checked = true;
            fmconf.ModoEscuro += ModoEscuro;
            fmconf.ShowDialog();
        }

        //
        // Botão Desligar
        //
        private void btnDesliga_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(("Tem certeza que deseja sair?"), "Sair do Programa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        //
        // Clique das Labels no menu
        //
        private void limpa_lbl()
        {
            Label[] limpa = {menu1.lbl_u_cad, menu1.lbl_u_lib, menu1.lbl_u_edi, menu1.lbl_u_pag, menu1.lbl_u_blo, menu1.lbl_f_cad, menu1.lbl_f_pag, menu1.lbl_fun_cad, menu1.lb_fun_edit, menu1.lb_prod_cad, menu1.lb_f_edit, menu1.lb_prod_edit};
            for(int i=0; i<limpa.Length; i++)
            {
                limpa[i].ForeColor = Color.White;
            }
        }

        public void lbl_u_cad_Click(object sender, EventArgs e)
        {
            usuarioCadastra1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "CADASTRO DE USUÁRIO";
            limpa_lbl();
            menu1.lbl_u_cad.ForeColor = Color.FromArgb(100,100,100);
        }

        public void lbl_u_ed_Click(object sender, EventArgs e)
        {
            usuarioEdita1.Atualiza();
            usuarioEdita1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "EDIÇÃO DE USUÁRIO";
            limpa_lbl();
            menu1.lbl_u_edi.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void lbl_f_cad_Click(object sender, EventArgs e)
        {
            fornecedorCadastra1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "CADASTRO DE FORNECEDOR";
            limpa_lbl();
            menu1.lbl_f_cad.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void lbl_f_ed_Click(object sender, EventArgs e)
        {
            fornecedorEdita1.Atualiza();
            fornecedorEdita1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "EDIÇÃO DE FORNECEDOR";
            limpa_lbl();
            menu1.lb_f_edit.ForeColor = Color.FromArgb(100, 100, 100);
        }
        private void lbl_fun_cad_Click(object sender, EventArgs e)
        {
            funcionarioCadastra1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "CADASTRO DE FUNCIONÁRIO";
            limpa_lbl();
            menu1.lbl_fun_cad.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void lbl_prod_cad_Click(object sender, EventArgs e)
        {
            produtoCadastra1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "CADASTRO DE PRODUTO";
            limpa_lbl();
            menu1.lb_prod_cad.ForeColor = Color.FromArgb(100, 100, 100);
        }
        private void lbl_prod_ed_Click(object sender, EventArgs e)
        {
            produtoEdita1.Atualiza();
            produtoEdita1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "EDIÇÃO DE PRODUTO";
            limpa_lbl();
            menu1.lb_prod_edit.ForeColor = Color.FromArgb(100, 100, 100);
        }
        private void lbl_fun_ed_Click(object sender, EventArgs e)
        {
            funcionarioEdita1.Atualiza();
            funcionarioEdita1.BringToFront();
            lblTitle.BringToFront();
            lblTitle.Text = "EDIÇÃO DE FUNCIONÁRIO";
            limpa_lbl();
            menu1.lb_fun_edit.ForeColor = Color.FromArgb(100, 100, 100);
        }

        //
        // Modo Escuro
        //
        public void ModoEscuro(object sender, EventArgs e)
        {
            if (esc == 0)
            {
                menu1.pn_func1.BackColor = Color.FromArgb(60, 64, 87);
                menu1.pn_forn1.BackColor = Color.FromArgb(60, 64, 87);
                menu1.pn_usu1.BackColor = Color.FromArgb(60, 64, 87);
                menu1.pn_prod1.BackColor = Color.FromArgb(60, 64, 87);
                menu1.pn_comp1.BackColor = Color.FromArgb(60, 64, 87);
                splitContainer1.BackColor = Color.FromArgb(0, 0, 0);
                this.BackColor = Color.FromArgb(10, 0, 61);
                lblTitle.ForeColor = Color.White;
                splitContainer1.Panel1.BackColor = Color.FromArgb(40, 44, 47);

                home1.pictureBox1.Image = Image.FromFile("img/icon-cafe(escuro).png");
                home1.richTextBox1.BackColor = Color.Black;

                TextBox[] txtsUsu = { usuarioCadastra1.txtNome, usuarioCadastra1.txtEmail, usuarioCadastra1.txtSenha, usuarioCadastra1.txtConfSenha, usuarioCadastra1.txtCidade, usuarioCadastra1.txtLogradouro, usuarioCadastra1.txtNum, usuarioCadastra1.txtComplemento, usuarioCadastra1.txtBairro };
                MaskedTextBox[] txts2Usu = { usuarioCadastra1.txtTelCel, usuarioCadastra1.txtTelFix, usuarioCadastra1.txtDataNasc, usuarioCadastra1.txtCEP };
                TextBox[] txtsFunc = { funcionarioCadastra1.txtNome, funcionarioCadastra1.txtEmail, funcionarioCadastra1.txtCidade, funcionarioCadastra1.txtLogradouro, funcionarioCadastra1.txtNum, funcionarioCadastra1.txtComplemento, funcionarioCadastra1.txtBairro };
                MaskedTextBox[] txts2Func = { funcionarioCadastra1.txtTelCel, funcionarioCadastra1.txtTelFix, funcionarioCadastra1.txtDataNasc, funcionarioCadastra1.txtCEP, funcionarioCadastra1.txtDataCont };
                TextBox[] txtsForn = { fornecedorCadastra1.txtNome, fornecedorCadastra1.txtEmail, fornecedorCadastra1.txtCidade, fornecedorCadastra1.txtLogradouro, fornecedorCadastra1.txtNum, fornecedorCadastra1.txtComplemento, fornecedorCadastra1.txtBairro };
                MaskedTextBox[] txts2Forn = {  fornecedorCadastra1.txtCEP, fornecedorCadastra1.txtCNPJ };
                TextBox[] txtsProd = { produtoCadastra1.txtNome, produtoCadastra1.txtNum, produtoCadastra1.txtPreco };

                Label[] lblsUsu = { usuarioCadastra1.lblBairro, usuarioCadastra1.lblNome, usuarioCadastra1.lblEmail, usuarioCadastra1.lblSenha, usuarioCadastra1.lblConfSenha, usuarioCadastra1.lblDataNasc, usuarioCadastra1.lblCEP, usuarioCadastra1.lblEstado, usuarioCadastra1.lblCidade, usuarioCadastra1.lblNum, usuarioCadastra1.lblComplemento, usuarioCadastra1.lblTelCel, usuarioCadastra1.lblTelFix, usuarioCadastra1.lblLogradouro };
                Label[] lblsFunc = { funcionarioCadastra1.lblBairro, funcionarioCadastra1.lblNome, funcionarioCadastra1.lblEmail, funcionarioCadastra1.lblDataNasc, funcionarioCadastra1.lblDataCont, funcionarioCadastra1.lblCEP, funcionarioCadastra1.lblEstado, funcionarioCadastra1.lblCidade, funcionarioCadastra1.lblNum, funcionarioCadastra1.lblComplemento, funcionarioCadastra1.lblTelCel, funcionarioCadastra1.lblTelFix, funcionarioCadastra1.lblLogradouro };
                Label[] lblsForn = { fornecedorCadastra1.lblBairro, fornecedorCadastra1.lblNome, fornecedorCadastra1.lblEmail, fornecedorCadastra1.lblCNPJ, fornecedorCadastra1.lblCEP, fornecedorCadastra1.lblEstado, fornecedorCadastra1.lblCidade, fornecedorCadastra1.lblNum, fornecedorCadastra1.lblComplemento, fornecedorCadastra1.lblLogradouro };
                Label[] lblsProd = { produtoCadastra1.lblNome, produtoCadastra1.lblNum, produtoCadastra1.lblPreco };

                foreach (TextBox aux in txtsUsu) aux.BackColor = Color.FromArgb(40, 44, 47);
                foreach (MaskedTextBox aux in txts2Usu) aux.BackColor = Color.FromArgb(40, 44, 47);
                usuarioCadastra1.txtEstado.BackColor = Color.FromArgb(40, 44, 47);
                foreach (TextBox aux in txtsFunc) aux.BackColor = Color.FromArgb(40, 44, 47);
                foreach (MaskedTextBox aux in txts2Func) aux.BackColor = Color.FromArgb(40, 44, 47);
                funcionarioCadastra1.txtEstado.BackColor = Color.FromArgb(40, 44, 47);
                foreach (TextBox aux in txtsForn) aux.BackColor = Color.FromArgb(40, 44, 47);
                foreach (MaskedTextBox aux in txts2Forn) aux.BackColor = Color.FromArgb(40, 44, 47);
                fornecedorCadastra1.txtEstado.BackColor = Color.FromArgb(40, 44, 47);
                foreach (TextBox aux in txtsProd) aux.BackColor = Color.FromArgb(40, 44, 47);

                foreach (Label aux in lblsUsu) aux.ForeColor = Color.White;
                foreach (Label aux in lblsFunc) aux.ForeColor = Color.White;
                foreach (Label aux in lblsForn) aux.ForeColor = Color.White;
                foreach (Label aux in lblsProd) aux.ForeColor = Color.White;

                usuarioEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                usuarioEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                usuarioEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 44, 47);
                usuarioEdita1.dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 47);
                usuarioEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                usuarioEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);
                usuarioEdita1.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                usuarioEdita1.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);

                funcionarioEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                funcionarioEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                funcionarioEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 44, 47);
                funcionarioEdita1.dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 47);
                funcionarioEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                funcionarioEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);
                funcionarioEdita1.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                funcionarioEdita1.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);

                fornecedorEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                fornecedorEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                fornecedorEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 44, 47);
                fornecedorEdita1.dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 47);
                fornecedorEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                fornecedorEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);
                fornecedorEdita1.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                fornecedorEdita1.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);

                produtoEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                produtoEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 44, 47);
                produtoEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 44, 47);
                produtoEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(60, 64, 87);
                produtoEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 44, 47);

                pictureBox1.Image = Image.FromFile("img/icon-gear(escuro).png");
                btnDesliga.Image = Image.FromFile("img/icon-off(escuro).png");
                usuarioEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(escuro).png");
                funcionarioEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(escuro).png");
                fornecedorEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(escuro).png");
                produtoEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(escuro).png");
                esc++;
            }
            else
            {
                menu1.pn_func1.BackColor = Color.FromArgb(40, 125, 161);
                menu1.pn_forn1.BackColor = Color.FromArgb(40, 125, 161);
                menu1.pn_usu1.BackColor = Color.FromArgb(40, 125, 161);
                menu1.pn_prod1.BackColor = Color.FromArgb(40, 125, 161);
                menu1.pn_comp1.BackColor = Color.FromArgb(40, 125, 161);
                splitContainer1.BackColor = Color.FromArgb(216, 231, 226);
                this.BackColor = Color.FromArgb(216, 231, 226);
                lblTitle.ForeColor = Color.FromArgb(40, 125, 161);
                splitContainer1.Panel1.BackColor = Color.FromArgb(0, 43, 73);

                home1.pictureBox1.Image = Image.FromFile("img/icon-cafe(claro).png");
                home1.richTextBox1.BackColor = Color.FromArgb(216, 231, 226);

                TextBox[] txtsUsu = { usuarioCadastra1.txtNome, usuarioCadastra1.txtEmail, usuarioCadastra1.txtSenha, usuarioCadastra1.txtConfSenha, usuarioCadastra1.txtCidade, usuarioCadastra1.txtLogradouro, usuarioCadastra1.txtNum, usuarioCadastra1.txtComplemento, usuarioCadastra1.txtBairro };
                MaskedTextBox[] txts2Usu = { usuarioCadastra1.txtTelCel, usuarioCadastra1.txtTelFix, usuarioCadastra1.txtDataNasc, usuarioCadastra1.txtCEP };
                TextBox[] txtsFunc = { funcionarioCadastra1.txtNome, funcionarioCadastra1.txtEmail, funcionarioCadastra1.txtCidade, funcionarioCadastra1.txtLogradouro, funcionarioCadastra1.txtNum, funcionarioCadastra1.txtComplemento, funcionarioCadastra1.txtBairro };
                MaskedTextBox[] txts2Func = { funcionarioCadastra1.txtTelCel, funcionarioCadastra1.txtTelFix, funcionarioCadastra1.txtDataNasc, funcionarioCadastra1.txtCEP, funcionarioCadastra1.txtDataCont };
                TextBox[] txtsForn = { fornecedorCadastra1.txtNome, fornecedorCadastra1.txtEmail, fornecedorCadastra1.txtCidade, fornecedorCadastra1.txtLogradouro, fornecedorCadastra1.txtNum, fornecedorCadastra1.txtComplemento, fornecedorCadastra1.txtBairro };
                MaskedTextBox[] txts2Forn = { fornecedorCadastra1.txtCEP, fornecedorCadastra1.txtCNPJ };
                TextBox[] txtsProd = { produtoCadastra1.txtNome, produtoCadastra1.txtNum, produtoCadastra1.txtPreco };

                Label[] lblsUsu = { usuarioCadastra1.lblBairro, usuarioCadastra1.lblNome, usuarioCadastra1.lblEmail, usuarioCadastra1.lblSenha, usuarioCadastra1.lblConfSenha, usuarioCadastra1.lblDataNasc, usuarioCadastra1.lblCEP, usuarioCadastra1.lblEstado, usuarioCadastra1.lblCidade, usuarioCadastra1.lblNum, usuarioCadastra1.lblComplemento, usuarioCadastra1.lblTelCel, usuarioCadastra1.lblTelFix, usuarioCadastra1.lblLogradouro };
                Label[] lblsFunc = { funcionarioCadastra1.lblBairro, funcionarioCadastra1.lblNome, funcionarioCadastra1.lblEmail, funcionarioCadastra1.lblDataNasc, funcionarioCadastra1.lblDataCont, funcionarioCadastra1.lblCEP, funcionarioCadastra1.lblEstado, funcionarioCadastra1.lblCidade, funcionarioCadastra1.lblNum, funcionarioCadastra1.lblComplemento, funcionarioCadastra1.lblTelCel, funcionarioCadastra1.lblTelFix, funcionarioCadastra1.lblLogradouro };
                Label[] lblsForn = { fornecedorCadastra1.lblBairro, fornecedorCadastra1.lblNome, fornecedorCadastra1.lblEmail, fornecedorCadastra1.lblCNPJ, fornecedorCadastra1.lblCEP, fornecedorCadastra1.lblEstado, fornecedorCadastra1.lblCidade, fornecedorCadastra1.lblNum, fornecedorCadastra1.lblComplemento, fornecedorCadastra1.lblLogradouro };
                Label[] lblsProd = { produtoCadastra1.lblNome, produtoCadastra1.lblNum, produtoCadastra1.lblPreco };

                foreach (TextBox aux in txtsUsu) aux.BackColor = Color.FromArgb(40, 125, 161);
                foreach (MaskedTextBox aux in txts2Usu) aux.BackColor = Color.FromArgb(40, 125, 161);
                usuarioCadastra1.txtEstado.BackColor = Color.FromArgb(40, 125, 161);
                foreach (TextBox aux in txtsFunc) aux.BackColor = Color.FromArgb(40, 125, 161);
                foreach (MaskedTextBox aux in txts2Func) aux.BackColor = Color.FromArgb(40, 125, 161);
                funcionarioCadastra1.txtEstado.BackColor = Color.FromArgb(40, 125, 161);
                foreach (TextBox aux in txtsForn) aux.BackColor = Color.FromArgb(40, 125, 161);
                foreach (MaskedTextBox aux in txts2Forn) aux.BackColor = Color.FromArgb(40, 125, 161);
                fornecedorCadastra1.txtEstado.BackColor = Color.FromArgb(40, 125, 161);
                foreach (TextBox aux in txtsProd) aux.BackColor = Color.FromArgb(40, 125, 161);

                foreach (Label aux in lblsUsu) aux.ForeColor = Color.FromArgb(0, 43, 73);
                foreach (Label aux in lblsFunc) aux.ForeColor = Color.FromArgb(0, 43, 73);
                foreach (Label aux in lblsForn) aux.ForeColor = Color.FromArgb(0, 43, 73);
                foreach (Label aux in lblsProd) aux.ForeColor = Color.FromArgb(0, 43, 73);

                // Deve ter uma forma bem mais facil de fazer isso, boa sorte em encontrar s2

                usuarioEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                usuarioEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                usuarioEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 125, 161);
                usuarioEdita1.dataGridView2.BackgroundColor = Color.FromArgb(40, 125, 161);
                usuarioEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                usuarioEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);
                usuarioEdita1.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                usuarioEdita1.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);

                funcionarioEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                funcionarioEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                funcionarioEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 125, 161);
                funcionarioEdita1.dataGridView2.BackgroundColor = Color.FromArgb(40, 125, 161);
                funcionarioEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                funcionarioEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);
                funcionarioEdita1.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                funcionarioEdita1.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);

                fornecedorEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                fornecedorEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                fornecedorEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 125, 161);
                fornecedorEdita1.dataGridView2.BackgroundColor = Color.FromArgb(40, 125, 161);
                fornecedorEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                fornecedorEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);
                fornecedorEdita1.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                fornecedorEdita1.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);

                produtoEdita1.combBoxPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                produtoEdita1.txtPesquisa.BackColor = Color.FromArgb(40, 125, 161);
                produtoEdita1.dataGridView1.BackgroundColor = Color.FromArgb(40, 125, 161);
                produtoEdita1.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(0, 43, 73);
                produtoEdita1.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 125, 161);

                pictureBox1.Image = Image.FromFile("img/icon-gear(claro).png");
                btnDesliga.Image = Image.FromFile("img/icon-off(claro).png");

                usuarioEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(claro).png");
                funcionarioEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(claro).png");
                fornecedorEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(claro).png");
                produtoEdita1.btnPesquisa.Image = Image.FromFile("img/icon-pesquisa(claro).png");

                esc--;
            }
        }

        //
        // Arrastar o Formulário
        //
        private void pnArrasta1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = arrastaX + MousePosition.X;
            this.Top = arrastaY + MousePosition.Y;
        }

        private void pnArrasta1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            arrastaX = this.Left - MousePosition.X;
            arrastaY = this.Top - MousePosition.Y;
        }
    }

}
