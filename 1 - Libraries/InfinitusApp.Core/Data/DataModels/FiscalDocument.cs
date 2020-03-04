using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FiscalDocument
    {
        public string Company { get; set; }

        public string AccessKey { get; set; }

        public string Total { get; set; }

        public string Uri { get; set; }

        public decimal TotalDecimal { get { return !string.IsNullOrEmpty(Total) ? Convert.ToDecimal(Total) : 0; } }

        public string TotalPresentation { get { return TotalDecimal.ToString("C"); } }

        public ExtractFromAccessKey InfoFromAccessKey { get { return new ExtractFromAccessKey(this.AccessKey); } }
    }

    /// <summary>
    /// Format: https://www.oobj.com.br/bc/article/como-%C3%A9-formada-a-chave-de-acesso-de-uma-nf-e-nfc-e-de-um-ct-e-e-um-mdf-e-281.html
    /// </summary>
    public class ExtractFromAccessKey
    {
        protected string AccessKey { get; set; }

        public ExtractFromAccessKey(string _accessKey)
        {
            AccessKey = _accessKey;
        }

        public string UfCode { get { return HasAccessKey ? AccessKey.Substring(0, 2) : ""; } }

        public int Year { get { return HasAccessKey ? Convert.ToInt32(AccessKey.Substring(2, 2)) : 0; } }

        public int Month { get { return HasAccessKey ? Convert.ToInt32(AccessKey.Substring(4, 2)) : 0; } }

        public string CnpjCompany { get { return HasAccessKey ? AccessKey.Substring(6, 14) : ""; } }

        /// <summary>
        /// More info : http://www.sefaz.go.gov.br/NETACCESS/AIDF_Eletronica/ModeloAidf/001frmListaDocumentosAIDF.asp
        /// </summary>
        public string DocModel { get { return HasAccessKey ? AccessKey.Substring(20, 2) : ""; } }

        public string DocSerie { get { return HasAccessKey ? AccessKey.Substring(22, 3) : ""; } }

        public string DocNumber { get { return HasAccessKey ? AccessKey.Substring(25, 9) : ""; } }

        public string ResumeInfo { get { return HasAccessKey ? "Nº " + DocNumber + " SÉRIE: " + DocSerie + " DATA: " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(Month) + " de 20" + Year : ""; } }

        public bool HasAccessKey { get { return !string.IsNullOrEmpty(AccessKey); } }
    }
}
