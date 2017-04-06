using Microsoft.Extensions.DependencyInjection;

using Shared.Entity;
using Shared.Command;

namespace Shared
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<MeetupRepository>(p => new MeetupRepository("//app//var//meetup.txt"));
            services.AddTransient<MeetupApplicationConfig>();
            services.AddTransient<ScheduleMeetupCommandHandler>();

            return services;
        }
    }
}