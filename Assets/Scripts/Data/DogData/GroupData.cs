using System;
using Newtonsoft.Json;

namespace Data.DogData
{
    [Serializable]
    public class GroupData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}