using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ContactsApplication.Domain.Entities
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
