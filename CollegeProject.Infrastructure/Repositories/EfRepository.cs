using Ardalis.Specification.EntityFrameworkCore;
using CollegeProject.Core.Interfaces;
using CollegeProject.Infrastructure.Data;

namespace CollegeProject.Infrastructure.Repositories;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(CollegeContext dbContext) : base(dbContext)
    {
    }
}

