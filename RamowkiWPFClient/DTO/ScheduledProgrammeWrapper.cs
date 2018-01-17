using System;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WPFSample.DTO
{
    public class ScheduledProgrammeWrapper : ScheduledProgrammeJson
    {
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public ProgrammeJson Programme { get; set; }

        public ScheduledProgrammeJson ToScheduledProgrammeJson()
        {
            return new ScheduledProgrammeJson(this.Day, this.BeginTime);
        }

        public ScheduledProgrammeWrapper() {}

        public ScheduledProgrammeWrapper(ScheduledProgrammeJson programmeJson)
        {
            this.Day = programmeJson.Day;
            this.BeginTime = programmeJson.BeginTime;
        }

        public ScheduledProgrammeWrapper(Time beginTime) : base(beginTime) {}
        public ScheduledProgrammeWrapper(int weekDay) : base(weekDay) {}
        public ScheduledProgrammeWrapper(string date) : base(date) {}
        public ScheduledProgrammeWrapper(int weekDay, Time beginTime) : base(weekDay, beginTime) {}
        public ScheduledProgrammeWrapper(string date, Time beginTime) : base(date, beginTime) {}
        public ScheduledProgrammeWrapper(int weekDay, string title) : base(weekDay)
        {
            this.Programme = new ProgrammeJson(title);
        }
        public ScheduledProgrammeWrapper(string date, string title) : base(date)
        {
            this.Programme = new ProgrammeJson(title);
        }
        public ScheduledProgrammeWrapper(Time beginTime, string title) : base(beginTime)
        {
            this.Programme = new ProgrammeJson(title);
        }
        public ScheduledProgrammeWrapper(int weekDay, Time beginTime, string title) : base(weekDay, beginTime)
        {
            this.Programme = new ProgrammeJson(title);
        }
        public ScheduledProgrammeWrapper(string date, Time beginTime, string title) : base(date, beginTime)
        {
            this.Programme = new ProgrammeJson(title);
        }
        public ScheduledProgrammeWrapper(int weekDay, string title, String description) : base(weekDay)
        {
            this.Programme = new ProgrammeJson(title, description);
        }
        public ScheduledProgrammeWrapper(string date, string title, String description) : base(date)
        {
            this.Programme = new ProgrammeJson(title, description);
        }
        public ScheduledProgrammeWrapper(Time beginTime, string title, String description) : base(beginTime)
        {
            this.Programme = new ProgrammeJson(title, description);
        }
        public ScheduledProgrammeWrapper(int weekDay, Time beginTime, string title, String description) : base(weekDay, beginTime)
        {
            this.Programme = new ProgrammeJson(title, description);
        }
        public ScheduledProgrammeWrapper(string date, Time beginTime, string title, String description) : base(date, beginTime)
        {
            this.Programme = new ProgrammeJson(title, description);
        }
    }
}
