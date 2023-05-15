using AlifTestTask.Entities;

namespace AlifTestTask.Services.CardActivityNotifier
{
    public class ConsoleCardNotifier : ICardNotifier
    {
        public void Notify(CardActivityEvent cardActivityEvent)
        {
            Console.WriteLine($"Received event: " +
                $"{cardActivityEvent.OrderType} - " +
                $"{cardActivityEvent.SessionId} - " +
                $"{cardActivityEvent.Card} - " +
                $"{cardActivityEvent.EventDate} - " +
                $"{cardActivityEvent.WebsiteUrl}"
            );
        }
    }
}
