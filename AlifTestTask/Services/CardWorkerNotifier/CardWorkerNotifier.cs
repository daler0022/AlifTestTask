using AlifTestTask.Services.CardActivityNotifier;
using AlifTestTask.Services.CardActivityStorage;

namespace AlifTestTask.Services.CardWorkerNotifier
{
    public class CardWorkerNotifier : BackgroundService
    {
        private readonly ICardStorage _storage;
        private readonly ICardNotifier _notifier;
        private readonly List<string> _processedEvents = new List<string>();

        public CardWorkerNotifier(ICardStorage storage, ICardNotifier notifier)
        {
            _storage = storage;
            _notifier = notifier;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var cardEvent in _storage.GetAllEvents())
                {
                    if (_processedEvents.Contains(cardEvent.SessionId))
                        continue;

                    _processedEvents.Add(cardEvent.SessionId);
                    _notifier.Notify(cardEvent);
                }

                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }
    }
}
