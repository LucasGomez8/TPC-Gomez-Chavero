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

        public static bool validateDecimalNumber(string number)
        {
            Regex re = new Regex(@"^[0-9]+([,][0-9]+)?$");
            Match ma = re.Match(number);
                if (!ma.Success)
                {
                    return false;
                }
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
            if (dni.Length < 7 || dni.Length > 10)
            {
                lblError.Text = "Tiene que tener entre 7 y 10 caracteres...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = false;
            return true;
        }

        public static bool validateNumber(string numeroFac, Label lblError)
        {
            if (!numeroFac.All(char.IsDigit))
            {
                lblError.Text = "Solo puede contener numeros...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = true;
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

        public static bool validateInputPassword(string pass, Label lblError)
        {
            if (pass.Length < 8)
            {
                lblError.Text = "Tiene que tener minimo 8 caracteres...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = false;
            return true;
        }

        public static bool validateInputPositiveNumber(string number, Label lblError)
        {
            if (long.Parse(number) <= 0)
            {
                lblError.Text = "Solo se pueden ingresar valores positivos...";
                lblError.Visible = true;
                return false;
            }
            if (!number.All(char.IsDigit))
            {
                lblError.Text = "Solo puede contener numeros...";
                lblError.Visible = true;
                return false;
            }
            lblError.Visible = false;
            return true;
        }

    }
}
