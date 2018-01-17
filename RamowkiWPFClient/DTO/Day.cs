using System;
using Newtonsoft.Json;

namespace WPFSample.DTO
{
    public abstract class Day {
        [JsonProperty(Required = Required.AllowNull)]
        public Guid Id { get; set; }
    }
}
