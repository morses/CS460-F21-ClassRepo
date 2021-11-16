using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;
using AuctionHouse.DAL.Concrete;

namespace AuctionHouse_Tests
{
    public class Buyer_Tests
    {
        private Mock<AuctionHouseDbContext> _mockContext;
        private Mock<DbSet<Buyer>> _mockBuyerDbSet;
        private List<Buyer> _buyers;

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
            // You only need to build data structures with what will be used in a test
            // Adding more here to show how when needed.  If you already have seed data it's fine
            // to reuse that
            _buyers = new List<Buyer>
            {
                new Buyer {Id = 45, FirstName = "Gayle", LastName = "Buran", Email = "burang@yahoo.com"},
                new Buyer {Id = 27, FirstName = "Ruprecht", LastName = "Lizch", Email = "lrup@bizrate.com"},
                new Buyer {Id = 76, FirstName = "Mohammed", LastName = "Alshelem", Email = "mmal@meta.com"}
            };

            _mockBuyerDbSet = GetMockDbSet(_buyers.AsQueryable());

            _mockContext = new Mock<AuctionHouseDbContext>();
            _mockContext.Setup(ctx => ctx.Buyers).Returns(_mockBuyerDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Buyer>()).Returns(_mockBuyerDbSet.Object);

        }

        [Test]
        public void Test_BuyerRepository_ValidBuyerSet_GetEmailList_ReturnsEmailList()
        {
            // Arrange
            IBuyerRepository buyerRepo = new BuyerRepository(_mockContext.Object);
            // Act
            List<string> emailList = buyerRepo.GetEmailList();
            emailList.Sort();
            List<string> expected = new List<string>
            {
                "burang@yahoo.com","lrup@bizrate.com","mmal@meta.com"
            };
            // Assert
            Assert.That(emailList.SequenceEqual(expected));     // SequenceEqual also compares lengths
        }

    }
}