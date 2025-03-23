using System;

namespace Data.GatherData
{
    [Serializable]
    public class ProbabilityOfPrecipitation
    {
        public string UnitCode { get; set; }

        public int? Value { get; set; } 
    }
}