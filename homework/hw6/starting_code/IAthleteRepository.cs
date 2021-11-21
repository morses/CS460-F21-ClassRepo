using System;
using System.Collections.Generic;
using TFAthlete.Models;

namespace TFAthlete.DAL.Abstract
{ 
    public interface IAthleteRepository : IRepository<Athlete>
    {
        /// <summary>
        /// Get all race results for the given athlete.  Sorting by event is done by the 
        /// race distance itself regardless of if they are a hurdle event or not, i.e.
        /// 100, then 100 hh, then 110 hh, then 200, then 300 ih, etc.  
        /// NOTE: we have limited test coverage for that at the moment
        /// </summary>
        /// <param name="athleteName">The full name of the athlete</param>
        /// <returns>List of race results sorted by event and then by date</returns>
        IEnumerable<RaceResultDisplay> GetRaceResultsFor(string athleteName);

        // Alternate version in case you want to do this by id instead of by name
        IEnumerable<RaceResultDisplay> GetRaceResultsFor(int athleteId);
    }

}