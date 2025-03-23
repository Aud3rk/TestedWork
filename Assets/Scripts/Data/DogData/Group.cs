using System;
using Newtonsoft.Json;

namespace Data.DogData
{
    [Serializable]
    public class Group
    {
        [JsonProperty("data")]
        public GroupData Data { get; set; }
    }
}