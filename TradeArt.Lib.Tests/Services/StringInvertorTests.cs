using NUnit.Framework;
using System;
using TradeArt.Lib.Services;

namespace TradeArt.Lib.Tests.Services
{
    public class StringInvertorTests
    {
        private IStringInvertor _stringInvertor;

        [SetUp]
        public void SetUp()
        {
            _stringInvertor = new StringInvertor();
        }

        [Test]
        public void Should_Invert_String()
        {
            // Arrange
            var testString = "This is a test string.";

            // Act
            var result = _stringInvertor.Invert(testString);

            // Assert
            Assert.AreEqual(result, ".gnirts tset a si sihT");
        }

        [Test]
        public void Should_Throw_ArgumentNullException_On_Empty_String()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => _stringInvertor.Invert(null));
        }
    }
}
