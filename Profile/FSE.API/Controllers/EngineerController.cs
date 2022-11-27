namespace FSE.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EngineerController> _logger;
        private readonly IValidator<AddProfileCommand> _validator;
        public EngineerController(IMediator mediator, ILogger<EngineerController> logger, 
            IValidator<AddProfileCommand> validator)
        {
            _mediator = mediator;
            _logger = logger;
            _validator = validator;
        }

        [HttpPost("add-profile")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddProfile([FromBody] AddProfileCommand command)
        {
            _logger.LogInformation("--> Add Profile endpoint is accessed.");

            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            var okResult = await _mediator.Send(command);
            return Ok(okResult);
        }

        [HttpPut("update-profile")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateProfile([FromBody] UpdateProfileCommand command,
            [FromHeader(Name = "x-userid")] string userId)
        {
            _logger.LogInformation("--> Update Profile endpoint is accessed.");

            if (string.IsNullOrWhiteSpace(userId))
            {
                var errors = new List<ValidationFailure> { new ValidationFailure("", "UserId header missing") };
                throw new FluentValidation.ValidationException(errors);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("is-alive")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<int> IsAlive()
        {
            _logger.LogInformation("--> Profile API is in good health.");

            return Ok();
        }
    }
}
