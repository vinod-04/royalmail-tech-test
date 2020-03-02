using MediatR;
using Microsoft.Extensions.Logging;
using people.api.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace people.api.MediatR.People
{
    public class GetPeopleSkillsHandler : IRequestHandler<GetPeopleSkillsQuery, List<Models.People>>
    {

        readonly IPeopleRepository _peopleRepository;
        readonly ILogger _logger;

        public GetPeopleSkillsHandler(IPeopleRepository peopleRepository, ILogger<GetPeopleSkillsHandler> logger)
        {
            _peopleRepository = peopleRepository;
            _logger = logger;
        }

        public async Task<List<Models.People>> Handle(GetPeopleSkillsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching people skills data...");
            var data = await _peopleRepository.GetAllPagedAsync();

            _logger.LogInformation("Successfully fetched data");
            return data;
        }
    }
}
