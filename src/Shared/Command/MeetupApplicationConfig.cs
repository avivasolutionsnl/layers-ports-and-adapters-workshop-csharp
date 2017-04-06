using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.CommandLineUtils;

namespace Shared.Command
{
    public class MeetupApplicationConfig
    {
        private IServiceProvider serviceProvider;

        public MeetupApplicationConfig(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Execute(string[] args)
        {
            CommandLineApplication commandLineApplication =
                new CommandLineApplication(throwOnUnexpectedArg: true);

            commandLineApplication.Command("schedule", target => {
                CommandArgument nameArgument = target.Argument("name", "Enter the full name of the meeting");
                CommandArgument descriptionArgument = target.Argument("description", "Enter a description of the meeting");
                CommandArgument scheduledForArgument = target.Argument("scheduledFor", "Enter a date for the meeting");

                target.OnExecute(() => {
                    var commandHandler = serviceProvider.GetService<ScheduleMeetupCommandHandler>();

                    commandHandler.Handle(nameArgument.Value, descriptionArgument.Value, scheduledForArgument.Value);

                    Console.WriteLine("Successfuly scheduled meetup.");                        

                    return 0;
                });
            });

            commandLineApplication.Execute(args);
        }
    }
}