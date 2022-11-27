using System.Text.Json;

namespace FSE.Admin.API.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EventProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void ProcessEvent(string message)
        {
            if (message == null)
                return;

            var receivedMessage = JsonSerializer.Deserialize<ProfilePublishedDTO>(message);

            Console.WriteLine($"--> Received event of type: {receivedMessage!.Event}");

            // TODO: Update cache to refresh the updates

            Console.WriteLine("--> Handled received event on the message bus...");
        }
    }
}
