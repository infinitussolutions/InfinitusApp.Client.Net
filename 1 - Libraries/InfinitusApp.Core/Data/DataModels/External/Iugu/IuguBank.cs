using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{
    public class IuguBank
    {
        public string Name { get; set; }
        public string Agency { get; set; }
        public string Number { get; set; }

        public string AgencyMask { get; set; }
        public string NumberMask { get; set; }
        public string NumberMaskObservation { get; set; }


        public int AgencyMaskLenght
        {
            get
            {
                return AgencyMask.Replace("-", "").Length;
            }
        }

        public int NumberMaskLenght
        {
            get
            {
                return NumberMask.Replace("-", "").Length;
            }
        }

        public string AgencyFormated
        {
            get
            {
                if (Agency == null)
                    return string.Empty;

                if (AgencyMask.Contains("-"))
                    return Agency.Insert(AgencyMask.IndexOf("-"), "-");

                return Agency;
            }
        }

        public string NumberFormated
        {
            get
            {
                if (Number == null)
                    return string.Empty;

                if (NumberMask.Contains("-"))
                    return Number.Insert(NumberMask.IndexOf("-"), "-");

                return Number;
            }
        }

        public static List<IuguBank> GetBanks()
        {
            return new List<IuguBank>
            {
                new IuguBank{ Name = "Banco do Brasil", AgencyMask = "9999-D", NumberMask = "99999999-D"},

                new IuguBank{ Name = "Santander", AgencyMask = "9999", NumberMask = "99999999-D"},

                new IuguBank{ Name = "Caixa Econômica", AgencyMask = "9999", NumberMask = "XXX99999999-D", NumberMaskObservation = "X: Operação"},

                new IuguBank{ Name = "Bradesco", AgencyMask = "9999-D", NumberMask = "9999999-D"},

                new IuguBank{ Name = "Itaú", AgencyMask = "9999", NumberMask = "99999-D"},

                new IuguBank{ Name = "Banrisul", AgencyMask = "9999", NumberMask = "999999999-D"},

                new IuguBank{ Name = "Sicredi", AgencyMask = "9999", NumberMask = "999999D"},

                new IuguBank{ Name = "Sicoob (Bancoob)", AgencyMask = "9999", NumberMask = "999999999-D"},

                new IuguBank{ Name = "Inter", AgencyMask = "9999", NumberMask = "999999999-D"},

                new IuguBank{ Name = "BRB", AgencyMask = "9999", NumberMask = "999999999-D"},

                new IuguBank{ Name = "Via Credi", AgencyMask = "9999", NumberMask = "99999999999-D"},

                new IuguBank{ Name = "Neon", AgencyMask = "9999", NumberMask = "9999999-D"},

                new IuguBank{ Name = "Votorantim", AgencyMask = "9999", NumberMask = "9999999-D"},

                new IuguBank{ Name = "Nubank", AgencyMask = "9999", NumberMask = "9999999999-D"},

                new IuguBank{ Name = "PagSeguro", AgencyMask = "9999", NumberMask = "99999999-D"},

                new IuguBank{ Name = "Banco Original", AgencyMask = "9999", NumberMask = "9999999-D"},

                new IuguBank{ Name = "Safra", AgencyMask = "9999", NumberMask = "99999999-D"},

                new IuguBank{ Name = "Modal", AgencyMask = "9999", NumberMask = "999999999-D"},

                new IuguBank{ Name = "Banestes", AgencyMask = "9999", NumberMask = "99999999-D"},

                new IuguBank{ Name = "Unicred", AgencyMask = "9999", NumberMask = "99999999-D"}

            }
            .OrderBy(x => x.Name).ToList();
        }

        public static List<string> GetBankAccountType()
        {
            return new List<string>
            {
                "Corrente",
                "Poupança"
            };
        }

        public string ErrorMessage
        {
            get
            {
                var msg = string.Empty;

                if (AgencyFormated.Length != AgencyMask.Length)
                    msg += "Agência inválida\n";

                if (NumberFormated.Length != NumberMask.Length)
                    msg += "Conta inválida\n";

                return msg;
            }
        }
    }
}
