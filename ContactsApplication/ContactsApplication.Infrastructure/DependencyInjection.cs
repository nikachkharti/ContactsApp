using ContactsApplication.Application.Contracts;
using ContactsApplication.Infrastructure.Helper;
using ContactsApplication.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace ContactsApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure MongoDB serialization
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            // Configure MongoDB settings
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDB"));

            // Register repositories
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
