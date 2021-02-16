using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.Util
{
    public static class AddressUtil
    {
        public static List<StateUtil> ListStates
        {
            get
            {
                return new List<StateUtil>
                {
                    new StateUtil("Acre", "AC"),
                    new StateUtil("Alagoas", "AL"),
                    new StateUtil("Amapá", "AP"),
                    new StateUtil("Amazonas", "AM"),
                    new StateUtil("Bahia", "BA"),
                    new StateUtil("Ceará", "CE"),
                    new StateUtil("Espírito Santo", "ES"),
                    new StateUtil("Goiás", "GO"),
                    new StateUtil("Maranhão", "MA"),
                    new StateUtil("Mato Grosso", "MT"),
                    new StateUtil("Mato Grosso do Sul", "MS"),
                    new StateUtil("Minas Gerais", "MG"),
                    new StateUtil("Pará", "PA"),
                    new StateUtil("Paraíba", "PB"),
                    new StateUtil("Paraná", "PR"),
                    new StateUtil("Pernambuco", "PE"),
                    new StateUtil("Piauí", "PI"),
                    new StateUtil("Rio de Janeiro", "RJ"),
                    new StateUtil("Rio Grande do Norte", "RN"),
                    new StateUtil("Rio Grande do Sul", "RS"),
                    new StateUtil("Rondônia", "RO"),
                    new StateUtil("Roraima", "RR"),
                    new StateUtil("Santa Catarina", "SC"),
                    new StateUtil("São Paulo", "SP"),
                    new StateUtil("Sergipe", "SE"),
                    new StateUtil("Tocantins", "TO"),
                    new StateUtil("Distrito Federal", "DF")
                }
                .OrderBy(x => x.FullName)
                .ToList();
            }
        }
    }

    public class StateUtil
    {
        public StateUtil(string fullName, string abbreviation)
        {
            FullName = fullName;
            Abbreviation = abbreviation;
        }
        public string Abbreviation { get; set; }
        public string FullName { get; set; }

    }
}
