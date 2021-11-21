using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFAthlete.Models
{
    /// <summary>
    /// A Model used to organize the results of querying the db.  We could have used a Tuple&lt;string,string&gt; but that
    /// isn't very self-documenting, i.e. when you need to extract the team name you'd be doing entry.Item1 instead of entry.TeamName
    /// and you'd have to remember which position corresponded to which value.  The downside is that we have to override equals
    /// in order to compare 2 of these, which the Tuple would have done automatically. 
    /// </summary>
    public class TeamCoachPair
    {
        public string TeamName { get; set; }
        public string CoachName { get; set; }

        // So we can easily compare it in a test
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else 
            {
                TeamCoachPair t = (TeamCoachPair) obj;
                return (TeamName == t.TeamName) && (CoachName == t.CoachName);
            }
        }

        // always override this with equals so it can be stored in a dict
        public override int GetHashCode()
        {
            return new[] {TeamName, CoachName}.GetHashCode();
        }
    }

    /// <summary>
    /// Helper model to contain the data needed to display a race result.  Sort of a View Model but it is 
    /// common for a VM to need to hold other, unrelated data as well, so this is just a non-db model class.
    /// </summary>
    public class RaceResultDisplay
    {
        public string TrackEventName { get; set; }
        public double Time { get; set; }
        public DateTime MeetDate { get; set; }
        public string MeetName { get; set; }

        public string TimeFormatted { get => Time.ToString("F2"); }
        public string MeetDateFormatted { get => MeetDate.ToString("yyyy-mm-dd"); }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else 
            {
                RaceResultDisplay r = (RaceResultDisplay) obj;
                return  (TrackEventName == r.TrackEventName) && 
                        (TimeFormatted == r.TimeFormatted) &&   // compare formatted time to avoid representation errors
                        (MeetDate == r.MeetDate) &&
                        (MeetName == r.MeetName);
            }
        }

        public override int GetHashCode()
        {
            return (TrackEventName + TimeFormatted + MeetDateFormatted + MeetName).GetHashCode();
        }
    }

}