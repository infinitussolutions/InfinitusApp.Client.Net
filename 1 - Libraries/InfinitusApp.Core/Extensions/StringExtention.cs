using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfinitusApp.Core.Extensions
{
    public static class StringExtention
    {
        public static List<string> HappyMessages
        {
            get
            {
                return new List<string>
                {
                    "ISSO AI, VOCÊ CONSEGUIU!",
                    "VOCÊ CONQUISTOU!",
                    "BOAAA, VOCÊ CHEGOU LÁ!",
                };
            }
        }

        public static string GetARandomHappyMessage { get { return HappyMessages.PickRandom(); } }

        public static bool IsNumber(this string valeu)
        {
            return int.TryParse(valeu, out int n);
        }

        public static bool ContainsNumber(this string value)
        {
            try
            {
                if (value == null)
                    return false;

                if (value.Where(x => char.IsNumber(x)).Count() > 0)
                    return true;

                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ContainsLetters(this string value)
        {
            try
            {
                if (value == null)
                    return false;

                if (value.Where(x => char.IsLetter(x)).Count() > 0)
                    return true;

                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsCNPJ(this string cnpj)
        {
            try
            {
                if (string.IsNullOrEmpty(cnpj))
                    return false;

                int[] mt1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] mt2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma; int resto; string digito; string TempCNPJ;

                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cnpj.Length != 14)
                    return false;

                if (cnpj == "00000000000000" || cnpj == "11111111111111" ||
                 cnpj == "22222222222222" || cnpj == "33333333333333" ||
                 cnpj == "44444444444444" || cnpj == "55555555555555" ||
                 cnpj == "66666666666666" || cnpj == "77777777777777" ||
                 cnpj == "88888888888888" || cnpj == "99999999999999")
                    return false;

                TempCNPJ = cnpj.Substring(0, 12);

                soma = 0;

                for (int i = 0; i < 12; i++)
                    soma += int.Parse(TempCNPJ[i].ToString()) * mt1[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;

                else
                    resto = 11 - resto;

                digito = resto.ToString();

                TempCNPJ = TempCNPJ + digito;

                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(TempCNPJ[i].ToString()) * mt2[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;

                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsCPF(this string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf))
                    return false;

                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;

                cpf = cpf.Trim();

                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                switch (cpf)
                {
                    case "11111111111":
                        return false;
                    case "00000000000":
                        return false;
                    case "2222222222":
                        return false;
                    case "33333333333":
                        return false;
                    case "44444444444":
                        return false;
                    case "55555555555":
                        return false;
                    case "66666666666":
                        return false;
                    case "77777777777":
                        return false;
                    case "88888888888":
                        return false;
                    case "99999999999":
                        return false;
                }

                tempCpf = cpf.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;

                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }

            catch (Exception e)
            {
                return false;
            }
        }

        public static string GetStringBetweenTags(string text, string startTag, string endTag)
        {
            int startIndex = text.IndexOf(startTag) + startTag.Length;
            int endIndex = text.IndexOf(endTag, startIndex);
            return text.Substring(startIndex, endIndex - startIndex);
        }
    }
}
