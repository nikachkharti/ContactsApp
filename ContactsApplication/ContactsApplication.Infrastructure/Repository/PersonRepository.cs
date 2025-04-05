using ContactsApplication.Application.Contracts;
using ContactsApplication.Domain.Entities;
using ContactsApplication.Infrastructure.Helper;
using Microsoft.Extensions.Options;

namespace ContactsApplication.Infrastructure.Repository
{
    public class PersonRepository : MongoRepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IOptions<MongoDbSettings> options) : base(options, "contacts")
        {
        }
    }
}
