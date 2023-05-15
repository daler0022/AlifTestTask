using AlifTestTask.Entities;

namespace AlifTestTask.Services.CardActivityStorage
{
    public interface ICardStorage
    {
        void AddEvent(CardActivityEvent cardActivityEvent);
        List<CardActivityEvent> GetAllEvents();
    }
}
