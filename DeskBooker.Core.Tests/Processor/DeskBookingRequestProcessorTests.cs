using DeskBooker.Core.Domain;
using NUnit.Framework;
using System;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private DeskBookingRequestProcessor _processor;

        [SetUp]
        public void SetUp()
        {
            _processor = new DeskBookingRequestProcessor();
        }

        [Test]
        public void ShouldReturnDeskBookingResultWithValues()
        {
            // Arrange
            var request = new DeskBookingRequest
            {
                FirstName = "Mike",
                LastName = "Mahachi",
                Email = "iron@mike.com",
                Date = new DateTime(2022, 03, 23)
            };


            // Act
            DeskBookingResult result = _processor.BookDesk(request);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo(request.FirstName));
            Assert.That(result.LastName, Is.EqualTo(request.LastName));
            Assert.That(result.Email, Is.EqualTo(request.Email));
            Assert.That(result.Date, Is.EqualTo(request.Date));
        }

        [Test]
        public void ShouldThrowExceptionIfResultIsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

            Assert.That(exception.ParamName,Is.EqualTo("request"));
        }
    }
}
