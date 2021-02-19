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
                    new StateUtil("Amapá", "AP", "Amapa"),
                    new StateUtil("Amazonas", "AM"),
                    new StateUtil("Bahia", "BA"),
                    new StateUtil("Ceará", "CE", "Ceara"),
                    new StateUtil("Espírito Santo", "ES", "Espirito Santo"),
                    new StateUtil("Goiás", "GO", "Goias"),
                    new StateUtil("Maranhão", "MA", "Maranhao"),
                    new StateUtil("Mato Grosso", "MT"),
                    new StateUtil("Mato Grosso do Sul", "MS"),
                    new StateUtil("Minas Gerais", "MG"),
                    new StateUtil("Pará", "PA", "Para"),
                    new StateUtil("Paraíba", "PB", "Paraiba"),
                    new StateUtil("Paraná", "PR", "Parana"),
                    new StateUtil("Pernambuco", "PE"),
                    new StateUtil("Piauí", "PI", "Piaui" ),
                    new StateUtil("Rio de Janeiro", "RJ"),
                    new StateUtil("Rio Grande do Norte", "RN"),
                    new StateUtil("Rio Grande do Sul", "RS"),
                    new StateUtil("Rondônia", "RO", "Rondonia" ),
                    new StateUtil("Roraima", "RR"),
                    new StateUtil("Santa Catarina", "SC"),
                    new StateUtil("São Paulo", "SP", "Sao Paulo"),
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
        public StateUtil(string fullName, string abbreviation, string fullNameWithoutAccent = null)
        {
            FullName = fullName;
            FullNameWithoutAccent = fullNameWithoutAccent;
            Abbreviation = abbreviation;
        }
        public string Abbreviation { get; set; }
        public string FullName { get; set; }
        public string FullNameWithoutAccent { get; set; }

        public bool StringIsEqual(string state)
        {
            if (string.IsNullOrEmpty(state))
                return false;

            state = state.Replace(" ", "").ToUpper();

            return 
                state.Equals(Abbreviation.ToUpper()) 
                || state.Equals(FullName.ToUpper()) 
                || state.Equals(FullNameWithoutAccent.ToUpper())
                ;
        }
    }
}
