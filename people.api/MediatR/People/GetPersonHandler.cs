using AutoMapper;
using MediatR;
using people.api.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace people.api.MediatR.People
{
    public class GetPersonHandler : IRequestHandler<GetPersonQuery, Models.People>
    {

        readonly IPeopleRepository _peopleRepository;
        readonly IMapper _mapper;

        public GetPersonHandler(IPeopleRepository peopleRepository, IMapper mapper)
        {
            _peopleRepository = peopleRepository;
            _mapper = mapper;
        }

        public async Task<Models.People> Handle(GetPersonQuery query, CancellationToken cancellationToken)
        {
            var data = await _peopleRepository.GetById(query.PersonId);
            var mappedData = _mapper.Map<Models.People>(data);

            return mappedData;
        }
    }
}
