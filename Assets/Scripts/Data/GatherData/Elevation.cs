using System;

namespace Data.GatherData
{
    [Serializable]
    public class Elevation
    {
        public string UnitCode { get; set; }

        public double Value { get; set; }
    }
}