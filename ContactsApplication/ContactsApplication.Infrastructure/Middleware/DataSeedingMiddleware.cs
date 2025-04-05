using ContactsApplication.Application.Contracts;
using ContactsApplication.Domain.Entities;
using ContactsApplication.Infrastructure.Repository;
using DnsClient.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContactsApplication.Infrastructure.Middleware
{
    public class DataSeedingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DataSeedingMiddleware> _logger;

        public DataSeedingMiddleware(RequestDelegate next, ILogger<DataSeedingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            try
            {
                _logger.LogInformation("Seeding started");

                using var scope = serviceProvider.CreateScope();
                var personRepository = scope.ServiceProvider.GetRequiredService<IPersonRepository>();

                var existingPerson = await personRepository.GetAll(pageNumber: 1, pageSize: 1);
                if (!existingPerson.Any())
                {
                    var people = new List<Person>
                    {
                        new Person()
                        {
                            Id = Guid.Parse("35851DD7-D257-4B9B-85DC-818D0FC80E0C"),
                            Name = "John Lennon"
                        },
                        new Person()
                        {
                            Id = Guid.Parse("5E6C4095-4B9A-49F3-990A-E7375FCEA90A"),
                            Name = "Paul Maccartney"
                        },
                        new Person()
                        {
                            Id = Guid.Parse("9989BF8F-4FF6-4E51-8268-6FC8A8C0D22A"),
                            Name = "Ringo Starr"
                        },
                        new Person()
                        {
                            Id = Guid.Parse("8A9600B6-1984-43FA-943C-C00AE4DA63CD"),
                            Name = "George Harrison"
                        }
                    };


                    foreach (var person in people)
                        await personRepository.Insert(person);

                    _logger.LogInformation("Database seeding completed.");
                }
                else
                {
                    _logger.LogInformation("Database already contains data. Skipping seeding.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Data seeding failed: {ex.Message}");
            }

            await _next(context);
        }
    }
}
