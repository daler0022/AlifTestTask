using AlifTestTask.Entities;

namespace AlifTestTask.Services.CardActivityNotifier
{
    public interface ICardNotifier
    {
        void Notify(CardActivityEvent cardActivityEvent);
    }
}
