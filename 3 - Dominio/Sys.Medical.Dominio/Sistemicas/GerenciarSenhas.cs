using System.Security.Cryptography;
using System.Text;

namespace Sys.Medical.Dominio.Sistemicas
{
    public static class GerenciarSenhas
    {
        private static string _salt = "gstualmc6hs99i4i^&#In@IBU@^V(";
        public static string ComputeHash(string password)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(_salt), 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return Convert.ToBase64String(hash);
        }

        public static bool IsValidPassword(string password)
        {
            // Verificar se a senha atende aos critérios de força
            if (password.Length < 6)
                return false;

            bool hasLetter = false, hasDigit = false, hasSpecialChar = false;
            foreach (char c in password)
            {
                if (char.IsLetter(c)) hasLetter = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSpecialChar = true;
            }

            return hasLetter && hasDigit && hasSpecialChar;
        }
    }
}
