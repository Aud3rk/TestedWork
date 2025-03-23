using System;
using System.Collections.Generic;

namespace Data.GatherData
{
    [Serializable]
    public class WeatherFeature
    {
        public List<object> context; 
        public string Type { get; set; }
        public Geometry Geometry { get; set; }

        public WeatherProperties Properties { get; set; }
    }
}