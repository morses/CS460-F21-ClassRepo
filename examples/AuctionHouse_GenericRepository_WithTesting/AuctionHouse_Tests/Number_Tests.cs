using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AuctionHouse.Models;

namespace AuctionHouse_Tests
{
    public class Number_Tests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_ForTest_Add_Valid_Numbers()
        {
            // Arrange
            double a = 4.5;
            double b = 20;

            // Act
            double output = ForTest.AddNumbers(a, b);

            // Assert
            Assert.That(output,Is.EqualTo(24.5).Within(0.0000001));
        }
    }
}