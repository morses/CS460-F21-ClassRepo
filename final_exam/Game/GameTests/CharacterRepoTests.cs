using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using Game.DAL.Abstract;
using Game.DAL.Concrete;
using Game.Models;

namespace GameTests
{
    // A new version of this file containing some test methods will be available just prior to the exam.  Replace this file with that one.

    public class CharacterRepoTests
    {
        private Mock<GameDbContext> _mockContext;

        private Mock<DbSet<Character>> _mockCharacterDbSet;
        private List<Character>        _characters         = FakeData.Characters;
        private List<CharacterClass>   _characterClass     = FakeData.CharacterClasses;
        private List<Weapon>           _weapons            = FakeData.Weapons;
        private List<Ability>          _abilities          = FakeData.Abilities;
        private List<CharacterAbility> _characterAbilities = FakeData.CharacterAbilities;
        private List<CharacterWeapon>  _characterWeapons   = FakeData.CharacterWeapons;

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
            _mockCharacterDbSet = GetMockDbSet(_characters.AsQueryable());
            // fake the Find method (for a single integer value passed in -- a pain since the signature for Find is (params object[] keyValues)
            _mockCharacterDbSet.Setup(a => a.Find(It.IsAny<object[]>())).Returns((object[] x) => {
                int id = (int)x[0];
                return _characters.Where(c => c.Id == id).First();
            });

            _mockContext = new Mock<GameDbContext>();
            _mockContext.Setup(ctx => ctx.Characters).Returns(_mockCharacterDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Character>()).Returns(_mockCharacterDbSet.Object);


        }

        [Test]
        public void SanityTest()
        {
            Assert.Pass();
        }

        
    }
}