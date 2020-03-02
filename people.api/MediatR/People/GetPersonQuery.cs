using MediatR;
using System.Collections.Generic;

namespace people.api.MediatR.People
{
    public class GetPersonQuery : IRequest<Models.People>
    {
        public int PersonId { get; set; }
    }
}
