namespace WPFSample.DTO
{
    public class ExistingProgrammeJson : ProgrammeJson
    {
        public string Id { get; set; }

        public ExistingProgrammeJson() { }
        public ExistingProgrammeJson(string id, string title) : this()
        {
            this.Id = id;
            this.Title = title;
        }
        public ExistingProgrammeJson(string id, string title, string description) : this(id, title)
        {
            this.Description = description;
        }
    }
}