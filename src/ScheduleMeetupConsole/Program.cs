using System;

using Microsoft.Extensions.DependencyInjection;

using Shared;
using Shared.Command;

namespace ScheduleMeetupConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddAppServices()
                .BuildServiceProvider();                

            var config = serviceProvider.GetService<MeetupApplicationConfig>();

            config.Execute(args);
        }
    }
}
