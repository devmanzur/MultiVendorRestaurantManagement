namespace MessengerBotAPI.ApiContract
{
    public class DetectTextIntentRequest
    {
        public string Text { get; set; }
        public string SessionId { get; set; }
    }
}