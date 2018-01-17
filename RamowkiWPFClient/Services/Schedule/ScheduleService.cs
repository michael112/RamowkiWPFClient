using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

using WPFSample.Utils;
using WPFSample.DTO;

namespace WPFSample.Services.Schedule
{
    public class ScheduleService : BaseService, IScheduleService
    {
        public void CreateSchedule(ScheduledProgrammeJson schedule, string programmeID)
        {
            var request = new RestRequest("api/schedule/?programme=" + programmeID, Method.POST);
            request.AddJsonBody(schedule);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public void CreateScheduleAndProgramme(ScheduledProgrammeJson schedule, ProgrammeJson programme)
        {
            var wrapper = new ScheduledProgrammeWrapper(schedule)
            {
                Programme = programme
            };
            var request = new RestRequest("api/schedule", Method.POST);
            request.AddJsonBody(wrapper);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public void UpdateSchedule(string scheduleID, string programmeID)
        {
            var request = new RestRequest("api/schedule/" + scheduleID + "?programme=" + programmeID, Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public void UpdateSchedule(ScheduledProgrammeJson schedule, string scheduleID)
        {
            var request = new RestRequest("api/schedule/" + scheduleID, Method.PUT);
            request.AddJsonBody(schedule);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public void RemoveSchedule(string scheduleID)
        {
            var request = new RestRequest("api/schedule/" + scheduleID, Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
        }

        public IEnumerable<ExistingScheduledProgrammeJson> GetScheduledProgrammeListByDate(string date)
        {
            var request = new RestRequest("api/schedule?date=" + date, Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
            return JsonConvert.DeserializeObject<IEnumerable<ExistingScheduledProgrammeJson>>(response.Content).OrderBy(x => x.BeginTime, new TimeComparer()).ToList();
        }

        public IEnumerable<ExistingScheduledProgrammeJson> GetScheduledProgrammeListByWeekDay(int weekDay)
        {
            var request = new RestRequest("api/schedule?day=" + weekDay.ToString(), Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = this.restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(response.Content);
            }
            return JsonConvert.DeserializeObject<IEnumerable<ExistingScheduledProgrammeJson>>(response.Content).OrderBy(x => x.BeginTime, new TimeComparer()).ToList();
        }
    }
}