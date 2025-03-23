using System;
using Newtonsoft.Json;

namespace Data.DogData
{
    [Serializable]
    public class Relationships
    {
        [JsonProperty("group")]
        public Group Group { get; set; }
    }
}