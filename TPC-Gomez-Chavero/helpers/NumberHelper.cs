using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helpers
{
    public static class NumberHelper
    {
        public static void inputOnlyNumberWithDeicmals(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            TextBox txtBox = (TextBox)sender;
            // only allow one decimal point
            if ((e.KeyChar == ','))
            {
                if ((txtBox.Text.IndexOf(',') > -1))
                {
                    e.Handled = true;
                }
            }

            // only allow two decimals number
           int idxPoint = txtBox.Text.IndexOf(",");
            if (idxPoint != -1 && !(e.KeyChar == (char)Keys.Back))
            {
                if (txtBox.Text.Length - idxPoint >= 3)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
