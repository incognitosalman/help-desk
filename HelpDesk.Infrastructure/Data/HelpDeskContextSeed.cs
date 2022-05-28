using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HelpDesk.Infrastructure.Persistence
{
    public class HelpDeskContextSeed
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var loggerFactory = scope.ServiceProvider.GetService<ILoggerFactory>();

                using (var context = scope.ServiceProvider.GetService<HelpDeskContext>())
                {
                    EnsureSeedData(context, loggerFactory);
                }
            }
        }

        private static void EnsureSeedData(HelpDeskContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.TicketSources.Any())
                {
                    var tempData = File.ReadAllText("../HelpDesk.Infrastructure/Persistence/SeedData/ticket-sources.json");
                    var temp = JsonSerializer.Deserialize<List<TicketSource>>(tempData);
                    foreach (var record in temp)
                    {
                        context.TicketSources.Add(record);
                    }
                }

                if (!context.TicketGroups.Any())
                {
                    var tempData = File.ReadAllText("../HelpDesk.Infrastructure/Persistence/SeedData/ticket-groups.json");
                    var temp = JsonSerializer.Deserialize<List<TicketGroup>>(tempData);
                    foreach (var record in temp)
                    {
                        context.TicketGroups.Add(record);
                    }
                }

                if (!context.TicketPriorities.Any())
                {
                    var tempData = File.ReadAllText("../HelpDesk.Infrastructure/Persistence/SeedData/ticket-priorities.json");
                    var temp = JsonSerializer.Deserialize<List<TicketPriority>>(tempData);
                    foreach (var record in temp)
                    {
                        context.TicketPriorities.Add(record);
                    }
                }

                if (!context.TicketStates.Any())
                {
                    var tempData = File.ReadAllText("../HelpDesk.Infrastructure/Persistence/SeedData/ticket-states.json");
                    var temp = JsonSerializer.Deserialize<List<TicketState>>(tempData);
                    foreach (var record in temp)
                    {
                        context.TicketStates.Add(record);
                    }
                }

                if (!context.TicketTypes.Any())
                {
                    var tempData = File.ReadAllText("../HelpDesk.Infrastructure/Persistence/SeedData/ticket-types.json");
                    var temp = JsonSerializer.Deserialize<List<TicketType>>(tempData);
                    foreach (var record in temp)
                    {
                        context.TicketTypes.Add(record);
                    }
                }
                
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<HelpDeskContextSeed>();
                logger.LogError($"Error while seeding data", ex);
            }
        }
    }
}
