using System.Text.RegularExpressions;

namespace ProjetoExemplo
{
    public static class Util
    {
        private static readonly int MaiorDeIdade = 18;

        public static int CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Today;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataAtual < dataNascimento.AddYears(idade))
            {
                idade--;
            }

            return idade;
        }

        public static bool GetMaiorDeIdade(int idade)
        {
            if (idade < MaiorDeIdade)
                return false;

            return true;
        }

        public static bool ValidateCPF(string cpf)
        {
            cpf = RemoverCaracteresEspeciais(cpf);

            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                return false;
            }

            int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cpfSemDigitos = cpf.Substring(0, 9);
            string digitoVerificador = cpf.Substring(9, 2);

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfSemDigitos[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }

            int resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string primeiroDigitoCalculado = resto.ToString();

            if (primeiroDigitoCalculado != digitoVerificador[0].ToString())
            {
                return false;
            }

            soma = 0;
            cpfSemDigitos += primeiroDigitoCalculado;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfSemDigitos[i].ToString()) * multiplicadoresSegundoDigito[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string segundoDigitoCalculado = resto.ToString();

            return segundoDigitoCalculado == digitoVerificador[1].ToString();
        }

        public static bool ValidarCNPJ(string cnpj)
        {
            cnpj = RemoverCaracteresEspeciais(cnpj);

            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14)
            {
                return false;
            }

            int[] multiplicadoresPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cnpjSemDigitos = cnpj.Substring(0, 12);
            string digitoVerificador = cnpj.Substring(12, 2);

            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpjSemDigitos[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }

            int resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string primeiroDigitoCalculado = resto.ToString();

            if (primeiroDigitoCalculado != digitoVerificador[0].ToString())
            {
                return false;
            }

            soma = 0;
            cnpjSemDigitos += primeiroDigitoCalculado;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpjSemDigitos[i].ToString()) * multiplicadoresSegundoDigito[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            string segundoDigitoCalculado = resto.ToString();

            return segundoDigitoCalculado == digitoVerificador[1].ToString();
        }

        public static string RemoverCaracteresEspeciais(string texto)
        {
            // Utiliza expressão regular para remover caracteres especiais
            string padrao = "[^a-zA-Z0-9]";
            string textoLimpo = Regex.Replace(texto, padrao, "");

            return textoLimpo;
        }
    }
}
