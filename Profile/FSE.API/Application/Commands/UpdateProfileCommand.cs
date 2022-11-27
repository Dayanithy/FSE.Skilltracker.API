namespace FSE.API.Application.Commands
{
    public class UpdateProfileCommand : IRequest<string>
    {
        public string? AssociateId { get; set; }
        public List<SkillDTO>? Skills { get; set; }
    }

    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, string>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ILogger<AddProfileCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(IProfileRepository profileRepository, ILogger<AddProfileCommandHandler> logger, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            FseProfileDTO profile = new FseProfileDTO
            {
                AssociateId = request.AssociateId,
                Skills = request.Skills
            };

            var success = await _profileRepository.UpdateProfile(_mapper.Map<FseProfile>(profile));

            _logger.LogInformation($"Associate details updated for Associate ID: {success}.");

            // TODO: Publish an event to RabbitMq notifying user updates

            return success;
        }
    }
}
