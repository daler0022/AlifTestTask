using AlifTestTask.Entities;

namespace AlifTestTask.Services.CardActivityStorage
{
    public class InMemoryCardStorage : ICardStorage
    {
        private readonly List<CardActivityEvent> _events = new List<CardActivityEvent>();

        public void AddEvent(CardActivityEvent cardActivityEvent)
        {
            _events.Add(cardActivityEvent);
        }

        public List<CardActivityEvent> GetAllEvents()
        {
            return _events;
        }
    }
}
