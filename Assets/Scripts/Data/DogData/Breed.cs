using System;
using Newtonsoft.Json;

namespace Data.DogData
{
    [Serializable]
    public class Breed
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("type")]
        public string Type { get; set; }
    
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    
        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }

        public override string ToString()
        {
            return  "Name: " + Attributes.Name + 
                    "\nDescription: " + Attributes.Description +
                    "\nLife: " + Attributes.Life.Min + " - " + Attributes.Life.Max + 
                    "\nMale Weight: " + Attributes.MaleWeight.Min + " - " + Attributes.MaleWeight.Max  + 
                    "\nFemale Weight: " + Attributes.FemaleWeight.Min + " - " + Attributes.FemaleWeight.Max + 
                    "\nHypoallergenic: " + Attributes.Hypoallergenic;
        }
    }
}