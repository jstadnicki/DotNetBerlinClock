using NUnit.Framework;
using System;

namespace BerlinClock.UnitTesting
{
    [TestFixture]
    class BerlinUhrTimeSpanConverterTests
    {
        [Test]
        public void WhenSectionExceedTimeRangeExceptionIsThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BerlinUhrTimeSpanConverter.Parse("25:00:00"));
            Assert.Throws<ArgumentOutOfRangeException>(() => BerlinUhrTimeSpanConverter.Parse("-1:00:00"));
            Assert.Throws<ArgumentOutOfRangeException>(() => BerlinUhrTimeSpanConverter.Parse("2:-10:00"));
            Assert.Throws<ArgumentOutOfRangeException>(() => BerlinUhrTimeSpanConverter.Parse("2:110:00"));
            Assert.Throws<ArgumentOutOfRangeException>(() => BerlinUhrTimeSpanConverter.Parse("2:10:61"));
            Assert.Throws<ArgumentOutOfRangeException>(() => BerlinUhrTimeSpanConverter.Parse("2:10:4568"));
        }
    }
}
