using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Services.Custom.Bionostic.Models
{
    public class BionosticMedicalReport
    {
        [JsonProperty("req_id")]
        public string RequestId { get; set; }
        [JsonProperty("exame_id")]
        public string MedicalReportId { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }
        [JsonProperty("metodo")]
        public string Method { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("atributos")]
        public List<MedicalReportAttribute> Attributes { get; set; }
        [JsonProperty("obs")]
        public List<MedicalReportObservation> Observations { get; set; }
        public DateTime Date { get; set; }

    }


    public class ResponseMedicalReport
    {
        [JsonProperty("req_id")]
        public string RequestId { get; set; }
        [JsonProperty("exames")]
        public List<BionosticMedicalReport> MedicalReportList { get; set; }
        [JsonProperty("requisicao")]
        public MedicalReportRequest Request { get; set; }
        [JsonProperty("cabecalho")]
        public MedicalReportHeader Header { get; set; }

    }

    public class MedicalReportRequest
    {
        //[JsonProperty("$ref")]
        //public string Referency { get; set; }
        [JsonProperty("req_data")]
        public DateTime MedicalReportDate { get; set; }
    }

    public class MedicalReportAttribute
    {
        [JsonProperty("atrib_id")]
        public string Id { get; set; }
        [JsonProperty("formatacao")]
        public string Formatting { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("posicao")]
        public int Position { get; set; }
        [JsonProperty("resultado")]
        public string Result { get; set; }
        [JsonProperty("tipo")]
        public int Type { get; set; }
        [JsonProperty("unidade")]
        public string Unity { get; set; }
        [JsonProperty("valorReferencia")]
        public string ReferenceValue { get; set; }
        [JsonProperty("resultLeuco")]
        public string ResultLeuco { get; set; }

    }

    public class MedicalReportObservation
    {
        [JsonProperty("obs_txt")]
        public string Message { get; set; }
        [JsonProperty("obs_nivel")]
        public string Level { get; set; }
    }

    public class MedicalReportHeader
    {
        [JsonProperty("pac_id")]
        public string PatientId { get; set; }
        [JsonProperty("clin_fone")]
        public string ClinicPhone { get; set; }
        [JsonProperty("clin_fax")]
        public string ClinicFax { get; set; }
        [JsonProperty("clin_end")]
        public string ClinicAdress { get; set; }
        [JsonProperty("clin_bairro")]
        public string ClinicDistrict { get; set; }
        [JsonProperty("clin_cidade")]
        public string ClinicCity { get; set; }
        [JsonProperty("clin_uf")]
        public string ClinicStateProvince { get; set; }
        [JsonProperty("clin_cep")]
        public string ClinicPostalCode { get; set; }
        [JsonProperty("med_nome")]
        public string MedicName { get; set; }
        [JsonProperty("med_fone")]
        public string MedicPhone { get; set; }
        [JsonProperty("med_celular")]
        public string MedicCellPhone { get; set; }
        [JsonProperty("med_crmv")]
        public string MedicRegister { get; set; }
        [JsonProperty("resp_fone")]
        public string ResponsiblePhone { get; set; }
        [JsonProperty("protocolo")]
        public string Protocol { get; set; }
        [JsonProperty("paciente")]
        public string PatientName { get; set; }
        [JsonProperty("raca")]
        public string Race { get; set; }
        [JsonProperty("especie")]
        public string Specie { get; set; }
        [JsonProperty("sexo")]
        public string PatientSex { get; set; }
        [JsonProperty("idade")]
        public string PatientAge { get; set; }
        [JsonProperty("data_requisicao")]
        public DateTimeOffset? RequisitionDate { get; set; }
        [JsonProperty("responsavel")]
        public string ResponsibleName { get; set; }
        [JsonProperty("data_emissao")]
        public DateTimeOffset? IssueDate { get; set; }
        [JsonProperty("clinica")]
        public string ClinicName { get; set; }
        [JsonProperty("clin_id")]
        public string ClinicID { get; set; }
    }

    public class MedicalReportListPresentation
    {
        [JsonProperty("req_id")]
        public string Protocol { get; set; }
        [JsonProperty("req_data")]
        public DateTime MedicalReportDate { get; set; }
        [JsonProperty("pac_id")]
        public string PetId { get; set; }
        [JsonProperty("clin_id")]
        public string ClinicId { get; set; }
        [JsonProperty("resp_id")]
        public string ResponsibleId { get; set; }
        [JsonProperty("paciente")]
        public BionosticPet Pet { get; set; }
        [JsonProperty("responsavel")]
        public BionosticResponsibleFull Responsible { get; set; }
        [JsonProperty("clinica")]
        public BionosticClinic Clinic { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
