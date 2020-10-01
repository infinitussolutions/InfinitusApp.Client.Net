using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{
    public class IuguBank
    {
        public string Name { get; set; }
        public string BankNumber { get; set; }
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

                while (Agency.Length < AgencyMaskLenght)
                {
                    Agency = Agency.Insert(0, "0");
                }

                if (AgencyMask.Contains("-"))
                    return Agency.Insert(Agency.Length - 1, "-");

                return Agency;
            }
        }

        public string NumberFormated
        {
            get
            {
                if (Number == null || Number.Length < 4)
                    return string.Empty;

                while (Number.Length < NumberMaskLenght)
                {
                    Number = Number.Insert(0, "0");
                }

                if (NumberMask.Contains("-"))
                    return Number.Insert(Number.Length - 1, "-");

                return Number;
            }
        }

        public string NamePresentation 
        {
            get
            {
                return string.Format("{0} - {1}", BankNumber, Name);
            }
        }

        public static List<IuguBank> GetBanks()
        {
            return new List<IuguBank>
            {
                new IuguBank{ Name = "Banco do Brasil", AgencyMask = "9999-D", NumberMask = "99999999-D", BankNumber = "001"},

                new IuguBank{ Name = "Santander", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "033"},

                new IuguBank{ Name = "Caixa Econômica", AgencyMask = "9999", NumberMask = "XXX99999999-D", NumberMaskObservation = "X: Operação", BankNumber = "104"},

                new IuguBank{ Name = "Bradesco", AgencyMask = "9999-D", NumberMask = "9999999-D", BankNumber = "237"},

                new IuguBank{ Name = "Itaú", AgencyMask = "9999", NumberMask = "99999-D", BankNumber = "341"},

                new IuguBank{ Name = "Banrisul", AgencyMask = "9999", NumberMask = "999999999-D", BankNumber = "041"},

                new IuguBank{ Name = "Sicredi", AgencyMask = "9999", NumberMask = "999999D", BankNumber = "748"},

                new IuguBank{ Name = "Sicoob (Bancoob)", AgencyMask = "9999", NumberMask = "999999999-D", BankNumber = "756"},

                new IuguBank{ Name = "Inter", AgencyMask = "9999", NumberMask = "999999999-D", BankNumber = "077"},

                new IuguBank{ Name = "BRB", AgencyMask = "9999", NumberMask = "999999999-D", BankNumber = "070"},

                new IuguBank{ Name = "Via Credi", AgencyMask = "9999", NumberMask = "99999999999-D", BankNumber = "085"},

                new IuguBank{ Name = "Neon/Votorantim", AgencyMask = "9999", NumberMask = "9999999-D", BankNumber = "655"},

                new IuguBank{ Name = "Nubank", AgencyMask = "9999", NumberMask = "9999999999-D", BankNumber = "260"},

                new IuguBank{ Name = "PagSeguro", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "290"},

                new IuguBank{ Name = "Banco Original", AgencyMask = "9999", NumberMask = "9999999-D", BankNumber = "212"},

                new IuguBank{ Name = "Safra", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "422"},

                new IuguBank{ Name = "Modal", AgencyMask = "9999", NumberMask = "999999999-D", BankNumber = "746"},

                new IuguBank{ Name = "Banestes", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "021"},

                new IuguBank{ Name = "Unicred", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "136"},

                new IuguBank{ Name = "Money Plus", AgencyMask = "9", NumberMask = "99999999-D", BankNumber = "274"},

                new IuguBank{ Name = "Mercantil do Brasil", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "389"},

                new IuguBank{ Name = "JP Morgan", AgencyMask = "9999", NumberMask = "99999999999-D", BankNumber = "376"},

                new IuguBank{ Name = "Gerencianet Pagamentos do Brasil", AgencyMask = "9999", NumberMask = "99999999-D", BankNumber = "364"},

                new IuguBank{ Name = "C6 Bank", AgencyMask = "9999", NumberMask = "	9999999-D", BankNumber = "336"},

                new IuguBank{ Name = "BS2", AgencyMask = "9999", NumberMask = "	999999-D", BankNumber = "218"},

                new IuguBank{ Name = "Banco Topazio", AgencyMask = "9999", NumberMask = "99999-D", BankNumber = "082"},

                new IuguBank{ Name = "Uniprime", AgencyMask = "9999", NumberMask = "9999-D", BankNumber = "099"},

                new IuguBank{ Name = "Banco Stone", AgencyMask = "9999", NumberMask = "999999-D", BankNumber = "197"}

            }
            .OrderBy(x => x.BankNumber).ToList();
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
