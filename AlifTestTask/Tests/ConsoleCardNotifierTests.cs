using AlifTestTask.Entities;
using AlifTestTask.Services.CardActivityNotifier;
using NUnit.Framework;

namespace AlifTestTask.Tests
{
    [TestFixture]
    public class ConsoleCardNotifierTests
    {
        private StringWriter _consoleOutput;
        private ConsoleCardNotifier _cardNotifier;

        [SetUp]
        public void Setup()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);

            _cardNotifier = new ConsoleCardNotifier();
        }

        [Test]
        public void Notify_ShouldWriteEventToConsole()
        {
            // Arrange
            var cardActivityEvent = new CardActivityEvent
            {
                OrderType = "TestOrder",
                SessionId = "123456",
                Card = "1234-5678-9012-3456",
                EventDate = DateTime.Now,
                WebsiteUrl = "https://example.com"
            };

            // Act
            _cardNotifier.Notify(cardActivityEvent);

            // Assert
            var consoleOutput = _consoleOutput.ToString();
            var expectedOutput = $"Received event: {cardActivityEvent.OrderType} - {cardActivityEvent.SessionId} - {cardActivityEvent.Card} - {cardActivityEvent.EventDate} - {cardActivityEvent.WebsiteUrl}{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput);
        }
    }
}
