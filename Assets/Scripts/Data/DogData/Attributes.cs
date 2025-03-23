using System;
using Newtonsoft.Json;

namespace Data.DogData
{
    [Serializable]
    public class Attributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
    
        [JsonProperty("life")]
        public Life Life { get; set; }
    
        [JsonProperty("male_weight")]
        public Weight MaleWeight { get; set; }
    
        [JsonProperty("female_weight")]
        public Weight FemaleWeight { get; set; }
    
        [JsonProperty("hypoallergenic")]
        public bool Hypoallergenic { get; set; }
    }
}