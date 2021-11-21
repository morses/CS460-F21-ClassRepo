using System;
using System.Collections.Generic;
using TFAthlete.Models;

namespace TFAthlete.DAL.Abstract
{ 
    public interface ITeamRepository : IRepository<Team>
    {
        /// <summary>
        /// Get all teams and their coaches, sorted by the team name alphabetically
        /// </summary>
        /// <returns>List of team coach pairs</returns>
        IEnumerable<TeamCoachPair> GetTeamsWithCoaches();

        /// <summary>
        /// Get all the athletes that are on a given team.  No navigation properties are loaded.
        /// </summary>
        /// <param name="teamName">The team name</param>
        /// <returns>List of athletes, sorted alphabetically by their last name.  We assume their last name is the part of their full name after the last space character.</returns>
        IEnumerable<Athlete> GetAthletesFor(string teamName);

        // Alternate version if you want to get athletes by team ID
        IEnumerable<Athlete> GetAthletesFor(int teamId);
    }

}