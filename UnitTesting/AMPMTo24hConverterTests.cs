using NUnit.Framework;
using System;

namespace BerlinClock.UnitTesting
{
    [TestFixture]
    public class AMPMTo24hConverterTests
    {
        [TestCase("1pm", 13)]
        [TestCase("13", 13)]
        [TestCase("1PM", 13)]
        [TestCase("12pm", 24)]
        [TestCase("24", 24)]
        [TestCase("12am", 12)]
        [TestCase("2am", 2)]
        [TestCase("2", 2)]
        [TestCase("2AM", 2)]
        public void T(string input, int expected)
        {
            Assert.AreEqual(expected, AMPMTo24hConverter.Convert(input));
        }

        public void T()
        {
            Assert.Throws<ArgumentNullException>(() => AMPMTo24hConverter.Convert(null));
            Assert.Throws<ArgumentNullException>(() => AMPMTo24hConverter.Convert(string.Empty));
        }

    }

}
