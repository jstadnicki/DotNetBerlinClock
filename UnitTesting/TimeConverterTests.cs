using NUnit.Framework;

namespace BerlinClock.UnitTesting
{
    [TestFixture]
    public class TimeConverterTests
    {

        [Test]
        [TestCase("11pm:59:59", "O\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase("12pm:00:00", "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        public void CanTranslateAmPm(string input, string expected)
        {
            // arrange
            ITimeConverter cut = new TimeConverter();

            // act 
            var result = cut.ConvertTime(input);

            // assert
            Assert.AreEqual(expected, result);
        }
    }

}
