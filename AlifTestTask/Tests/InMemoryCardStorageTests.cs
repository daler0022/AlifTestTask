using AlifTestTask.Entities;
using AlifTestTask.Services.CardActivityStorage;
using NUnit.Framework;

namespace AlifTestTask.Tests
{
    [TestFixture]
    public class InMemoryCardStorageTests
    {
        private InMemoryCardStorage _cardStorage;

        [SetUp]
        public void Setup()
        {
            _cardStorage = new InMemoryCardStorage();
        }

        [Test]
        public void AddEvent_ShouldAddEventToList()
        {
            // Arrange
            var cardActivityEvent = new CardActivityEvent();

            // Act
            _cardStorage.AddEvent(cardActivityEvent);

            // Assert
            var events = _cardStorage.GetAllEvents();
            Assert.Contains(cardActivityEvent, events);
        }

        [Test]
        public void GetAllEvents_ShouldReturnAllEvents()
        {
            // Arrange
            var events = new List<CardActivityEvent>
            {
                new CardActivityEvent(),
                new CardActivityEvent(),
                new CardActivityEvent()
            };
            foreach (var ev in events)
            {
                _cardStorage.AddEvent(ev);
            }

            // Act
            var result = _cardStorage.GetAllEvents();

            // Assert
            Assert.AreEqual(events.Count, result.Count);
            Assert.AreEqual(events, result);
        }
    }

}
