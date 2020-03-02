using MediatR;
using System.Collections.Generic;

namespace people.api.MediatR.People
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsEnabled { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
