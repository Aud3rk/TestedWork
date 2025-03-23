using System;
using System.Collections.Generic;

namespace Data.GatherData
{
    [Serializable]
    public class WeatherProperties
    {
        public string Units { get; set; }

        public string ForecastGenerator { get; set; }

        public DateTime GeneratedAt { get; set; }

        public DateTime UpdateTime { get; set; }

        public string ValidTimes { get; set; }

        public Elevation Elevation { get; set; }

        public List<WeatherPeriod> Periods { get; set; }
    }
}