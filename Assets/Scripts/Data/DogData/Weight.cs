using System;
using Newtonsoft.Json;

namespace Data.DogData
{
    [Serializable]
    public class Weight
    {
        [JsonProperty("max")]
        public int Max { get; set; }
    
        [JsonProperty("min")]
        public int Min { get; set; }
    }
}