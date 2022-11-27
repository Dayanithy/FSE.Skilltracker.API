using FSE.API.AsyncDataServices;

namespace FSE.API.Application.Commands
{
    public class AddProfileCommand : IRequest<string>
    {
        public string? AssociateId { get; set; }

        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
                
        [Phone]
        public string? Mobile { get; set; }

        public List<SkillDTO>? Skills { get; set; }
    }

    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, string>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ILogger<AddProfileCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public AddProfileCommandHandler(IProfileRepository profileRepository, ILogger<AddProfileCommandHandler> logger, IMapper mapper,
            IMessageBusClient messageBusClient)
        {
            _profileRepository = profileRepository;
            _logger = logger;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }
        public async Task<string> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            //var result = await _profileRepository.AddProfile(_mapper.Map<FseProfile>(request));
            var result = string.Empty;

            _logger.LogInformation($"--> Associate successfully added with Associate ID: {result}.");

            // TODO: Publish an event to RabbitMq notifying user addition
            try
            {
                var updatedProfile = new ProfileUpdatedDTO { AssociateId = "CTS1234", Event = "Add_Profile" };
                _messageBusClient.PublishProfileUpdates(updatedProfile);
            }
            catch (Exception)
            {
                Console.Write("--> Could not send message via Message Bus client...");
            }

            return result;
        }
    }
}
