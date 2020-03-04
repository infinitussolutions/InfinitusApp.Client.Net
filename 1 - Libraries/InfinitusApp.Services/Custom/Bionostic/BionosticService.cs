using InfinitusApp.Core.Data.Commands.Custom.Bionostic;
using InfinitusApp.Core.Data.Commands.Login;
using InfinitusApp.Core.Extensions;
using InfinitusApp.Services.Custom.Bionostic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static InfinitusApp.Services.Custom.Bionostic.Models.BionosticResponsibleContact;

namespace InfinitusApp.Services.Custom.Bionostic
{
    // Clínica - benoni / 181818
    // Tutor - 277740 / xcqc8sz7

    public class BionosticService : ServiceBase
    {
        public static BionosticResponseLogin CurrentBionosticUser { get; set; }
        public BionosticService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {

        }

        public async Task<List<MedicalReportListPresentation>> GetAllMedicalReport(BionosticMedicalReportFilterCommand cmd)
        {
            try
            {
                cmd.ResponsibleType = CurrentBionosticUser.IsClinic ? BionosticResponsibleType.Clinic : BionosticResponsibleType.Tutor;

                return await ServiceClient.InvokeApiAsync<BionosticMedicalReportFilterCommand, List<MedicalReportListPresentation>>("Custom/Bionostic/Bionostic/GetAllMedicalReports", cmd);

                //var dic = new Dictionary<string, string>
                //{
                //    { "type", type.ToString() },
                //    { "responsibleId", responsibleId },
                //    { "start", start.ToString() },
                //    { "amount", amount.ToString() },
                //};

                //return await ServiceClient.InvokeApiAsync<List<MedicalReportListPresentation>>("Custom/Bionostic/Bionostic/GetAllMedicalReports", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseMedicalReport> GetMedicalReportById(string id)
        {
            try
            {
                var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

                return await ServiceClient.InvokeApiAsync<ResponseMedicalReport>("Custom/Bionostic/Bionostic/GetMedicalReportById", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> GetPdfLinkByMedicalReportId(string id)
        {
            try
            {

                var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

                return await ServiceClient.InvokeApiAsync<string>("Custom/Bionostic/Bionostic/GetPdfLinkByMedicalReportId", HttpMethod.Get, dic);

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<byte[]> GetPdfByMedicalReportId(string id)
        {
            try
            {
                var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

                return await ServiceClient.InvokeApiAsync<byte[]>("Custom/Bionostic/Bionostic/GetPdfByMedicalReportId", HttpMethod.Get, dic);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BionosticCollect>> GetCollects(string clinicId, int start, int amount)
        {
            try
            {
                var dic = new Dictionary<string, string>
                {
                    { "clinicId", clinicId },
                    { "start", start.ToString() },
                    { "amount", amount.ToString() }
                };

                return await ServiceClient.InvokeApiAsync<List<BionosticCollect>>("Custom/Bionostic/Bionostic/GetCollects", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CreateCollect(BionosticCollectCreateCommand command)
        {
            try
            {
                return await ServiceClient.InvokeApiAsync<BionosticCollectCreateCommand, bool>("Custom/Bionostic/Bionostic/CreateCollect", command);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<BionosticSpecie>> GetAllSpecies()
        {
            try
            {
                return await ServiceClient.InvokeApiAsync<List<BionosticSpecie>>("Custom/Bionostic/Bionostic/GetAllSpecies", HttpMethod.Get, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BionosticRace>> GetAllRacesBySpecieId(string specieId)
        {
            try
            {
                if (string.IsNullOrEmpty(specieId))
                    throw new Exception("Specie Id is null");

                var dic = new Dictionary<string, string>
                {
                    { "specieId", specieId }
                };

                return await ServiceClient.InvokeApiAsync<List<BionosticRace>>("Custom/Bionostic/Bionostic/GetAllRacesBySpecieId", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BionosticRaceFull>> GetAllRaces()
        {
            try
            {
                return await ServiceClient.InvokeApiAsync<List<BionosticRaceFull>>("Custom/Bionostic/Bionostic/GetAllRaces", HttpMethod.Get, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BionosticRace> GetRaceById(string raceId)
        {
            try
            {
                if (string.IsNullOrEmpty(raceId))
                    throw new Exception("Race Id is null");

                var dic = new Dictionary<string, string>
                {
                    { "id", raceId }
                };

                return await ServiceClient.InvokeApiAsync<BionosticRace>("Custom/Bionostic/Bionostic/GetRaceById", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BionosticPetFull>> GetAllPetsByResponsibleId(string responsibleId)
        {
            try
            {
                if (string.IsNullOrEmpty(responsibleId))
                    throw new Exception("Responsible Id is null");

                var dic = new Dictionary<string, string>
                {
                    { "responsibleId", responsibleId }
                };

                return await ServiceClient.InvokeApiAsync<List<BionosticPetFull>>("Custom/Bionostic/Bionostic/GetAllPetsByResponsibleId", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BionosticPetFull> GetPetById(string petId)
        {
            try
            {
                if (string.IsNullOrEmpty(petId))
                    throw new Exception("Pet Id is null");

                var dic = new Dictionary<string, string>
                {
                    { "petId", petId }
                };

                return await ServiceClient.InvokeApiAsync<BionosticPetFull>("Custom/Bionostic/Bionostic/GetPetById", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BionosticResponsibleFull> GetResponsibleById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Id is null");

                var dic = new Dictionary<string, string>
                {
                    { "id", id }
                };

                return await ServiceClient.InvokeApiAsync<BionosticResponsibleFull>("Custom/Bionostic/Bionostic/GetResponsibleById", HttpMethod.Get, dic);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<BionosticResponseLogin> Login(LoginCommand cmd)
        {
            try
            {
                if (cmd == null)
                    throw new NullReferenceException("Username");

                if (string.IsNullOrEmpty(cmd.Username))
                    throw new NullReferenceException("Username");

                if (string.IsNullOrEmpty(cmd.Password))
                    throw new NullReferenceException("Password");

                CurrentBionosticUser = await ServiceClient.InvokeApiAsync<LoginCommand, BionosticResponseLogin>("Custom/Bionostic/Bionostic/Login", cmd);

                if (CurrentBionosticUser != null && CurrentBionosticUser.IsClinic)
                {
                    var dic = new Dictionary<string, string>
                      {
                          { "id", CurrentBionosticUser.Clinic.Id }
                      };

                    var clinic = await ServiceClient.InvokeApiAsync<BionosticClinic>("Custom/Bionostic/Bionostic/GetClinicById", HttpMethod.Get, dic);

                    if (clinic != null)
                        CurrentBionosticUser.Clinic = clinic;
                }

                return CurrentBionosticUser; 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BionosticSatisfactionSurveyQuestion>> GetSatisfactionSurveyQuestions()
        {
            try
            {
                return await ServiceClient.InvokeApiAsync<List<BionosticSatisfactionSurveyQuestion>>("Custom/Bionostic/Bionostic/GetSatisfactionSurveyQuestions", HttpMethod.Get, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SendSatisfactionSurvey(BionosticSatisfactionSurvey satisfactionSurvey)
        {
            try
            {
                if (string.IsNullOrEmpty(satisfactionSurvey.ClinicId))
                    throw new ArgumentNullException(nameof(satisfactionSurvey.ClinicId));

                return await ServiceClient.InvokeApiAsync<BionosticSatisfactionSurvey, bool>("Custom/Bionostic/Bionostic/CreateSatisfactionSurvey", satisfactionSurvey);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateResponsiblePassword(BionosticResponsiblePasswordCommand cmd)
        {
            try
            {
                if (string.IsNullOrEmpty(cmd.ResponsibleId))
                    throw new ArgumentNullException(nameof(cmd.ResponsibleId));

                if (string.IsNullOrEmpty(cmd.NewPassword))
                    throw new ArgumentNullException(nameof(cmd.NewPassword));

                return await ServiceClient.InvokeApiAsync<BionosticResponsiblePasswordCommand, bool>("Custom/Bionostic/Bionostic/UpdateResponsiblePassword", cmd);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateResponsible(BionosticResponsible responsible)
        {
            try
            {
                //if (string.IsNullOrEmpty(responsible.Id))
                //    throw new ArgumentNullException(nameof(responsible.Id));

                return await ServiceClient.InvokeApiAsync<BionosticResponsible, bool>("Custom/Bionostic/Bionostic/UpdateResponsible", responsible);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateClinic(BionosticClinic clinic)
        {
            try
            {
                //if (string.IsNullOrEmpty(responsible.Id))
                //    throw new ArgumentNullException(nameof(responsible.Id));

                return await ServiceClient.InvokeApiAsync<BionosticClinic, bool>("Custom/Bionostic/Bionostic/UpdateClinic", clinic);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateClinicPassword(BionosticClinicPasswordCommand cmd)
        {
            try
            {
                if (string.IsNullOrEmpty(cmd.ClinicId))
                    throw new ArgumentNullException(nameof(cmd.ClinicId));

                if (string.IsNullOrEmpty(cmd.NewPassword))
                    throw new ArgumentNullException(nameof(cmd.NewPassword));

                return await ServiceClient.InvokeApiAsync<BionosticClinicPasswordCommand, bool>("Custom/Bionostic/Bionostic/UpdateClinicPassword", cmd);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
