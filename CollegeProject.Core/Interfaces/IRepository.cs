using Ardalis.Specification;

namespace CollegeProject.Core.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}