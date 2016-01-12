using System;
using System.Text.RegularExpressions;

namespace Britanico.Utilitario.ValidacionesForms
{
    public class GeneralValidation
    {

        public static bool IsEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }


        public static bool IsString(string Cadena)
        {
            string strRegex = "[a-zA-Z]";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Cadena))
                return (true);
            else
                return (false);
        }

        public static bool IsFono(string Fono)
        {
            string strRegex = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Fono))
                return (true);
            else
                return (false);
        }

        public static bool IsCelular(string Celular)
        {
            string strRegex = @"((\(\d{3}\) ?)|(\d{3}-))?\d{8}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Celular))
                return (true);
            else
                return (false);
        }


        public static bool IsDecimal(string Decimal)
        {
            string strRegex = @"^\$?[+-]?[\d,]*\.?\d{0,6}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Decimal))
                return (true);
            else
                return (false);
        }

        public static bool IsInteger(string Entero)
        {
            //periodo de gracia
            string strRegex = "[0-6]";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Entero))
                return (true);
            else
                return (false);
        }

        public static bool IsIntegerOtros(string Entero)
        {
            //para los demas
            string strRegex = @"[0-9]\{3}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Entero))
                return (true);
            else
                return (false);
        }

        public static bool periodoGracia(string valor)
        {
            //if(valor.isdi)

            Int32 entero = Convert.ToInt32(valor);
            if (entero > 6 && entero < 0)
                return (false);
            else
                return (true);
        }

        public static bool diaPago(string valor)
        {
            Int32 entero = Convert.ToInt32(valor);
            if (entero > 31 && entero < 0)
                return (false);
            else
                return (true);
        }

        public static bool plazo(string valor)
        {
            Int32 entero = Convert.ToInt32(valor);
            if (entero > 120 && entero < 6)
                return (false);
            else
                return (true);
        }

    }

}