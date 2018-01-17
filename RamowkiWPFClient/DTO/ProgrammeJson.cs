using System;
using Newtonsoft.Json;

namespace WPFSample.DTO
{
    public class ProgrammeJson
    {
        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }
        public String Description { get; set; }

        public ProgrammeJson() { }
        public ProgrammeJson(string title) : this()
        {
            this.Title = title;
        }
        public ProgrammeJson(string title, string description) : this(title)
        {
            this.Description = description;
        }
    }
}
