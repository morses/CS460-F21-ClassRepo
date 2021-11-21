using System;
using System.Collections.Generic;
using System.Linq;
using TFAthlete.Models;

namespace TFAthlete_Tests
{
    /// <summary>
    /// Put the base set of fake data for testing here for easy re-use.  Use static methods and a static (initializer) constructor
    /// so we can simply get the fake data with calls like FakeData.Coaches
    /// </summary>
    public class FakeData
    {
        public static readonly List<Coach> Coaches = new List<Coach>
            {
                new Coach { Id = 1, FullName = "Don Berger"      },
                new Coach { Id = 2, FullName = "Eli Cirino"      },
                new Coach { Id = 3, FullName = "Kerri Lemerande" },
                new Coach { Id = 4, FullName = "Erik Cross"      },
                new Coach { Id = 5, FullName = "Bill Masei"      },
                new Coach { Id = 6, FullName = "No Name"         }
            };

        public static readonly List<Team> Teams = new List<Team>
            {
                new Team {Id = 1, Name = "North Salem HS", CoachId = 1},
                new Team {Id = 2, Name = "Central HS",     CoachId = 2},
                new Team {Id = 3, Name = "West Albany HS", CoachId = 3},
                new Team {Id = 4, Name = "Silverton HS",   CoachId = 4},
                new Team {Id = 5, Name = "Dallas HS",      CoachId = 5},
                new Team {Id = 6, Name = "New York HS",    CoachId = 6}     // Team with a coach but no athletes
            };

        public static readonly List<Athlete> Athletes = new List<Athlete>
            {
                new Athlete { Id = 1,  FullName = "Vinnie Eimhear"   , TeamId = 4 },
                new Athlete { Id = 2,  FullName = "Izzy Katinka"     , TeamId = 4 },
                new Athlete { Id = 3,  FullName = "Deo Napoleon"     , TeamId = 4 },
                new Athlete { Id = 4,  FullName = "Armen Ben"        , TeamId = 4 },
                new Athlete { Id = 5,  FullName = "Geoffrey Rayhana" , TeamId = 4 },
                new Athlete { Id = 6,  FullName = "Ursula Aigle"     , TeamId = 4 },
                new Athlete { Id = 7,  FullName = "Morten Randy"     , TeamId = 4 },
                new Athlete { Id = 8,  FullName = "Shel Vilim"       , TeamId = 4 },
                new Athlete { Id = 9,  FullName = "Khalilah Kane"    , TeamId = 4 },
                new Athlete { Id = 10, FullName = "Iwo Indira"       , TeamId = 4 },
                new Athlete { Id = 11, FullName = "Lysimachos Matey" , TeamId = 4 },    // has no race results
                new Athlete { Id = 12, FullName = "Birger Arkaitz"   , TeamId = 4 },
                new Athlete { Id = 13, FullName = "Jason Donatas"    , TeamId = 4 },
                new Athlete { Id = 14, FullName = "Vincent Yishai"   , TeamId = 4 },
                new Athlete { Id = 35, FullName = "Lamont Shea"      , TeamId = 3 },
                new Athlete { Id = 36, FullName = "Lorrie Estes"     , TeamId = 3 },
                new Athlete { Id = 37, FullName = "Lynne Stewart"    , TeamId = 3 },
                new Athlete { Id = 38, FullName = "Trent Mora"       , TeamId = 3 },
                new Athlete { Id = 39, FullName = "Willa Bell"       , TeamId = 3 },
                new Athlete { Id = 40, FullName = "Aurelia Sandoval" , TeamId = 3 },
                new Athlete { Id = 41, FullName = "Tanner Hensley"   , TeamId = 3 },
                new Athlete { Id = 42, FullName = "Miranda Owens"    , TeamId = 3 },
                new Athlete { Id = 34, FullName = "Emilia Gomez"     , TeamId = 2 },
                new Athlete { Id = 43, FullName = "Kurt Nicholson"   , TeamId = 1 },
                new Athlete { Id = 44, FullName = "Mac Lucas"        , TeamId = 1 },
                new Athlete { Id = 45, FullName = "Elba Mullins"     , TeamId = 1 },
                new Athlete { Id = 46, FullName = "Long Hill"        , TeamId = 1 },
                new Athlete { Id = 47, FullName = "Viola Howell"     , TeamId = 1 },
                new Athlete { Id = 48, FullName = "Rory Bruce"       , TeamId = 1 },
                new Athlete { Id = 49, FullName = "Taylor Pugh"      , TeamId = 1 },
                new Athlete { Id = 50, FullName = "Brooke Rasmussen" , TeamId = 1 }
            };
        
        public static readonly List<TrackEvent> TrackEvents = new List<TrackEvent>
            {
                new TrackEvent {Id = 4, Title = "800"},
                new TrackEvent {Id = 6, Title = "3000"},
                new TrackEvent {Id = 9, Title = "300 ih"},
                new TrackEvent {Id = 3, Title = "400"},
                new TrackEvent {Id = 5, Title = "1500"},
                new TrackEvent {Id = 7, Title = "100 hh"},
                new TrackEvent {Id = 8, Title = "110 hh"},
                new TrackEvent {Id = 1, Title = "100"},
                new TrackEvent {Id = 2, Title = "200"}
            };

        public static readonly List<Location> Locations = new List<Location>
            {
                new Location { Id = 1, Title = "Silverton Meet",                       MeetDate = new DateTime( 2020, 4, 20) },
                new Location { Id = 2, Title = "Dallas Invitational",                  MeetDate = new DateTime( 2020, 4, 25) },
                new Location { Id = 3, Title = "Central HS",                           MeetDate = new DateTime( 2020, 5, 6) },
                new Location { Id = 4, Title = "West Albany Meet",                     MeetDate = new DateTime( 2019, 4, 3) },
                new Location { Id = 5, Title = "Independence",                         MeetDate = new DateTime( 2019, 4, 10) },
                new Location { Id = 6, Title = "Silverton Triple Meet",                MeetDate = new DateTime( 2019, 4, 17) },
                new Location { Id = 7, Title = "Dallas Invitational",                  MeetDate = new DateTime( 2019, 4, 24) },
                new Location { Id = 8, Title = "Central HS",                           MeetDate = new DateTime( 2019, 5, 8) },
                new Location { Id = 9, Title = "North Salem HS",                       MeetDate = new DateTime( 2019, 5, 16) },
                new Location { Id = 10, Title = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23) },
                new Location { Id = 11, Title = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30) }
            };

        public static readonly List<RaceResult> RaceResults = new List<RaceResult>
            { 
                new RaceResult { Id = 250, Time = 28.21 , AthleteId = 34, ClassificationId = 1, LocationId = 4, TrackEventId = 2 },
                new RaceResult { Id = 251, Time = 689.31, AthleteId = 34, ClassificationId = 1, LocationId = 4, TrackEventId = 6 },
                new RaceResult { Id = 252, Time = 13.72 , AthleteId = 34, ClassificationId = 1, LocationId = 4, TrackEventId = 1 },
                new RaceResult { Id = 301, Time = 61.72 , AthleteId = 34, ClassificationId = 1, LocationId = 5, TrackEventId = 3 },
                new RaceResult { Id = 302, Time = 14.27 , AthleteId = 34, ClassificationId = 1, LocationId = 5, TrackEventId = 1 },
                new RaceResult { Id = 303, Time = 160.11, AthleteId = 34, ClassificationId = 1, LocationId = 5, TrackEventId = 4 },
                new RaceResult { Id = 319, Time = 136.17, AthleteId = 48, ClassificationId = 2, LocationId = 5, TrackEventId = 4 },
                new RaceResult { Id = 320, Time = 12.51 , AthleteId = 48, ClassificationId = 2, LocationId = 5, TrackEventId = 1 },
                new RaceResult { Id = 321, Time = 270.71, AthleteId = 48, ClassificationId = 2, LocationId = 5, TrackEventId = 5 },
                new RaceResult { Id = 352, Time = 318.11, AthleteId = 34, ClassificationId = 1, LocationId = 6, TrackEventId = 5 },
                new RaceResult { Id = 353, Time = 59.99 , AthleteId = 34, ClassificationId = 1, LocationId = 6, TrackEventId = 3 },
                new RaceResult { Id = 354, Time = 642.35, AthleteId = 34, ClassificationId = 1, LocationId = 6, TrackEventId = 6 },
                new RaceResult { Id = 394, Time = 23.26 , AthleteId = 48, ClassificationId = 2, LocationId = 6, TrackEventId = 2 },
                new RaceResult { Id = 395, Time = 132.53, AthleteId = 48, ClassificationId = 2, LocationId = 6, TrackEventId = 4 },
                new RaceResult { Id = 396, Time = 252.92, AthleteId = 48, ClassificationId = 2, LocationId = 6, TrackEventId = 5 },
                new RaceResult { Id = 427, Time = 292.5 , AthleteId = 34, ClassificationId = 1, LocationId = 7, TrackEventId = 5 },
                new RaceResult { Id = 428, Time = 12.97 , AthleteId = 34, ClassificationId = 1, LocationId = 7, TrackEventId = 1 },
                new RaceResult { Id = 429, Time = 26.92 , AthleteId = 34, ClassificationId = 1, LocationId = 7, TrackEventId = 2 },
                new RaceResult { Id = 469, Time = 128.93, AthleteId = 48, ClassificationId = 2, LocationId = 7, TrackEventId = 4 },
                new RaceResult { Id = 470, Time = 268.84, AthleteId = 48, ClassificationId = 2, LocationId = 7, TrackEventId = 5 },
                new RaceResult { Id = 471, Time = 545.33, AthleteId = 48, ClassificationId = 2, LocationId = 7, TrackEventId = 6 },
                new RaceResult { Id = 502, Time = 26.27 , AthleteId = 34, ClassificationId = 1, LocationId = 8, TrackEventId = 2 },
                new RaceResult { Id = 503, Time = 147.94, AthleteId = 34, ClassificationId = 1, LocationId = 8, TrackEventId = 4 },
                new RaceResult { Id = 504, Time = 288.57, AthleteId = 34, ClassificationId = 1, LocationId = 8, TrackEventId = 5 },
                new RaceResult { Id = 544, Time = 11.57 , AthleteId = 48, ClassificationId = 2, LocationId = 9, TrackEventId = 1 },
                new RaceResult { Id = 545, Time = 22.9  , AthleteId = 48, ClassificationId = 2, LocationId = 9, TrackEventId = 2 },
                new RaceResult { Id = 546, Time = 243.37, AthleteId = 48, ClassificationId = 2, LocationId = 9, TrackEventId = 5 },
                new RaceResult { Id = 577, Time = 60.8  , AthleteId = 34, ClassificationId = 1, LocationId = 9, TrackEventId = 3 },
                new RaceResult { Id = 578, Time = 145.53, AthleteId = 34, ClassificationId = 1, LocationId = 9, TrackEventId = 4 },
                new RaceResult { Id = 579, Time = 288.34, AthleteId = 34, ClassificationId = 1, LocationId = 9, TrackEventId = 5 },
                new RaceResult { Id = 604, Time = 12.63 , AthleteId = 34, ClassificationId = 1, LocationId = 10, TrackEventId = 1 },
                new RaceResult { Id = 605, Time = 59.35 , AthleteId = 34, ClassificationId = 1, LocationId = 10, TrackEventId = 3 },
                new RaceResult { Id = 606, Time = 642.97, AthleteId = 34, ClassificationId = 1, LocationId = 10, TrackEventId = 6 },
                new RaceResult { Id = 646, Time = 22.83 , AthleteId = 48, ClassificationId = 2, LocationId = 10, TrackEventId = 2 },
                new RaceResult { Id = 647, Time = 50.72 , AthleteId = 48, ClassificationId = 2, LocationId = 10, TrackEventId = 3 },
                new RaceResult { Id = 648, Time = 11.18 , AthleteId = 48, ClassificationId = 2, LocationId = 10, TrackEventId = 1 },
                new RaceResult { Id = 679, Time = 632.2 , AthleteId = 34, ClassificationId = 1, LocationId = 11, TrackEventId = 6 },
                new RaceResult { Id = 680, Time = 285.6 , AthleteId = 34, ClassificationId = 1, LocationId = 11, TrackEventId = 5 },
                new RaceResult { Id = 681, Time = 25.78 , AthleteId = 34, ClassificationId = 1, LocationId = 11, TrackEventId = 2 },
                new RaceResult { Id = 721, Time = 527.7 , AthleteId = 48, ClassificationId = 2, LocationId = 11, TrackEventId = 6 },
                new RaceResult { Id = 722, Time = 241.22, AthleteId = 48, ClassificationId = 2, LocationId = 11, TrackEventId = 5 },
                new RaceResult { Id = 723, Time = 117.64, AthleteId = 48, ClassificationId = 2, LocationId = 11, TrackEventId = 4 }
            };

        static FakeData()
        {
            // Still need to set the navigation properties, so do it from the id's
            Teams.ForEach(t =>
            {
                t.Coach = Coaches.Single(c => c.Id == t.CoachId);              // to one
                t.Athletes = Athletes.Where(a => a.TeamId == t.Id).ToList();   // to many
            });
            Athletes.ForEach(a =>
            {
                a.Team = Teams.Single(t => t.Id == a.TeamId);                            // to one
                a.RaceResults = RaceResults.Where(rr => rr.AthleteId == a.Id).ToList();  // to many
            });
            RaceResults.ForEach(rr =>
            {
                rr.Athlete = Athletes.Single(a => a.Id == rr.AthleteId);            // to one
                rr.Location = Locations.Single(l => l.Id == rr.LocationId);         // to one
                rr.TrackEvent = TrackEvents.Single(e => e.Id == rr.TrackEventId);   // to one
            });
        }
    }
}