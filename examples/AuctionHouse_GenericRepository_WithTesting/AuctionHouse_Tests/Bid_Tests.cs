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
    public class Bid_Tests
    {
        private Mock<AuctionHouseDbContext> _mockContext;
        private Mock<DbSet<Bid>> _mockBidDbSet;
        private List<Bid> _bids;
        private List<Item> _items;
        private List<Buyer> _buyers;
        private List<Seller> _sellers;

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

            _sellers = new List<Seller>
            {
                new Seller {Id = 1, FirstName = "Llywellyn", LastName = "Naziha"},
                new Seller {Id = 2, FirstName = "Donnchad", LastName = "Hira"}
            };

            _items = new List<Item>
            {
                new Item {Id = 5, Name = "1912 Blue Crayon", Description = "Lightly used", Seller = _sellers[0]},
                new Item {Id = 22, Name = "Diamond Ring", Description = "9.38 Carat Genuine Aquamarine 14K Solid Yellow Gold Luxury Diamond Ring", Seller = _sellers[1]},
                new Item {Id = 4, Name = "Captain Marvel #25 Comic", Description = "Captain Marvel #25, (1968 1st Series Marvel), Thanos app.", Seller = _sellers[0]},
            };

            _bids = new List<Bid>
            {
                new Bid {Id = 1, Price = 3465.45M,TimeSubmitted = new DateTime(2021,11,4,11,30,22),
                    Item = _items[1], Buyer = _buyers[1]},
                new Bid {Id = 2, Price = 3400.01M,TimeSubmitted = new DateTime(2021,11,4,11,15,10),
                    Item = _items[1], Buyer = _buyers[2]},
                new Bid {Id = 3, Price = 12.00M,TimeSubmitted = new DateTime(2020,10,12,8,2,56),
                    Item = _items[0], Buyer = _buyers[2]}
            };

            _mockBidDbSet = GetMockDbSet(_bids.AsQueryable());

            _mockContext = new Mock<AuctionHouseDbContext>();
            _mockContext.Setup(ctx => ctx.Bids).Returns(_mockBidDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Bid>()).Returns(_mockBidDbSet.Object);

        }

        // These are kind of silly since there is no reason to test the IQueryable.Count() method
        // itself.  These are just examples of the process.
        [Test]
        public void Test_BidRepository_HasBidsReturnsNumberOfBids()
        {
            // Arrange
            IBidRepository bidRepo = new BidRepository(_mockContext.Object);
            // Act
            int count = bidRepo.NumberOfBids();
            // Assert
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void Test_BidRepository_NoBidsReturnsCountOf_0()
        {
            // Arrange
            _bids = new List<Bid>{};
            _mockBidDbSet = GetMockDbSet(_bids.AsQueryable());
            _mockContext = new Mock<AuctionHouseDbContext>();
            _mockContext.Setup(ctx => ctx.Bids).Returns(_mockBidDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Bid>()).Returns(_mockBidDbSet.Object);
            IBidRepository bidRepo = new BidRepository(_mockContext.Object);

            // Act
            int count = bidRepo.NumberOfBids();
            // Assert
            Assert.That(count, Is.EqualTo(0));
        }

    }
}