using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

using WPFSample.DTO;

namespace WPFSample.Services.Programme
{
    public class ProgrammeService : BaseService, IProgrammeService
    {
        public ProgrammeService() : base() {}

        public void AddNewProgramme(ProgrammeJson programme)
        {
            var request = new RestRequest("api/programme", Method.POST);
            request.AddJsonBody(programme);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if( response.StatusCode != HttpStatusCode.OK )
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public IEnumerable<ExistingProgrammeJson> ReadProgrammeList()
        {
            var request = new RestRequest("api/programme", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK) throw new InvalidOperationException(response.Content);
            else return JsonConvert.DeserializeObject<IEnumerable<ExistingProgrammeJson>>(response.Content);
        }

        public void UpdateProgramme(string programmeID, ExistingProgrammeJson programme)
        {
            var request = new RestRequest("api/programme/" + programmeID, Method.PUT);
            request.AddJsonBody(programme);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if( response.StatusCode != HttpStatusCode.OK )
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public void RemoveProgramme(string programmeID)
        {
            var request = new RestRequest("api/programme/" + programmeID, Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
        }
    }
}