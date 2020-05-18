using System.IO;
using System.Threading.Tasks;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using MessengerBotAPI.ApiContract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MessengerBotAPI.Controllers
{
    [Route("api/bot")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static JsonParser _jsonParser;
        private SessionsClient _client;
        private const string ProjectId = "food-delivery-umawew";

        public MessageController()
        {
            _jsonParser =
                new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
            _client = SessionsClient.Create();
        }

        [HttpPost("dialog-callback")]
        public async Task<ContentResult> DialogAction()
        {
            string requestJson;
            using (TextReader reader = new StreamReader(Request.Body))
            {
                requestJson = await reader.ReadToEndAsync();
            }

            var request = _jsonParser.Parse<WebhookRequest>(requestJson);

            var response = new WebhookResponse()
            {
                FulfillmentText = "Thank you for contacting us",
            };
            var responseJson = response.ToString();
            return Content(responseJson, "application/json");
        }

        [HttpPost("detect-intent")]
        public async Task<IActionResult> DetectIntent(DetectTextIntentRequest request)
        {
            var response = await _client.DetectIntentAsync(
                session: SessionName.FromProjectSession(ProjectId, request.SessionId),
                queryInput: new QueryInput()
                {
                    Text = new TextInput()
                    {
                        Text = request.Text,
                        LanguageCode = "en"
                    }
                }
            );
            return Ok(response);
        }
    }
}