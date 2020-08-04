using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberCafé
{
    class FuncoesLayout
    {
        public static void UseCustomFont(int size, Label label)
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            int fontLength = Properties.Resources.poppins_light.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.poppins_light;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            label.Font = new Font(pfc.Families[0], size);
        }

        public GraphicsPath SuArredondaRect(Rectangle pRect, int pCanto, int lado)
        {
            GraphicsPath gp = new GraphicsPath();

            if (lado == 1)
            {
                gp.AddLine(pRect.X - 1, pRect.Y - 1, pRect.X + pRect.Width, pRect.Y - 1);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y - 1, pCanto, pCanto, 270, 90);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 0, 90);
                gp.AddLine(pRect.X + pRect.Width, pRect.Y + pRect.Height, pRect.X - 1, pRect.Y + pRect.Height);
            }
            else if (lado == 0)
            {
                gp.AddLine(pRect.X - 1, pRect.Y - 1, pRect.X + pRect.Width, pRect.Y - 1);
                gp.AddLine(pRect.X + pRect.Width, pRect.Y + pRect.Height, pRect.X - 1, pRect.Y + pRect.Height);
                gp.AddArc(pRect.X - 1, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 90, 90);
                gp.AddArc(pRect.X - 1, pRect.Y - 1, pCanto, pCanto, 180, 90);
            }
            else if (lado == 2)
            {
                gp.AddArc(pRect.X - 1, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 90, 90);
                gp.AddArc(pRect.X - 1, pRect.Y - 1, pCanto, pCanto, 180, 90);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y - 1, pCanto, pCanto, 270, 90);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 0, 90);
                gp.AddLine(pRect.X + pRect.Width, pRect.Y + pRect.Height, pRect.X - 1, pRect.Y + pRect.Height);
            }
            
            return gp;
        }

        public static void ArredondaPn(Panel pPanel, int pCanto, int lado)
        {
            Rectangle r = new Rectangle();
            r = pPanel.ClientRectangle;
            FuncoesLayout fl = new FuncoesLayout();
            pPanel.Region = new Region(fl.SuArredondaRect(r, pCanto, lado));
        }
        public static void ArredondaBt(Button pPanel, int pCanto, int lado)
        {
            Rectangle r = new Rectangle();
            r = pPanel.ClientRectangle;
            FuncoesLayout fl = new FuncoesLayout();
            pPanel.Region = new Region(fl.SuArredondaRect(r, pCanto, lado));
        }
    }
}
