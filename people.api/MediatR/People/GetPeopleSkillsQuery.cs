using MediatR;
using System.Collections.Generic;

namespace people.api.MediatR.People
{
    public class GetPeopleSkillsQuery : IRequest<List<Models.People>>
    {
    }
}
