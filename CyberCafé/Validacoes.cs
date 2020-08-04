using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CyberCafé
{
    class Validacoes
    {
        public static bool ValidaData(string data)
        {
            string[] datinhas = data.Split('/');
            int dia = int.Parse(datinhas[0]);
            int mes = int.Parse(datinhas[1]);
            int ano = int.Parse(datinhas[2]);

            bool valida = false;

            if (data.Length == 10)
            {
                if (!(ano >= 1900 && ano <= DateTime.Now.Year) || !(mes >= 1 && mes <= 12) || !(dia >= 1 && dia <= 31))
                    valida = false;
                else
                {
                    double resto = mes % 2d;
                    if (dia <= 28 && mes == 2)
                        valida = true;
                    if (mes < 8 && resto == 0 && dia == 31 || mes >= 8 && resto != 0 && dia == 31)
                        valida = false;
                    else
                        valida = true;
                }
            }
            else
            {
                valida = false;
            }
            return valida;
        }

        public static bool ValidaEmail(string email)
        {
            if (email.Contains('@'))
            {
                string usuario = email.Split('@')[0];
                string dominio = email.Split('@')[1];
                if (usuario.Length > 1 && dominio.Length > 3 && !dominio.Contains('@') && !usuario.Contains(' ') && !dominio.Contains(' ') && dominio.Contains('.'))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 127) || (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || (e.KeyChar > 127 && e.KeyChar < 167))
                e.Handled = false;
            else
                e.Handled = true;
        }

        public static void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == 8 || e.KeyChar == 127))
                e.Handled = true;
        }

        public static void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 127) || (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || (e.KeyChar > 127 && e.KeyChar < 167))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
