using System;
using System.Collections.Generic;
using AJAXExample.Models;

namespace AJAXExample.DAL.Abstract
{
    public interface IEarthquakeService
    {
        IEnumerable<Earthquake> GetRecentEarthquakes(EarthquakeTimeRange range);
    }
}