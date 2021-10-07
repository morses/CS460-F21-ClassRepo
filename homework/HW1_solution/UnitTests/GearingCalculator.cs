using NUnit.Framework;
using System;
using System.Collections.Generic;
using GearingCalculator.ViewModels;

namespace UnitTests
{
    public class GearingCalculator
    {
        [SetUp]
        public void Setup()
        {
        }

        private static GearingCalcInputVM MakeValidGearingCalcInputVM()
        {
            return new GearingCalcInputVM
            {
                WheelCircumference = 2111.5,
                FrontChainringSizes = "30,46",
                RearChainringSizes = "11,12,15,17,19,21,23,25,27,30,34",
                Cadence = 90,
                DisplayUnits = GearingCalcInputVM.Units[1]  // kph
            };
        }

        [Test]
        public void GearingCalcInputVM_ValidValuesSpeed_IsCorrect()
        {
            // Arrange
            GearingCalcInputVM vm = MakeValidGearingCalcInputVM();
            // Act
            double speed = vm.Speed(30, 11);
            double expected = 90 * (30.0 / 11.0) * 2111.5 * 60 / 1e6;
            // Assert
            Assert.That(speed, Is.EqualTo(expected).Within(0.5).Percent);
        }

        [Test]
        public void GearingCalcInputVM_ValidValuesForFrontChainring_ParseOK()
        {
            // Arrange
            GearingCalcInputVM vm = new GearingCalcInputVM();
            vm.FrontChainringSizes = "36,38,40";
            // Act
            IEnumerable<int> values = vm.FrontChainringValues();
            int[] expected = new[] {36,38,40};
            // Assert
            Assert.That(values,Is.EqualTo(expected).AsCollection);
        }

        [Test]
        public void GearingCalcInputVM_ValidValuesOutOfOrderForFrontChainring_ParseOK()
        {
            // Arrange
            GearingCalcInputVM vm = new GearingCalcInputVM();
            vm.FrontChainringSizes = "38,36,40,22";
            // Act
            IEnumerable<int> values = vm.FrontChainringValues();
            int[] expected = new[] {22,36,38,40};
            // Assert
            Assert.That(values,Is.EqualTo(expected).AsCollection);
        }
    }
}