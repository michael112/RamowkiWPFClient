using System.Collections.Generic;
using WPFSample.DTO;

namespace WPFSample.Services.Schedule
{
    public interface IScheduleService
    {
        void CreateSchedule(ScheduledProgrammeJson schedule, string programmeID);
        void CreateScheduleAndProgramme(ScheduledProgrammeJson schedule, ProgrammeJson programme);
        void UpdateSchedule(string scheduleID, string programmeID);
        void UpdateSchedule(ScheduledProgrammeJson schedule, string scheduleID);
        void RemoveSchedule(string scheduleID);
        IEnumerable<ExistingScheduledProgrammeJson> GetScheduledProgrammeListByWeekDay(int weekDay);
        IEnumerable<ExistingScheduledProgrammeJson> GetScheduledProgrammeListByDate(string date);
    }
}