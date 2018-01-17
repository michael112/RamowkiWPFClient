namespace WPFSample.DTO
{
    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Time() {}
        public Time(int hours, int minutes) : this()
        {
            this.Hours = hours;
            this.Minutes = minutes;
        }
        public Time(int hours) : this(hours, 0) {}
    }
}
