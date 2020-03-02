using System.Linq;
using System.Threading.Tasks;

namespace people.api.Repository
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetById(int id);
        public Task Create(TEntity entity);
        public Task<int> Update(TEntity entity);
        public Task Delete(int id);
    }
}
