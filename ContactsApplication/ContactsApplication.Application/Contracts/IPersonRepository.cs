using ContactsApplication.Domain.Entities;

namespace ContactsApplication.Application.Contracts
{
    public interface IPersonRepository : IMongoRepositoryBase<Person>
    {
    }
}
