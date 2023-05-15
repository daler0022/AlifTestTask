namespace AlifTestTask.Entities
{
    public class CardActivityEvent
    {
        public string OrderType { get; set; }
        public string SessionId { get; set; }
        public string Card { get; set; }
        public DateTime EventDate { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
