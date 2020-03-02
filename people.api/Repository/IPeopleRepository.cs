using people.api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace people.api.Repository
{
    public interface IPeopleRepository : IGenericRepository<People>
    {
        Task<List<Models.People>> GetAllPagedAsync();
    }
}
