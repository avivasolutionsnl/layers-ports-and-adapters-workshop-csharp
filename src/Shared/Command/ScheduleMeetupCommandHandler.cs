using System;

using Shared.Entity;

namespace Shared.Command 
{
    public class ScheduleMeetupCommandHandler
    {
        public void Handle(string name, string description, string scheduledFor)
        {
            var meetupRepository = new MeetupRepository("//app//var//meetup.txt");

            meetupRepository.Add(Meetup.Schedule(
                Name.FromString(name),
                Description.FromString(description), 
                DateTimeOffset.Parse(scheduledFor)));            
        }
    }
}