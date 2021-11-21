using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using TFAthlete.DAL.Abstract;
using TFAthlete.DAL.Concrete;
using TFAthlete.Models;

namespace TFAthlete_Tests
{
    public class AthleteTests
    {
        private Mock<TFADbContext> _mockContext;

        private Mock<DbSet<Athlete>> _mockAthleteDbSet;
        private List<Athlete> _athletes = FakeData.Athletes;

        private Mock<DbSet<RaceResult>> _mockRaceResultDbSet;
        private List<RaceResult> _raceResults = FakeData.RaceResults;

        private Mock<DbSet<TrackEvent>> _mockEventDbSet;
        private List<TrackEvent> _events = FakeData.TrackEvents;

        private Mock<DbSet<Location>> _mockLocationDbSet;
        private List<Location> _locations = FakeData.Locations;

        // a helper to make dbset queryable
        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }

        [SetUp]
        public void Setup()
        {
            // Get mock dbsets
            _mockAthleteDbSet = GetMockDbSet(_athletes.AsQueryable());
            _mockRaceResultDbSet = GetMockDbSet(_raceResults.AsQueryable());
            _mockEventDbSet = GetMockDbSet(_events.AsQueryable());
            _mockLocationDbSet = GetMockDbSet(_locations.AsQueryable());

            // Get the mock context
            _mockContext = new Mock<TFADbContext>();
            _mockContext.Setup(ctx => ctx.Athletes).Returns(_mockAthleteDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Athlete>()).Returns(_mockAthleteDbSet.Object);
            _mockContext.Setup(ctx => ctx.RaceResults).Returns(_mockRaceResultDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<RaceResult>()).Returns(_mockRaceResultDbSet.Object);
            _mockContext.Setup(ctx => ctx.TrackEvents).Returns(_mockEventDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<TrackEvent>()).Returns(_mockEventDbSet.Object);
            _mockContext.Setup(ctx => ctx.Locations).Returns(_mockLocationDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Location>()).Returns(_mockLocationDbSet.Object);
        }

        // Failure conditions

        [Test]
        public void AthleteRepo_GetRaceResultsForNonExistentAthlete_Should_ReturnEmptyResults()
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);
            string athleteName = "No Student Found";
            int athleteId = 444;

            // Act 
            IEnumerable<RaceResultDisplay> teamAndCoachList = athleteRepo.GetRaceResultsFor(athleteName);
            // or your choice
            IEnumerable<RaceResultDisplay> teamAndCoachListById = athleteRepo.GetRaceResultsFor(athleteId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(teamAndCoachList.Count(), Is.EqualTo(0));
                Assert.That(teamAndCoachListById.Count(), Is.EqualTo(0));
            });  
        }

        [Test]
        public void AthleteRepo_GetRaceResultsForNullName_Should_ThrowException()
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);
            string athleteName = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => {athleteRepo.GetRaceResultsFor(athleteName);});
        }

        [TestCase(0)]
        [TestCase(-34)]
        public void AthleteRepo_GetRaceResultsForInvalidID_Should_ThrowException(int athleteId)
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => {athleteRepo.GetRaceResultsFor(athleteId);}); 
        }

        [Test]
        public void AthleteRepo_GetRaceResultsForAthleteWithNoResults_Returns_NoResults()
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);
            string athleteName = "Lysimachos Matey";
            int athleteId = 11;

            // Act 
            IEnumerable<RaceResultDisplay> teamAndCoachList = athleteRepo.GetRaceResultsFor(athleteName);
            // or your choice
            IEnumerable<RaceResultDisplay> teamAndCoachListById = athleteRepo.GetRaceResultsFor(athleteId);

            // Assert that this list is empty
            Assert.That(teamAndCoachList.Count(), Is.EqualTo(0));
        }

        // Positive cases
        [Test]
        public void AthleteRepo_GetRaceResultsFor_Returns_AllRaceResults()
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);
            string athleteName = "Rory Bruce";
            int athleteId = 48;
            var expectedList = new List<RaceResultDisplay>
            {
                new RaceResultDisplay { Time = 136.17, MeetName = "Independence",                        MeetDate = new DateTime( 2019, 4, 10), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 12.51 , MeetName = "Independence",                        MeetDate = new DateTime( 2019, 4, 10), TrackEventName  = "100" },
                new RaceResultDisplay { Time = 270.71, MeetName = "Independence",                        MeetDate = new DateTime( 2019, 4, 10), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 23.26 , MeetName = "Silverton Triple Meet",               MeetDate = new DateTime( 2019, 4, 17), TrackEventName  = "200" },
                new RaceResultDisplay { Time = 132.53, MeetName = "Silverton Triple Meet",               MeetDate = new DateTime( 2019, 4, 17), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 252.92, MeetName = "Silverton Triple Meet",               MeetDate = new DateTime( 2019, 4, 17), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 128.93, MeetName = "Dallas Invitational",                 MeetDate = new DateTime( 2019, 4, 24), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 268.84, MeetName = "Dallas Invitational",                 MeetDate = new DateTime( 2019, 4, 24), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 545.33, MeetName = "Dallas Invitational",                 MeetDate = new DateTime( 2019, 4, 24), TrackEventName  = "3000" },
                new RaceResultDisplay { Time = 11.57 , MeetName = "North Salem HS",                      MeetDate = new DateTime( 2019, 5, 16), TrackEventName  = "100" },
                new RaceResultDisplay { Time = 22.9  , MeetName = "North Salem HS",                      MeetDate = new DateTime( 2019, 5, 16), TrackEventName  = "200" },
                new RaceResultDisplay { Time = 243.37, MeetName = "North Salem HS",                      MeetDate = new DateTime( 2019, 5, 16), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 22.83 , MeetName = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23), TrackEventName  = "200" },
                new RaceResultDisplay { Time = 50.72 , MeetName = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23), TrackEventName  = "400" },
                new RaceResultDisplay { Time = 11.18 , MeetName = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23), TrackEventName  = "100" },
                new RaceResultDisplay { Time = 527.7 , MeetName = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30), TrackEventName  = "3000" },
                new RaceResultDisplay { Time = 241.22, MeetName = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 117.64, MeetName = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30), TrackEventName  = "800" }
            };

            // Act 
            IEnumerable<RaceResultDisplay> teamAndCoachList = athleteRepo.GetRaceResultsFor(athleteName);
            // or your choice
            IEnumerable<RaceResultDisplay> teamAndCoachListById = athleteRepo.GetRaceResultsFor(athleteId);

            // Assert that this list contains the correct race results
            Assert.Multiple(() => {
                Assert.That(teamAndCoachList.Count(), Is.EqualTo(expectedList.Count()));
                foreach(RaceResultDisplay a in expectedList)
                {
                    Assert.That(teamAndCoachList.Any(actual => actual.Equals(a)));
                    //Assert.That(teamAndCoachListById.Any(actual => actual.Equals(a)));       // Should make this a separate test method if we're writing both
                }
            });
        }

        

        [Test]
        public void AthleteRepo_GetRaceResultsFor_Returns_AllRaceResults_AndIsSortedByEventAndDate()
        {
            // Arrange
            IAthleteRepository athleteRepo = new AthleteRepository(_mockContext.Object);
            string athleteName = "Rory Bruce";
            int athleteId = 48;
            var expectedList = new List<RaceResultDisplay>      // now sorted correctly
            {
                new RaceResultDisplay { Time = 12.51 , MeetName = "Independence",                        MeetDate = new DateTime( 2019, 4, 10), TrackEventName  = "100" },
                new RaceResultDisplay { Time = 11.57 , MeetName = "North Salem HS",                      MeetDate = new DateTime( 2019, 5, 16), TrackEventName  = "100" },
                new RaceResultDisplay { Time = 11.18 , MeetName = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23), TrackEventName  = "100" },
                new RaceResultDisplay { Time = 23.26 , MeetName = "Silverton Triple Meet",               MeetDate = new DateTime( 2019, 4, 17), TrackEventName  = "200" },
                new RaceResultDisplay { Time = 22.9  , MeetName = "North Salem HS",                      MeetDate = new DateTime( 2019, 5, 16), TrackEventName  = "200" },
                new RaceResultDisplay { Time = 22.83 , MeetName = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23), TrackEventName  = "200" },
                new RaceResultDisplay { Time = 50.72 , MeetName = "District Meet",                       MeetDate = new DateTime( 2019, 5, 23), TrackEventName  = "400" },
                new RaceResultDisplay { Time = 136.17, MeetName = "Independence",                        MeetDate = new DateTime( 2019, 4, 10), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 132.53, MeetName = "Silverton Triple Meet",               MeetDate = new DateTime( 2019, 4, 17), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 128.93, MeetName = "Dallas Invitational",                 MeetDate = new DateTime( 2019, 4, 24), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 117.64, MeetName = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30), TrackEventName  = "800" },
                new RaceResultDisplay { Time = 270.71, MeetName = "Independence",                        MeetDate = new DateTime( 2019, 4, 10), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 252.92, MeetName = "Silverton Triple Meet",               MeetDate = new DateTime( 2019, 4, 17), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 268.84, MeetName = "Dallas Invitational",                 MeetDate = new DateTime( 2019, 4, 24), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 243.37, MeetName = "North Salem HS",                      MeetDate = new DateTime( 2019, 5, 16), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 241.22, MeetName = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30), TrackEventName  = "1500" },
                new RaceResultDisplay { Time = 545.33, MeetName = "Dallas Invitational",                 MeetDate = new DateTime( 2019, 4, 24), TrackEventName  = "3000" },
                new RaceResultDisplay { Time = 527.7 , MeetName = "State Track and Field Championships", MeetDate = new DateTime( 2019, 5, 30), TrackEventName  = "3000" }
            };

            // Act 
            IEnumerable<RaceResultDisplay> teamAndCoachList = athleteRepo.GetRaceResultsFor(athleteName);
            // or your choice
            IEnumerable<RaceResultDisplay> teamAndCoachListById = athleteRepo.GetRaceResultsFor(athleteId);

            // Assert that this list is sorted by event then by date
            Assert.Multiple(() => {
                Assert.That(teamAndCoachList.SequenceEqual(expectedList));
                //Assert.That(teamAndCoachListById.SequenceEqual(expectedList));
            });
        }
    }
}