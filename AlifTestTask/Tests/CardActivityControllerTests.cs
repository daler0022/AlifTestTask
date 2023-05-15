using AlifTestTask.Controllers;
using AlifTestTask.Entities;
using AlifTestTask.Services.CardActivityStorage;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AlifTestTask.Tests
{
    [TestFixture]
    public class CardActivityControllerTests
    {
        [Test]
        public void Post_ShouldAddEventToStorageAndReturnOkResult()
        {
            // Arrange
            var storageMock = new Mock<ICardStorage>();
            var controller = new CardActivityController(storageMock.Object);
            var cardActivityEvent = new CardActivityEvent();

            // Act
            var result = controller.Post(cardActivityEvent);

            // Assert
            storageMock.Verify(s => s.AddEvent(cardActivityEvent), Times.Once);
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
