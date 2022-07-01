using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace helpers
{
    public static class FormHelper
    {
        public static bool validateInputEmail(string email, Label lblError)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                lblError.Text = "Por favor indique un mail valido...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = false;
            return true;
        }

        public static bool validateInputDniOrCuit(string dni, Label lblError)
        {
            if (!dni.All(char.IsDigit))
            {
                lblError.Text = "Solo puede contener numeros...";
                lblError.Visible = true;
                return false;
            }
            if (dni.Length < 7)
            {
                lblError.Text = "Tiene que tener minimo 7 digitos...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = false;
            return true;
        }

        public static bool validateInputPhone(string phone, Label lblError)
        {
            if (!phone.All(char.IsDigit))
            {
                lblError.Text = "Solo puede contener numeros...";
                lblError.Visible = true;
                return false;
            }
            if (phone.Length < 8)
            {
                lblError.Text = "Tiene que tener minimo 8 digitos...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = false;
            return true;
        }

    }
}
