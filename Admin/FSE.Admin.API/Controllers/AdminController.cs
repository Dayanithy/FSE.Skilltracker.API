namespace FSE.Admin.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IMediator mediator, ILogger<AdminController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("search")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FseProfileDTO>> SearchProfile(SearchProfileQuery searchQuery)
        {
            _logger.LogInformation("FSE search profile endpoint accessed.");

            return await _mediator.Send(searchQuery);
        }

        [HttpGet(Name = "IsAlive")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<int> IsAlive()
        {
            var response = "Admin API is in good health.";
            
            _logger.LogInformation(response);

            return Ok(response);
        }
    }
}
