using System.Collections.Generic;

using Shared.Entity;

namespace Web.Models
{
    public class MeetupOverview
    {
        public IEnumerable<Meetup> UpcomingMeetups{get;set;}
        public IEnumerable<Meetup> PastMeetups{get;set;}
    }
}