namespace FSE.Admin.API.Application.Queries
{
    public class SearchProfileQuery : IRequest<IEnumerable<FseProfileDTO>>
    {
        public string? AssociateId { get; set; }
        public string? Name { get; set; }
        public string? SkillName { get; set; }
    }

    public class SearchProfileQueryHandler : IRequestHandler<SearchProfileQuery, IEnumerable<FseProfileDTO>>
    {
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchProfileQueryHandler> _logger;
        private readonly IMapper _mapper;

        public SearchProfileQueryHandler(ISearchService searchService, ILogger<SearchProfileQueryHandler> logger, IMapper mapper)
        {
            _searchService = searchService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FseProfileDTO>> Handle(SearchProfileQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Search with AssociateId={request.AssociateId} Name={request.Name} Skill={request.SkillName}");
            
            var response = new List<FseProfileDTO>();

            if (!string.IsNullOrWhiteSpace(request.AssociateId))
            {
                var profile = await _searchService.SearchByAssociateId(request.AssociateId);
                if (profile != null)
                {
                    response.Add(_mapper.Map<FseProfileDTO>(profile));
                }
                
                return response;
            }
            else if (!string.IsNullOrWhiteSpace(request.Name))
            {
                var result = await _searchService.SearchByAssociateName(request.Name);
                
                return _mapper.Map<List<FseProfileDTO>>(result);
            }
            else if (!string.IsNullOrWhiteSpace(request.SkillName))
            {
                var result = await _searchService.SearchBySkillName(request.SkillName);

                return _mapper.Map<List<FseProfileDTO>>(result);
            }

            return new List<FseProfileDTO>();
        }
    }
}
