using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using people.api.MediatR.People;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace people.api.Controllers
{
    /// <summary>
    /// JWT Authentication is configured in the startup.cs. But this is not implemented in the UI. All end points allow anonymous access.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/people")]

    public class PeopleController : ControllerBase
    {
        /// <summary>
        /// Meditor pattern for CQRS
        /// </summary>
        readonly IMediator _mediator;
        readonly ILogger _logger;

        public PeopleController(IMediator mediator, ILogger<PeopleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Get all people data with skills from database asynchronously
        /// </summary>
        /// <param name="cancellationToken">To cancel job</param>
        /// <returns>List<Models.People></Models.People></returns>
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult<List<Models.People>>> GetAllPeople(CancellationToken cancellationToken)
        {
            _logger.LogInformation("People data requested");

            var response = await _mediator.Send(new GetPeopleSkillsQuery(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Get person details from database asynchronously
        /// </summary>
        /// <param name="personId">Person Id</param>
        /// <param name="cancellationToken">To cancel job</param>
        /// <returns>List<Models.People></returns>
        [AllowAnonymous]
        [HttpGet("{personId}")]
        public async Task<ActionResult<List<Models.People>>> GetPersonById(int personId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetPersonQuery { PersonId = personId}, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Update person details and skill
        /// </summary>
        /// <param name="request">person details to update</param>
        /// <param name="cancellationToken">To cancel job</param>
        /// <returns>Person data</returns>
        [AllowAnonymous]
        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdatePerson(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Person details update request received");

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(new { success = response });
        }
    }
}
