using System;

using Shared.Entity;

namespace Meetup.Util
{
    public class MeetupFactory
    {
        public static Shared.Entity.Meetup SomeMeetup() 
        {
            return UpcomingMeetup();
        }

        public static Shared.Entity.Meetup UpcomingMeetup()
        {
            return Shared.Entity.Meetup.Schedule(
                Name.FromString("Name"),
                Description.FromString("Description"),
                DateTimeOffset.Parse("01-01-2020"));
        }

        public static Shared.Entity.Meetup PastMeetup()
        {
            return Shared.Entity.Meetup.Schedule(
                Name.FromString("Name"),
                Description.FromString("Description"),
                DateTimeOffset.Parse("01-01-2017"));
        }
    }
}