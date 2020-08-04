using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace CyberCafé
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            FuncoesLayout.ArredondaPn(pn_usu1, 45, 1);
            FuncoesLayout.ArredondaPn(pn_forn1, 45, 1);
            FuncoesLayout.ArredondaPn(pn_func1, 45, 1);
            FuncoesLayout.ArredondaPn(pn_prod1, 45, 1);
            FuncoesLayout.ArredondaPn(pn_comp1, 45, 1);
        }

        internal int i, h, h1, h2, h5, c = 0, esc = 0;
        Panel p;
        internal bool recolher_usu = false, recolher_forn = false, recolher_func = false, recolher_prod, recolher_comp;


        public event EventHandler FornCad_Click, UsuCad_Click, FuncCad_Click, ProdCad_Click, UsuEd_Click, FuncEd_Click, FornEd_Click, ProdEd_Click;

        private void lb_prod_edit_Click(object sender, EventArgs e)
        {
            EventHandler handler = ProdEd_Click;
            handler?.Invoke(this, e);
        }

        private void lb_f_edit_Click(object sender, EventArgs e)
        {
            EventHandler handler = FornEd_Click;
            handler?.Invoke(this, e);
        }

        private void lb_fun_edit_Click(object sender, EventArgs e)
        {
            EventHandler handler = FuncEd_Click;
            handler?.Invoke(this, e);
        }

        private void lbl_u_edi_Click(object sender, EventArgs e)
        {
            EventHandler handler = UsuEd_Click;
            handler?.Invoke(this, e);
        }

        private void lb_prod_cad_Click(object sender, EventArgs e)
        {
            EventHandler handler = ProdCad_Click;
            handler?.Invoke(this, e);
        }

        private void lbl_fun_cad_Click(object sender, EventArgs e)
        {
            EventHandler handler = FuncCad_Click;
            handler?.Invoke(this, e);
        }

        private void lbl_f_cad_Click(object sender, EventArgs e)
        {
            EventHandler handler = FornCad_Click;
            handler?.Invoke(this, e);
        }

        private void lbl_u_cad_Click(object sender, EventArgs e)
        {
            EventHandler handler = UsuCad_Click;
            handler?.Invoke(this, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (p == pn_forn2 && recolher_forn || p == pn_usu2 && recolher_usu || p == pn_func2 && recolher_func || p == pn_prod2 && recolher_prod || p == pn_comp2 && recolher_comp)
            {
                p.Height = Convert.ToInt32(h - 50 * (h / 1000d) * i);
                this.Height = Convert.ToInt32(this.Height - 5 * (h / 1000d) * i);
                pictureBox1.Top = Convert.ToInt32(pictureBox1.Top - 5 * (h / 1000d) * i);
                if (p == pn_usu2)
                {
                    pn_forn1.Top = Convert.ToInt32(pn_forn1.Top - 5 * (h / 1000d * i));
                    pn_forn2.Top = Convert.ToInt32(pn_forn2.Top - 5 * (h / 1000d * i));
                    pn_func1.Top = Convert.ToInt32(pn_func1.Top - 5 * (h / 1000d * i));
                    pn_func2.Top = Convert.ToInt32(pn_func2.Top - 5 * (h / 1000d * i));
                    pn_prod1.Top = Convert.ToInt32(pn_prod1.Top - 5 * (h / 1000d * i));
                    pn_prod2.Top = Convert.ToInt32(pn_prod2.Top - 5 * (h / 1000d * i));
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top - 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top - 5 * (h / 1000d * i));
                }
                else if (p == pn_forn2)
                {
                    pn_func1.Top = Convert.ToInt32(pn_func1.Top - 5 * (h / 1000d * i));
                    pn_func2.Top = Convert.ToInt32(pn_func2.Top - 5 * (h / 1000d * i));
                    pn_prod1.Top = Convert.ToInt32(pn_prod1.Top - 5 * (h / 1000d * i));
                    pn_prod2.Top = Convert.ToInt32(pn_prod2.Top - 5 * (h / 1000d * i));
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top - 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top - 5 * (h / 1000d * i));
                }
                else if (p == pn_func2)
                {
                    pn_prod1.Top = Convert.ToInt32(pn_prod1.Top - 5 * (h / 1000d * i));
                    pn_prod2.Top = Convert.ToInt32(pn_prod2.Top - 5 * (h / 1000d * i));
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top - 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top - 5 * (h / 1000d * i));
                }
                else if (p == pn_prod2)
                {
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top - 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top - 5 * (h / 1000d * i));
                }
                if (p.Height == 0)
                {
                    timer1.Enabled = false;
                    p = null;
                }
            }
            else if (p == pn_forn2 && !recolher_forn || p == pn_usu2 && !recolher_usu || p == pn_func2 && !recolher_func || p == pn_prod2 && !recolher_prod || p == pn_comp2 && !recolher_comp)
            {
                p.Height = Convert.ToInt32(50 * (h / 1000d) * i);
                this.Height = Convert.ToInt32(this.Height + 5 * (h / 1000d) * i);
                pictureBox1.Top = Convert.ToInt32(pictureBox1.Top + 5 * (h / 1000d) * i);
                if (p == pn_usu2)
                {
                    pn_forn1.Top = Convert.ToInt32(pn_forn1.Top + 5 * (h / 1000d * i));
                    pn_forn2.Top = Convert.ToInt32(pn_forn2.Top + 5 * (h / 1000d * i));
                    pn_func1.Top = Convert.ToInt32(pn_func1.Top + 5 * (h / 1000d * i));
                    pn_func2.Top = Convert.ToInt32(pn_func2.Top + 5 * (h / 1000d * i));
                    pn_prod1.Top = Convert.ToInt32(pn_prod1.Top + 5 * (h / 1000d * i));
                    pn_prod2.Top = Convert.ToInt32(pn_prod2.Top + 5 * (h / 1000d * i));
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top + 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top + 5 * (h / 1000d * i));
                }
                else if (p == pn_forn2)
                {
                    pn_func1.Top = Convert.ToInt32(pn_func1.Top + 5 * (h / 1000d * i));
                    pn_func2.Top = Convert.ToInt32(pn_func2.Top + 5 * (h / 1000d * i));
                    pn_prod1.Top = Convert.ToInt32(pn_prod1.Top + 5 * (h / 1000d * i));
                    pn_prod2.Top = Convert.ToInt32(pn_prod2.Top + 5 * (h / 1000d * i));
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top + 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top + 5 * (h / 1000d * i));
                }
                else if (p == pn_func2)
                {
                    pn_prod1.Top = Convert.ToInt32(pn_prod1.Top + 5 * (h / 1000d * i));
                    pn_prod2.Top = Convert.ToInt32(pn_prod2.Top + 5 * (h / 1000d * i));
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top + 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top + 5 * (h / 1000d * i));
                }
                else if (p == pn_prod2)
                {
                    pn_comp1.Top = Convert.ToInt32(pn_comp1.Top + 5 * (h / 1000d * i));
                    pn_comp2.Top = Convert.ToInt32(pn_comp2.Top + 5 * (h / 1000d * i));
                }
                if (p.Height >= h)
                {
                    timer1.Enabled = false;
                    p = null;
                }
            }
        }

        private void PN_Recolher1(object sender, EventArgs e)
        {
            i = 0;
            if (!recolher_usu)
            {
                recolher_usu = true;
                h2 = pn_usu2.Height;
            }
            else
                recolher_usu = false;
            h = h2;
            p = pn_usu2;
            timer1.Enabled = true;
        }

        private void PN_Recolher2(object sender, EventArgs e)
        {
            i = 0;
            if (!recolher_forn)
            {
                recolher_forn = true;
                h1 = pn_forn2.Height;
            }
            else
                recolher_forn = false;
            h = h1;
            p = pn_forn2;
            timer1.Enabled = true;

        }

        private void PN_Recolher5(object sender, EventArgs e)
        {
            i = 0;
            if (!recolher_func)
            {
                recolher_func = true;
                h5 = pn_func2.Height;
            }
            else
                recolher_func = false;
            h = h5;
            p = pn_func2;
            timer1.Enabled = true;
        }

        private void PN_Recolher6(object sender, EventArgs e)
        {
            i = 0;
            if (!recolher_prod)
            {
                recolher_prod = true;
                h5 = pn_prod2.Height;
            }
            else
                recolher_prod = false;
            h = h5;
            p = pn_prod2;
            timer1.Enabled = true;
        }

        private void PN_Recolher7(object sender, EventArgs e)
        {
            i = 0;
            if (!recolher_comp)
            {
                recolher_comp = true;
                h5 = pn_comp2.Height;
            }
            else
                recolher_comp = false;
            h = h5;
            p = pn_comp2;
            timer1.Enabled = true;
        }
    }
}
