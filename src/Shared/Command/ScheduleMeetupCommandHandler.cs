using System;

using Shared.Entity;

namespace Shared.Command 
{
    public class ScheduleMeetupCommandHandler
    {
        private MeetupRepository meetupRepository;

        public ScheduleMeetupCommandHandler(MeetupRepository meetupRepository)
        {
            this.meetupRepository = meetupRepository;
        }

        public void Handle(string name, string description, string scheduledFor)
        {
            meetupRepository.Add(Meetup.Schedule(
                Name.FromString(name),
                Description.FromString(description), 
                DateTimeOffset.Parse(scheduledFor)));            
        }
    }
}