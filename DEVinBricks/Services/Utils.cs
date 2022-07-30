using System.Globalization;
using System.Text.RegularExpressions;

namespace DEVinBricks.Services
{
    public class Util
    {
        public static bool verificaDataNascimento(string dataNascimento)
        {
            return DateTime.TryParseExact(dataNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
        }
        public static string formataTelefone(string telefone)
        {
            return telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }
        public static string formataCPF(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").Replace(" ", "");
        }
        public static bool validaCPF(string cpf)
        {

            string valor = formataCPF(cpf);

            if (!validaNumero(valor))
                return false;

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        public static bool validaEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            return false;
        }
        public static bool validaNumero(string num)
        {
            Regex regex = new Regex("^\\d+$");
            Match match = regex.Match(num);
            if (match.Success)
                return true;
            return false;
        }
    }
}
