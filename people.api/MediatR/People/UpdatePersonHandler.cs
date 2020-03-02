using MediatR;
using Microsoft.Extensions.Logging;
using people.api.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace people.api.MediatR.People
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        readonly IPeopleRepository _peopleRepository;
        readonly ILogger _logger;

        public UpdatePersonHandler(IPeopleRepository peopleRepository, ILogger<UpdatePersonHandler> logger)
        {
            _peopleRepository = peopleRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating person data...");

            //Get people entity for the current update request
            var personEntity = await _peopleRepository.GetById(request.PersonId);
            personEntity.PersonSkills = new List<Domain.PersonSkills>();

            //update person entity
            personEntity.IsAdmin = request.IsAdmin;
            personEntity.IsEnabled = request.IsEnabled;

            //Add PersonSkills back so that we can process in the repository
            foreach (var skill in request.SkillIds)
            {
                personEntity.PersonSkills.Add(new Domain.PersonSkills { PersonId = request.PersonId, SkillId = skill });
            }

            var rowsEffected = await _peopleRepository.Update(personEntity);

            _logger.LogInformation("Successfully updated person data...");

            return rowsEffected > 0;
        }
    }
}
