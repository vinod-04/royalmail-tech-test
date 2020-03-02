using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using people.api.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace people.api.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        readonly TechTestContext _dbContext;
        readonly IMapper _mapper;
        readonly ILogger _logger;

        public PeopleRepository(TechTestContext dbContext, IMapper mapper, ILogger<PeopleRepository> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// To add new person to database
        /// </summary>
        /// <param name="entity">People entity</param>
        /// <returns>Rows inserted</returns>
        public async Task Create(People entity)
        {
            await _dbContext.Set<People>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// To delete person from the database
        /// </summary>
        /// <param name="id">Person id to delete</param>
        /// <returns>Rows deleted</returns>
        public async Task Delete(int id)
        {
            var people = await GetById(id);
            var mappedEntity = _mapper.Map<Domain.People>(people);

            _dbContext.Set<People>().Remove(mappedEntity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get person by id
        /// </summary>
        /// <param name="id">Person id</param>
        /// <returns>People entity</returns>
        public async Task<People> GetById(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<People, Models.People>();
            });

            var data = await _dbContext.Set<People>().Include(p => p.PersonSkills).AsNoTracking().FirstOrDefaultAsync(x => x.PersonId == id);
            return data;
        }

        /// <summary>
        /// Update person details and skills
        /// </summary>
        /// <param name="entity">Person details to update</param>
        /// <returns>Rows effected</returns>
        public async Task<int> Update(People entity)
        {
            //First delete this person's skills from the table
            _logger.LogInformation("Deleting person skills");

            _dbContext.PersonSkills.RemoveRange(_dbContext.PersonSkills.Where(x => x.PersonId == entity.PersonId));
            _dbContext.SaveChanges();

            //Now update/add back person skills
            _logger.LogInformation("Updating person skills");

            foreach (var skill in entity.PersonSkills)
            {
                _dbContext.PersonSkills.Add(new PersonSkills { PersonId = entity.PersonId, SkillId = skill.SkillId  });
            }

            entity.PersonSkills = null;
            _dbContext.Set<People>().Update(entity);

            _logger.LogInformation("Updated person details");

            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all people data with skills from database. Lazy loading
        /// </summary>
        /// <returns>Queryable People entity</returns>
        public IQueryable<People> GetAll()
        {
            return _dbContext.Set<People>().Include(p => p.PersonSkills).AsNoTracking();
        }

        /// <summary>
        ///  Get all people data with skills from database. Pagination logic can be added here
        /// </summary>
        /// <returns>List<Models.People></returns>
        async Task<List<Models.People>> IPeopleRepository.GetAllPagedAsync()
        {
            var data = await GetAll().ToListAsync();
            var mappedData = _mapper.Map<List<Models.People>>(data);
            return mappedData;
        }
    }
}
