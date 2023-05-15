using AlifTestTask.Entities;
using AlifTestTask.Services.CardActivityNotifier;
using AlifTestTask.Services.CardActivityStorage;
using Microsoft.AspNetCore.Mvc;

namespace AlifTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardActivityController : ControllerBase
    {
        private readonly ICardStorage _storage;

        public CardActivityController(ICardStorage storage)
        {
            _storage = storage;
        }

        [HttpPost]
        public IActionResult Post(CardActivityEvent cardActivityEvent)
        {
            _storage.AddEvent(cardActivityEvent);
            return Ok();
        }
    }

}
