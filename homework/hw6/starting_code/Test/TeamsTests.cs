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
    public class TeamsTests
    {
        private Mock<TFADbContext> _mockContext;

        private Mock<DbSet<Team>> _mockTeamDbSet;
        private List<Team> _teams = FakeData.Teams;

        private Mock<DbSet<Coach>> _mockCoachesDbSet;
        private List<Coach> _coaches = FakeData.Coaches;

        private Mock<DbSet<Athlete>> _mockAthletesDbSet;
        private List<Athlete> _athletes = FakeData.Athletes;

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
            _mockTeamDbSet = GetMockDbSet(_teams.AsQueryable());
            _mockCoachesDbSet = GetMockDbSet(_coaches.AsQueryable());
            _mockAthletesDbSet = GetMockDbSet(_athletes.AsQueryable());

            // Get the mock context
            _mockContext = new Mock<TFADbContext>();
            _mockContext.Setup(ctx => ctx.Teams).Returns(_mockTeamDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Team>()).Returns(_mockTeamDbSet.Object);
            _mockContext.Setup(ctx => ctx.Coaches).Returns(_mockCoachesDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Coach>()).Returns(_mockCoachesDbSet.Object);
            _mockContext.Setup(ctx => ctx.Athletes).Returns(_mockAthletesDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Athlete>()).Returns(_mockAthletesDbSet.Object);
        }

        [Test]
        public void TeamRepo_GetTeamsWithCoaches_Should_ReturnAllTeamNamesWithCoachesNames()
        {
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            List<TeamCoachPair> expectedList = new List<TeamCoachPair>
            {
                new TeamCoachPair {CoachName = "Eli Cirino"     , TeamName = "Central HS"     },
                new TeamCoachPair {CoachName = "Bill Masei"     , TeamName = "Dallas HS"      },
                new TeamCoachPair {CoachName = "Don Berger"     , TeamName = "North Salem HS" },
                new TeamCoachPair {CoachName = "Erik Cross"     , TeamName = "Silverton HS"   },
                new TeamCoachPair {CoachName = "Kerri Lemerande", TeamName = "West Albany HS" },
                new TeamCoachPair {CoachName = "No Name"        , TeamName = "New York HS"    }
            };

            // Act
            IEnumerable<TeamCoachPair> teamAndCoachList = teamRepo.GetTeamsWithCoaches();

            // Assert that this list contains the known team name and coach name pairings and has the correct length
            Assert.Multiple(() => {
                Assert.That(teamAndCoachList.Count(), Is.EqualTo(6));
                foreach(TeamCoachPair tcp in expectedList)
                {
                    Assert.That(teamAndCoachList.Any(tactual => tactual.CoachName == tcp.CoachName && tactual.TeamName == tcp.TeamName));
                }
            });
        }

        [Test]
        public void TeamRepo_GetTeamsWithCoaches_Should_ReturnAllTeamNamesWithCoachesNames_AndIsSorted()
        {
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            List<TeamCoachPair> expectedList = new List<TeamCoachPair>
            {
                new TeamCoachPair {CoachName = "Eli Cirino"     , TeamName = "Central HS"     },
                new TeamCoachPair {CoachName = "Bill Masei"     , TeamName = "Dallas HS"      },
                new TeamCoachPair {CoachName = "No Name"        , TeamName = "New York HS"    },
                new TeamCoachPair {CoachName = "Don Berger"     , TeamName = "North Salem HS" },
                new TeamCoachPair {CoachName = "Erik Cross"     , TeamName = "Silverton HS"   },
                new TeamCoachPair {CoachName = "Kerri Lemerande", TeamName = "West Albany HS" }
            };

            // Act
            IEnumerable<TeamCoachPair> teamAndCoachList = teamRepo.GetTeamsWithCoaches();

            // Assert that this list is sorted by team name (if it isn't a list of built-in types you must override Equals)
            Assert.That(teamAndCoachList.SequenceEqual(expectedList));
        }

        [Test]
        public void TeamRepo_GetAthletesFor_Should_ReturnAllAthletesOnThatTeam()
        {
            // Mock 1 or two teams and their athletes, with the athletes in random order
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            string teamName = "North Salem HS";
            int teamID = 1;
            List<string> expectedList = new List<string>
            {
                "Kurt Nicholson",
                "Mac Lucas",
                "Elba Mullins",
                "Long Hill",
                "Viola Howell",
                "Rory Bruce",
                "Taylor Pugh",
                "Brooke Rasmussen"
            };

            // Act
            IEnumerable<Athlete> athleteList = teamRepo.GetAthletesFor(teamName); 
            // or your choice
            IEnumerable<Athlete> athleteListById = teamRepo.GetAthletesFor(teamID);

            // Assert that this list contains all the athletes for this team
            Assert.Multiple(() => {
                Assert.That(athleteList.Count(), Is.EqualTo(expectedList.Count()));
                foreach(string a in expectedList)
                {
                    Assert.That(athleteList.Any(actual => actual.FullName == a));
                    //Assert.That(athleteListById.Any(actual => actual.FullName == a));       // Should make this a separate test method if we're writing both
                }
            });
        }

        [Test]
        public void TeamRepo_GetAthletesFor_Should_ReturnAllAthletesOnThatTeam_AndIsSorted()
        {
            // Mock 1 or two teams and their athletes, with the athletes in random order
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            string teamName = "North Salem HS";
            int teamID = 1;
            List<string> expectedList = new List<string>
            {
                "Rory Bruce",
                "Long Hill",
                "Viola Howell",
                "Mac Lucas",
                "Elba Mullins",
                "Kurt Nicholson",
                "Taylor Pugh",
                "Brooke Rasmussen"
            };

            // Act
            IEnumerable<Athlete> athleteList = teamRepo.GetAthletesFor(teamName); 
            // or your choice
            IEnumerable<Athlete> athleteListById = teamRepo.GetAthletesFor(teamID);

            // Assert that this list is sorted alphabetically by LAST name
            Assert.Multiple(() => {
                Assert.That(athleteList.Select(a => a.FullName).SequenceEqual(expectedList));       // Select preserves order
                //Assert.That(athleteListById.Select(a => a.FullName).SequenceEqual(expectedList));
            });
        }

        [Test]
        public void TeamRepo_GetAthletesForTeam_WithNoAthletes_Should_Return_EmptyList()
        {
            // Mock 1 or two teams with NO athletes
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            string teamName = "New York HS";
            int teamID = 6;

            // Act
            IEnumerable<Athlete> athleteList = teamRepo.GetAthletesFor(teamName); 
            // or your choice
            IEnumerable<Athlete> athleteListById = teamRepo.GetAthletesFor(teamID);

            // Assert that this list is empty
            Assert.Multiple(() => {
                Assert.That(athleteList.Count(), Is.EqualTo(0));
                //Assert.That(athleteListById.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public void TeamRepo_GetAthletesForNonExistentTeam_Should_Return_EmptyList()
        {
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            string teamName = "No Team HS";

            // Act
            IEnumerable<Athlete> athleteList = teamRepo.GetAthletesFor(teamName); 

            // Assert that this list is empty
            Assert.That(athleteList.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TeamRepo_GetAthletesForNullTeamName_Should_ThrowException()
        {
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);
            string teamName = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => {teamRepo.GetAthletesFor(teamName);});
        }

        [TestCase(0)]
        [TestCase(-23)]
        public void TeamRepo_GetAthletesForInvalidId_Should_ThrowException(int id)
        {
            // Arrange
            ITeamRepository teamRepo = new TeamRepository(_mockContext.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => {teamRepo.GetAthletesFor(id);});
        }


    }
}