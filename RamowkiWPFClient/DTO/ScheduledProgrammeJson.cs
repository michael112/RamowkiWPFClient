namespace WPFSample.DTO
{
    public class ScheduledProgrammeJson
    {
        public DayWrapper Day { get; set; }
        public Time BeginTime { get; set; }

        public ScheduledProgrammeJson() {}

        public ScheduledProgrammeJson(Time beginTime)
        {
            this.BeginTime = beginTime;
        }

        public ScheduledProgrammeJson(int weekDay)
        {
            this.Day = new DayWrapper(weekDay);
        }
        public ScheduledProgrammeJson(string date)
        {
            this.Day = new DayWrapper(date);
        }

        public ScheduledProgrammeJson(int weekDay, Time beginTime) : this(weekDay)
        {
            this.BeginTime = beginTime;
        }
        public ScheduledProgrammeJson(string date, Time beginTime) : this(date)
        {
            this.BeginTime = beginTime;
        }

        public ScheduledProgrammeJson(DayWrapper day, Time beginTime)
        {
            this.Day = day;
            this.BeginTime = beginTime;
        }
    }
}
