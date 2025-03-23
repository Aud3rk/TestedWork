using System;
using System.Collections.Generic;

namespace Data.GatherData
{
    [Serializable]
    public class Geometry
    {
        public string Type { get; set; }

        public List<List<List<double>>> Coordinates { get; set; }
    }
}