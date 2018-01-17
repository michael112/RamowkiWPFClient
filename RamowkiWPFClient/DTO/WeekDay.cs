namespace WPFSample.DTO
{
    public class WeekDay : Day
    {
        public WeekdayEnum Day { get; set; }

        public WeekDay() {}
        public WeekDay(int dayNumber)
        {
            this.Day = (WeekdayEnum)(dayNumber % 7);
        }
    }
    public enum WeekdayEnum 
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 0
    }
}
